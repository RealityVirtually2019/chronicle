import React from 'react';
import { Button, TextInput, View } from 'react-native';

export default class TextScreen extends React.Component {
  constructor(props) {
    super(props);
    this.state = { text: '' };
  }

  render() {
    
    const onPressSubmit = () => {
      makeRequest(this.state.text);
      this.setState({ text: '' });
    }

    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <TextInput
          style={{height: 40, width: '80%', borderColor: 'gray', borderWidth: 1, padding: '2.5%'}}
          placeholder='Write anything...'
          onChangeText={(text) => this.setState({text})}
          value={this.state.text}
        />
        <Button
          onPress={onPressSubmit}
          title="Submit"
        />
      </View>
    );
  }
}

const makeRequest = (textString) => {
  
}