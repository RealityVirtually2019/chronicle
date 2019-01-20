const app = require('express')();
const bodyParser = require('body-parser');
const http = require('http').Server(app);
const storage = require('node-persist');

const port = process.env.PORT || 8080;
app.use(bodyParser.json({limit: '50mb'}));
app.use(bodyParser.urlencoded({limit: '50mb', extended: true}));

const extendTimeoutMiddleware = (req, res, next) => {
  const space = ' ';
  let isFinished = false;
  let isDataSent = false;

  // Only extend the timeout for API requests
  if (!req.url.includes('/api')) {
    next();
    return;
  }

  res.once('finish', () => {
    isFinished = true;
  });

  res.once('end', () => {
    isFinished = true;
  });

  res.once('close', () => {
    isFinished = true;
  });

  res.on('data', (data) => {
    // Look for something other than our blank space to indicate that real
    // data is now being sent back to the client.
    if (data !== space) {
      isDataSent = true;
    }
  });

  const waitAndSend = () => {
    setTimeout(() => {
      // If the response hasn't finished and hasn't sent any data back....
      if (!isFinished && !isDataSent) {
        // Need to write the status code/headers if they haven't been sent yet.
        if (!res.headersSent) {
          res.writeHead(202);
        }

        res.write(space);

        // Wait another 15 seconds
        waitAndSend();
      }
    }, 15000);
  };

  waitAndSend();
  next();
};

app.use(extendTimeoutMiddleware);

app.get('/ping', (req, res) => {
  res.send('pong');
});

app.post('/chronicle/:contentType', async (req, res) => {
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

http.listen(port, () => {
  console.log(`Server running at ${port}`);
});