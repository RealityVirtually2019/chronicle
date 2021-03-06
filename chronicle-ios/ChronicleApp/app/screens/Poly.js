import React from 'react';
import {
  Image,
  Text,
  TouchableHighlight,
  View
} from 'react-native';

export default class PhotoScreen extends React.Component {
  constructor(props) {
    super(props);
  }

  makeRequest(polyData, endpoint) {
    console.log(polyData);
    fetch(`${endpoint}/poly`, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        type: 'poly',
        data: polyData,
      }),
    });
  }

  render() {
    let rowIndex = 0;
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text style={{fontWeight: 'bold', paddingBottom: 10}}>Choose any Poly model</Text>
        {polyModels.map(polyModelRow => {
          rowIndex++;
          return (
            <View key={rowIndex} style={{ flexDirection: 'row', alignItems: 'center' }}>
              {polyModelRow.map(polyModel => {
                return (
                  <TouchableHighlight key={polyModel.id} onPress={() => this.makeRequest(polyModel.id, this.props.endpoint)}>
                    <Image source={polyModel.url} style={{ width: 150, height: 150 }}/>
                  </TouchableHighlight>
                );
              })}
            </View>);
        })}
      </View>
    );
  }

}

const polyModels = [
  [{
    id: 'AstronautPoly',
    url: require('../static/astronaut.jpg')
  },
  {
    id: 'BoomboxPoly',
    url: require('../static/boombox.jpg')
  }],
  [{
    id: 'PalmTreePoly',
    url: require('../static/palmtree.jpg')
  },
  {
    id: 'GameBoyPoly',
    url: require('../static/gameboy.jpg')
  }],
  [{
    id: 'BurgerPoly',
    url: require('../static/burger.jpg')
  },
  {
    id: 'PizzaPoly',
    url: require('../static/pizza.jpg')
  }]
]