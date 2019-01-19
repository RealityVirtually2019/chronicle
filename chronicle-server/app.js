const app = require('express')();
const bodyParser = require('body-parser');
const http = require('http').Server(app);
const storage = require('node-persist');

const port = process.env.PORT || 8080;
app.use(bodyParser.json());

app.get('/ping', (req, res) => {
  res.send(name);
});

app.post('/chronicle/text', async (req, res) => {
  await storage.init();
  const storageItem = req.body.data;
  console.log('Setting item to latest: ' + storageItem);
  await storage.setItem('latest', {type: 'text', data: storageItem});
});

app.get('/latest', async (req, res) => {
  await storage.init();
  const storageItem = await storage.getItem('latest');
  if (storageItem === undefined) {
    console.log('No new items');
    res.send('');
  } else {
    console.log('Found latest item: '  + storageItem.data + ' with type ' + storageItem.type); 
    await storage.removeItem('latest');
    res.send(storageItem);
  }
});

http.listen(port, () => {
  console.log(`Server running at ${port}`);
});