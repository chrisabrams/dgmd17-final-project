# Drone Race Course

## Setting up Unity

In Unity Hub, under the installs tab, add a new install: `2020.3.14f1`. This is the latest LTS at the time of this project creation, everything should support this version. You'll be asked which targets to install; you really only need the OS you are running (Windows support for Windows, etc).

## Loading the Project

There are two main projects you can load: `Skybound Final` and `Drone Race Course`. 

`Drone Race Course` contains our first attempt at making a drone simulation through a Python UDP connection. Once you clone the project, simply go to the Unity Hub and click on Add Project, locate the `Drone Race Course` folder, and load it in. If you see nothing inside of Unity, you may need to go the the Scenes folder and load `SampleScene`.

`Skybound Final` can be loaded in the same way, however make sure that you have loaded the `Simulation` Scene. This represents our final product, with three different race courses, ray-casting on the drone for object detection, and many configurable parameters before runtime.

### Coding

If you don't have Visual Studio or Visual Studio Code, I recommend installing one of those as Unity makes it quite easy to link code snippets between the Visual Studio programs and Unity (you can edit the files in the Visual Studio programs and Unity will update in real-time, no need to re-compile).

## Project Resources

- [Paper / Report](https://docs.google.com/document/d/11JtSV4KBW5OCLFkRRMnZL66Bg5gOwMjH_syZ4cxcdXM/edit?usp=sharing)
- [Presentation Slides](https://docs.google.com/presentation/d/1gmr0C-JXrMalLmwPT8HH0lXfkOh1Kh9VBx0AU_PdyCM/edit?usp=sharing)
- [Video](https://www.youtube.com/watch?v=Ccjmokj2yxM)
