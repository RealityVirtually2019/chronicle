import React from 'react';
import {Button, Image, Text, View} from 'react-native';
import ImagePicker from 'react-native-image-picker';

import {RNS3} from 'react-native-aws3';

export default class PhotoScreen extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      photos: []
    };
  }

  _showPicker() {
    const options = {
      title: 'Select Photo/Video',
      storageOptions: {
        skipBackup: true,
        path: 'images'
      },
      quality: 0.1
    };

    ImagePicker.showImagePicker(options, (response) => {
      console.log('Response = ', response);

      if (response.didCancel) {
        console.log('User cancelled image picker');
      } else if (response.error) {
        console.log('ImagePicker Error: ', response.error);
      } else {
        const source = {
          uri: response.uri
        };

        // You can also display the image using data:
        const sourceData = {
          uri: response.data
        };

        this.setState({mediaSrc: source, mediaSrcData: sourceData});
      }
    });
  };

  render() {
    const image = (imageSrc) => {
      if (imageSrc) {
        console.log(imageSrc);
        return <Image
          source={imageSrc}
          style={{
          width: 250,
          height: 250
        }}/>;
      }
      return <Image
        source={require('../static/placeholder-image.jpg')}
        style={{
        width: 250,
        height: 250
      }}/>;
    }

    const onPressSubmit = () => {
      makeRequest(this.state.mediaSrc, this.props.endpoint);
    }

    const disabledBool = this.state.mediaSrc === undefined;
    return (
      <View
        style={{
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center'
      }}>
        {image(this.state.mediaSrc)}
        <Button
          title='Load Image'
          onPress={this
          ._showPicker
          .bind(this)}/>
        <Button title='Submit' onPress={onPressSubmit} disabled={disabledBool}/>
      </View>
    );
  }

}

function generateUUID() { // Public Domain/MIT
  var d = new Date().getTime();
  if (typeof performance !== 'undefined' && typeof performance.now === 'function') {
    d += performance.now(); //use high-precision timer if available
  }
  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
    var r = (d + Math.random() * 16) % 16 | 0;
    d = Math.floor(d / 16);
    return (c === 'x'
      ? r
      : (r & 0x3 | 0x8)).toString(16);
  });
}

const makeRequest = (imageData, endpoint) => {

  console.log(imageData.uri);
  const file = {
    // `uri` can also be a file system path (i.e. file://)
    uri: imageData.uri,
    name: generateUUID(),
    type: "image/jpeg"
  }

  const options = {
    bucket: "chronicle-ios-app",
    region: "us-east-1",
    accessKey: "your-access-key",
    secretKey: "your-secret-key"
  }

  RNS3
    .put(file, options)
    .then(response => {
      if (response.status !== 201) 
        throw new Error("Failed to upload image to S3");
      console.log(response.body);
      /**
     * {
     *   postResponse: {
     *     bucket: "your-bucket",
     *     etag : "9f620878e06d28774406017480a59fd4",
     *     key: "uploads/image.png",
     *     location: "https://your-bucket.s3.amazonaws.com/uploads%2Fimage.png"
     *   }
     * }
     */
      fetch(`${endpoint}/photo`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(
          {
            type: 'photo',
            data: response.body.postResponse.location
          })
      });
    });
}