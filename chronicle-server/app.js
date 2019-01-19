const app = require('express')();
const http = require('http').Server(app);
const io = require('socket.io')(http);

const port = process.env.PORT || 8080;

app.get('/ping', (req, res) => {
  res.send('pong');
});

io.on('connection', function(socket) {
  console.log('a user connected');

  socket.on('chronicle-channel-text', function(msg){
    console.log('message: ' + msg);
    // emit text message to all users in channel
    io.emit('chronicle-channel-text', msg);
  });

  socket.on('disconnect', function() {
    console.log('user disconnected');
  });
});

http.listen(port, () => {
  console.log(`Server running at ${port}`);
});