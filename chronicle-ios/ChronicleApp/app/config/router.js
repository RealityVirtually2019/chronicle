import React from 'react';
import { createBottomTabNavigator, createStackNavigator, createAppContainer } from 'react-navigation';
import TextScreen from '../screens/Text';
import PhotoScreen from '../screens/Photo';
import PolyScreen from '../screens/Poly';
import MusicScreen from '../screens/Music';
import { Image } from 'react-native';

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

class PolyTab extends React.Component {
  render() {
    return (
      <PolyScreen {...this.props}/>
    );
  }
}

class MusicTab extends React.Component {
  render() {
    return (
      <MusicScreen {...this.props}/>
    );
  }
}

const TabNavigator = createBottomTabNavigator({
  Text: {
    screen: (props) => <TextTab {...props.screenProps}/>,
    navigationOptions: {
      tabBarIcon: ({tintColor}) =>
        <Image source={require('../static/text-icon.png')} style={{width: 26, height: 26, tintColor: tintColor}}/>
    }
  },
  Photo: {
    screen: (props) => <PhotoTab {...props.screenProps}/>,
    navigationOptions: {
      tabBarIcon: ({tintColor}) =>
        <Image source={require('../static/photo-icon.png')} style={{width: 26, height: 26, tintColor: tintColor}}/>
    }
  },
  Poly: {
    screen: (props) => <PolyTab {...props.screenProps}/>,
    navigationOptions: {
      tabBarIcon: ({tintColor}) =>
        <Image source={require('../static/poly-icon.png')} style={{width: 29, height: 29, tintColor: tintColor}}/>
    }
  },
  Music: {
    screen: (props) => <MusicTab {...props.screenProps}/>,
    navigationOptions: {
      tabBarIcon: ({tintColor}) =>
        <Image source={require('../static/music-icon.png')} style={{width: 25, height: 25, tintColor: tintColor}}/>
    }
  },
});

const StackNavigator = createStackNavigator({
  MainApp: {
    screen: TabNavigator,
    navigationOptions: {title: 'chr🌀nicle'}
  }
});

export const AppContainer = createAppContainer(StackNavigator);
