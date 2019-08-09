# A Very Real Looper
A custom musical interface developed for the HTC Vive. The Very Real Looper lets you place virtual sounds onto physical objects and perform music—without a headset. Click [here](https://vimeo.com/347904695) for a video of the Looper in action.

## Table of Contents
* [Introduction](#introduction)
* [Getting Started](#getting-started)
	* [Prerequisites](#prerequisites)
	* [Unity](#unity)
	* [TouchDesigner](#touchdesigner)
	* [Ableton Live](#abletonlive)
* [Acknowledgements](#acknowledgements)

## Introduction

![](https://github.com/raulaltosaar/a-very-real-looper/blob/master/looper-diagram.jpg)

The Looper uses three pieces of software: Unity, TouchDesigner, and Ableton Live. 

Unity handles input from the HTC Vive via SteamVR. It also houses triggers in the form of 3D models. Unity's physics engine is used to detect collisions between the Vive controllers and these triggers. 

Using [Open Sound Control](http://opensoundcontrol.org/introduction-osc) (OSC), this collision information is sent to TouchDesigner alongside live controller position data. TouchDesigner helps tune the incoming data from Unity and communicates seamlessly with Ableton Live via the [TDAbleton package](https://docs.derivative.ca/TDAbleton). If you haven't heard of [TouchDesigner](https://www.derivative.ca/) before, it's an awesome visual coding platform particularly designed for real-time projects. 

Our sound resides in Ableton Live in the form of samples, MIDI clips, and effects—all of which are controlled by OSC messages received from TouchDesigner. 

## Getting Started

Getting the Looper up and running involves installing some software and paying close attention to version numbers.

### Prerequisites

- The SteamVR runtime must be installed and running when using the Looper. This can be downloaded from Steam or by clicking [here](https://store.steampowered.com/app/250820/SteamVR/).
- Unity **version 2018.2.7** must be installed. This can be downloaded from the [Unity version archive](https://unity3d.com/get-unity/download/archive) (click Unity 2018.x and scroll down until you see the right version). Other versions of Unity will not work properly because the Looper utilizes a now-deprecated version of the [SteamVR Unity plugin](https://github.com/ValveSoftware/steamvr_unity_plugin).
- TouchDesigner must be installed and can be downloaded from [here](https://www.derivative.ca/099/Downloads/).
- Ableton Live must be installed. If you don't own Ableton you can get a free 30-day trial [here](https://www.ableton.com/en/trial/). You can probably use an expired version of the trial to test the Looper out—you just can't save or export anything.
- The [ASIO4ALL universal audio driver](http://www.asio4all.org/) isn't necessary but is recommended for achieving lower gestural input -> audio output latencies.

## Unity

Navigate to the Unity/Assets/Scenes folder in this repo and open the AVRL.unity file. This is where the magic begins. Check out the scene hierarchy to get a basic sense of what is going on. Inside the **[CameraRig]** GameObject, Controller (left)/(right) contain all of the VR controller interaction scripts (also accessible via ./Assets/Scripts). Inside the **Trigger** GameObject we have all of our 3D models that act like triggers and have corresponding scripts attached to them. These triggers are broken up into:

- **OneShots** that trigger samples in Ableton. These can't be looped.
- **NotesAndEffects** that trigger specific MIDI notes in Ableton and enable VR controller position data to control audio effects affecting those MIDI notes. These can be looped.
- **Textures** that trigger ambient samples in Ableton. These can be looped. 
- **ClipsAndeffects** that trigger MIDI clips in Ableton. These can be looped.

The Looper is essentially played in Unity with the HTC Vive controllers. Interaction is relatively straightforward:

- Hit a trigger with your controller to play a sound. Haptic feedback will fire while you are inside the trigger (haptic feedback is what makes the Looper playable without a headset).
- While inside of a trigger, press the **[Menu](https://www.vive.com/us/support/vive/category_howto/about-the-controllers.html)** button on your controller to loop the sound that is currently playing (if it can be looped).
- To end the loop, put your controller back inside the currently looping trigger and press the Menu button again. 
- To move a trigger into a new position in real-world space, hold the **[Grip](https://www.vive.com/us/support/vive/category_howto/about-the-controllers.html)** button, move the controller into a trigger, and then hold the **[Trigger](https://www.vive.com/us/support/vive/category_howto/about-the-controllers.html)** button. You have now grabbed the 3D audio trigger and can move it wherever you want. To drop the trigger into its new location, release your grip on the Trigger button, pull the controller out of the trigger, and finally release the Grip button.

## TODO

- Master the AVRL Ableton set properly, by getting mastered version of "Gradex" ableton set off of hard drive and replicating the settings.

```
Give examples
```

### Installing

A step by step series of examples that tell you how to get a development env running

Say what the step will be

```
Give the example
```

And repeat

```
until finished
```

End with an example of getting some data out of the system or using it for a little demo

## Running the tests

Explain how to run the automated tests for this system

### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc