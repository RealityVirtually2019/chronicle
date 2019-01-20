const app = require('express')();
const bodyParser = require('body-parser');
const http = require('http').Server(app);
const storage = require('node-persist');

const port = process.env.PORT || 8080;
app.use(bodyParser.json({limit: '50mb'}));
app.use(bodyParser.urlencoded({limit: '50mb', extended: true}));

app.get('/ping', (req, res) => {
  res.send('pong');
});

app.post('/chronicle/:contentType', async (req, res) => {
  req.setTimeout(1000000);
  await storage.init();
  const storageItem = req.body.data;
  console.log('Setting item of type: ' + req.body.type);
  await storage.setItem('latest', {type: req.params.contentType, data: storageItem});
});

app.get('/latest', async (req, res) => {
  await storage.init();
  const storageItem = await storage.getItem('latest');
  if (storageItem === undefined) {
    console.log('No new items');
    res.send({type: '', data: ''});
  } else {
    console.log('Found latest item with type ' + storageItem.type); 
    await storage.removeItem('latest');
    res.send(storageItem);
  }
});

http.timeout = 60000;
http.listen(port, () => {
  console.log(`Server running at ${port}`);
});