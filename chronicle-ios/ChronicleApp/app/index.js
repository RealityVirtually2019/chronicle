import React, { Component } from 'react';
import { AppContainer } from './config/router';
import io from 'socket.io-client';

class App extends Component {
  constructor(props) {
    super(props);
    this.socket = io('http://localhost:8080');
  }
  render() {
    return <AppContainer screenProps={{socket: this.socket}}/>;
  }
}

export default App;
