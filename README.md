# chronicle
Curate memory collages in the real world.

# Development
## chronicle-ios
iOS app built using React Native. Its main purpose is to emit mixed media (text, image, video, urls) to specific socket channels.

## chronicle-server
Handles all of the socket configuration and is hosted on the following heroku instance:
```
https://chronicle-client-server.herokuapp.com

# healthcheck
https://chronicle-client-server.herokuapp.com/ping
```

In order to push the server code to the heroku instance, use the following `git` command:

```
git push heroku `git subtree split --prefix chronicle-server master`:master --force
```

## chronicle-unity
Magic Leap app that listens to events from specific socket channels (i.e. data emitted by `chronicle-ios`). It allows the headset user to collage that media and tie to specific objects by scanning the real world.
