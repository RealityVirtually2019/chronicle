import React, { Component } from 'react';
import { AppContainer } from './config/router';

class App extends Component {
  constructor(props) {
    super(props);
    // this.endpoint = 'https://chronicle-client-server.herokuapp.com/chronicle';
    this.endpoint = 'http://localhost:8080/chronicle';
  }
  render() {
    return <AppContainer screenProps={{endpoint: this.endpoint}}/>;
  }
}

export default App;
