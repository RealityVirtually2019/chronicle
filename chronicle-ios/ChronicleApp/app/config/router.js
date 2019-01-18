import React from 'react';
import { Text, View } from 'react-native';
import { createBottomTabNavigator, createAppContainer } from 'react-navigation';
import TextScreen from '../screens/Text';

class TextTab extends React.Component {
  render() {
    return (
      <TextScreen />
    );
  }
}

class PhotoTab extends React.Component {
  render() {
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text>Settings!</Text>
      </View>
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
  Text: TextTab,
  Photo: PhotoTab,
  Audio: AudioTab,
  URL: URLTab,
});

export const AppContainer = createAppContainer(TabNavigator);
