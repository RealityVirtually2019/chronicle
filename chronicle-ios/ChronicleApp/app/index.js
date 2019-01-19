import React, { Component } from 'react';
import { AppContainer } from './config/router';
import io from 'socket.io-client';

class App extends Component {
  constructor(props) {
    super(props);
    this.socket = io('https://chronicle-client-server.herokuapp.com');
  }
  render() {
    return <AppContainer screenProps={{socket: this.socket}}/>;
  }
}

export default App;
