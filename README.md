# A Very Real Looper
A custom musical interface developed for the HTC Vive. The Very Real Looper lets you place virtual sounds onto physical objects and perform music—without a headset.

Click [here](https://vimeo.com/347904695) for a video of the Looper in action.

## Table of Contents
* [Introduction](#introduction)
* [Getting Started](#getting-started)
	* [Prerequisites](#prerequisites)
	* [Unity](#unity)
		* [Scene Hierarchy](#scene-hierarchy)
		* [Interaction](#interaction)
	* [TouchDesigner](#touchdesigner)
	* [Ableton Live](#abletonlive)
* [Acknowledgements](#acknowledgements)
* [License](#license)

## Introduction

![:)](https://github.com/raulaltosaar/a-very-real-looper/blob/master/looper-diagram.jpg)

The Looper uses three pieces of software: Unity, TouchDesigner, and Ableton Live. 

Unity handles input from the HTC Vive via SteamVR. It also houses audio triggers in the form of 3D models which can be dragged and dropped onto real-world objects. Unity's physics engine is used to detect collisions between the Vive controllers and these triggers. 

Using [Open Sound Control](http://opensoundcontrol.org/introduction-osc) (OSC), this collision information is sent to TouchDesigner alongside live controller position data. TouchDesigner helps tune the incoming data from Unity and communicates seamlessly with Ableton Live via the [TDAbleton package](https://docs.derivative.ca/TDAbleton). If you haven't heard of [TouchDesigner](https://www.derivative.ca/) before, it's an awesome visual coding platform particularly designed for real-time projects. 

Our sound resides in Ableton Live in the form of samples, MIDI clips, and effects—all of which are controlled by OSC messages received from TouchDesigner. 

## Getting Started

Getting the Looper up and running involves installing some software. To play the Looper you must have Unity, TouchDesigner, and Ableton Live running at the same time.

## Prerequisites

- The SteamVR runtime must be installed and running when using the Looper. This can be downloaded from Steam or by clicking [here](https://store.steampowered.com/app/250820/SteamVR/).
- Unity **version 2018.2.7** must be installed. This can be downloaded from the [Unity version archive](https://unity3d.com/get-unity/download/archive) (click Unity 2018.x and scroll down until you see the right version). 
	- Other versions of Unity will not work properly because the Looper utilizes a now-deprecated (and much easier-to-use) version of the [SteamVR Unity plugin](https://github.com/ValveSoftware/steamvr_unity_plugin).
- TouchDesigner must be installed and can be downloaded from [here](https://www.derivative.ca/099/Downloads/). The TDAbleton package must also be installed and connected to Ableton Live using [these instructions](https://docs.derivative.ca/TDAbleton#Install_the_latest_TDAbleton_system).
- Ableton Live must be installed. If you don't own Ableton you can get a free 30-day trial [here](https://www.ableton.com/en/trial/). You can probably use an expired version of the trial to test the Looper out—you just can't save or export anything.
- The [ASIO4ALL universal audio driver](http://www.asio4all.org/) isn't necessary but is recommended for achieving lower gestural input -> audio output latencies.

## Unity

![:)](https://github.com/raulaltosaar/a-very-real-looper/blob/master/looper-triggers-unity.jpg)

### Scene Hierarchy

Navigate to the Unity/Assets/Scenes folder in this repo and open the AVRL.unity file. This is where the magic begins. Check out the scene hierarchy to get a sense of what is going on. Inside the **[CameraRig]** GameObject, Controller (left)/(right) contain all of the VR controller interaction scripts (also accessible via Unity/Assets/Scripts). Next in the scene hierarchy we have the **Triggers** GameObject that contains all of our 3D models which act like audio triggers. These triggers have corresponding interaction scripts and OSC addresses attached to them (using [UnityOSC](https://github.com/jorgegarcia/UnityOSC)). These triggers are broken up into:

- **OneShots** that trigger samples in Ableton. These can't be looped.
- **NotesAndEffects** that trigger specific MIDI notes in Ableton. These can be looped. Audio effects affecting these triggered notes can be controlled using position data from the VR controllers.
- **Textures** that trigger ambient samples in Ableton. These can be looped. 
- **ClipsAndEffects** that trigger MIDI clips in Ableton. These can be looped. Audio effects affecting these triggered clips can also be controlled using position data from the VR controllers.

### Interaction

The Looper is essentially played in Unity with the HTC Vive controllers. Interaction is relatively straightforward:

- Hit a trigger with your controller to play a sound. Haptic feedback will fire while you are inside the trigger (haptic feedback is what makes the Looper playable without a headset).
- While inside of a trigger, press the **[Menu](https://www.vive.com/us/support/vive/category_howto/about-the-controllers.html)** button on your controller to loop the sound that is currently playing (if it can be looped).
- To end the loop, put your controller back inside the currently looping trigger and press the Menu button again. 
- To move a trigger into a new position in real-world space, hold the **[Grip](https://www.vive.com/us/support/vive/category_howto/about-the-controllers.html)** button, move the controller into a trigger, and then hold the **[Trigger](https://www.vive.com/us/support/vive/category_howto/about-the-controllers.html)** button. You have now grabbed the 3D audio trigger and can move it wherever you want. To drop the trigger into its new location, release your grip on the Trigger button, pull the controller out of the trigger, and finally release the Grip button. 
	- OneShot triggers cannot be moved. 
	- The Grip button functions to mute the grabbed trigger while you are moving it into a new location.
- To control audio effects affecting Notes and Clips, simply hold your VR controller inside one of those triggers and move your other controller up and down in space.

## TouchDesigner

Open the AVRL.toe file located inside the TouchDesigner folder in this repo. TouchDesigner receives OSC messages from each audio trigger in Unity. These OSC messages are either discrete 0s or 1s (on or off) or continuous VR controller position data. [CHOP Execute DATs](https://docs.derivative.ca/CHOP_Execute_DAT) parse these discrete messages into specific MIDI note commands which are sent to Ableton. The Ableton Mapper OP receives and tunes the incoming VR controller position data and sends it to Mapper devices attached to specific Ableton tracks.

## Ableton Live

Open the AVRL.als file located inside the Ableton_Live/AVRL_Project folder in this repo. This set consists of a number of tracks with different instruments, clips, samples, and effects. These are all controlled using incoming messages from TouchDesigner.

## Acknowledgements

- Major thanks to Jorge Garcia Martin for developing [UnityOSC](https://github.com/jorgegarcia/UnityOSC), a set of OSC C# classes and an API which this project makes use of.
- An inspiring visit to [Dynamicland](https://dynamicland.org/) was the original catalyst for this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.


