import React from 'react';
import {
  Button,
  Image,
  Text,
  TouchableHighlight,
  View
} from 'react-native';
import Emoji from 'react-native-emoji';

export default class MusicScreen extends React.Component {
  constructor(props) {
    super(props);
  }

  makeRequest(musicData, endpoint) {
    console.log(musicData);
    fetch(`${endpoint}/music`, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        type: 'music',
        data: musicData,
      }),
    });
  }

  render() {
    let rowIndex = 0;
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text style={{fontWeight: 'bold', paddingBottom: 10}}>Choose your favorite music <Emoji name='notes'/></Text>
        {albums.map(albumRow => {
          rowIndex++;
          return (
            <View key={rowIndex} style={{ flexDirection: 'row', alignItems: 'center' }}>
              {albumRow.map(album => {
                return (
                  <TouchableHighlight key={album.id} onPress={() => this.makeRequest(album.id, this.props.endpoint)}>
                    <Image source={album.url} style={{ width: 150, height: 150 }}/>
                  </TouchableHighlight>
                );
              })}
            </View>);
        })}
      </View>
    );
  }

}

const albums = [
  [{
    id: 'DeLa',
    url: require('../static/DeLa.jpg')
  },
  {
    id: 'Sylvia',
    url: require('../static/Sylvia.jpg')
  }],
  [{
    id: 'Moody',
    url: require('../static/Moody.jpg')
  },
  {
    id: 'Nas',
    url: require('../static/Nas.jpg')
  }]
]