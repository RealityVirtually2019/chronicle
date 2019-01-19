const app = require('express')();
const bodyParser = require('body-parser');
const http = require('http').Server(app);
const storage = require('node-persist');

const port = process.env.PORT || 8080;

app.get('/ping', async (req, res) => {
  //you must first call storage.init
  await storage.init( /* options ... */ );
  await storage.setItem('name','yourname')
  const name = await storage.getItem('name')
  console.log(await storage.getItem('name')); // yourname
  res.send(name);
});

app.post('/chronicle/text', (req, res) => {
  console.log(req.body);
});

http.listen(port, () => {
  console.log(`Server running at ${port}`);
});