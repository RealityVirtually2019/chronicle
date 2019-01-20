import React from 'react';
import {
  Button,
  Image,
  Text,
  View
} from 'react-native';
import ImagePicker from 'react-native-image-picker';

export default class PhotoScreen extends React.Component {
  constructor(props) {
    super(props);
    this.state = { photos: [] };
  }

  _showPicker() {
    const options = {
      title: 'Select Photo/Video',
      storageOptions: {
        skipBackup: true,
        path: 'images',
      },
    };

    ImagePicker.showImagePicker(options, (response) => {
      console.log('Response = ', response);
  
      if (response.didCancel) {
        console.log('User cancelled image picker');
      } else if (response.error) {
        console.log('ImagePicker Error: ', response.error);
      } else {
        const source = { uri: response.uri };
  
        // You can also display the image using data:
        const sourceData = { uri: 'data:image/jpeg;base64,' + response.data };
  
        this.setState({
          mediaSrc: source,
          mediaSrcData: sourceData
        });
      }
    });
  };

  render() {
    const image = (imageSrc) => {
      if (imageSrc) {
        console.log(imageSrc);
        return <Image source={imageSrc} style={{ width: 250, height: 250 }}/>;
      }
      return <Image source={require('../static/placeholder-image.jpg')} style={{ width: 250, height: 250 }}/>;
    }

    const onPressSubmit = () => {
      makeRequest(this.state.mediaSrcData, this.props.endpoint);
    }

    const disabledBool = this.state.mediaSrc === undefined;
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        {image(this.state.mediaSrc)}
        <Button title='Load Image' onPress={this._showPicker.bind(this)} />
        <Button title='Submit' onPress={onPressSubmit} disabled={disabledBool}/>
      </View>
    );
  }

}

const makeRequest = (imageData, endpoint) => {
  console.log(imageData);
  fetch(`${endpoint}/photo`, {
    method: 'POST',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      type: 'photo',
      data: imageData.uri,
    }),
  });
}