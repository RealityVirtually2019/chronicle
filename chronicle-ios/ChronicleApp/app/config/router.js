import React from 'react';
import { Text, View } from 'react-native';
import { createBottomTabNavigator, createAppContainer } from 'react-navigation';
import TextScreen from '../screens/Text';
import PhotoScreen from '../screens/Photo';

class TextTab extends React.Component {
  render() {
    return (
      <TextScreen {...this.props}/>
    );
  }
}

class PhotoTab extends React.Component {
  render() {
    return (
      <PhotoScreen {...this.props}/>
    );
  }
}

class AudioTab extends React.Component {
  render() {
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text>Settings!</Text>
      </View>
    );
  }
}

class URLTab extends React.Component {
  render() {
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text>Settings!</Text>
      </View>
    );
  }
}

const TabNavigator = createBottomTabNavigator({
  Text: {
    screen: (props) => <TextTab {...props.screenProps}/>
  },
  Photo: {
    screen: (props) => <PhotoTab {...props.screenProps}/>
  },
  Audio: AudioTab,
  URL: URLTab,
});

export const AppContainer = createAppContainer(TabNavigator);
