# A Very Real Looper
A custom musical interface developed for the HTC Vive. The Very Real Looper lets you place virtual sounds onto physical objects and perform music—without a headset. Click [here](https://vimeo.com/347904695) for a video of the Looper in action
.r
## Table of Contents
* [Introduction](#introduction)
* [Getting Started](#getting-started)
	* [Prerequisites](#prerequisites)
	* [Unity](#unity)
	* [TouchDesigner](#touchdesigner)
	* [Ableton Live](#abletonlive)
* [Acknowledgements](#acknowledgements)

## Introduction

The Looper uses three pieces of software: Unity, TouchDesigner, and Ableton Live. 

Unity handles input from the HTC Vive via SteamVR. It also houses triggers in the form of 3D models. Unity's physics engine is used to detect collisions between the Vive controllers and these triggers. 

Using [Open Sound Control](http://opensoundcontrol.org/introduction-osc) (OSC), this collision information is sent to TouchDesigner alongside live controller position data. TouchDesigner helps tune the incoming data from Unity and communicates seamlessly with Ableton Live via the [TDAbleton package](https://docs.derivative.ca/TDAbleton). If you haven't heard of [TouchDesigner](https://www.derivative.ca/) before, it's an awesome visual coding platform particularly designed for real-time projects. 

Our sound resides in Ableton Live in the form of samples, MIDI clips, and effects—all of which are controlled by OSC messages received from TouchDesigner. 

## Getting Started



### Prerequisites

What things you need to install the software and how to install them

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