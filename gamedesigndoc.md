---
layout: page
title: Game Design Document
---

![Cover Art]({{ '/assets/img/new_cover_art.png' | relative_url }})

> Escape to RNG Terrain

All work Copyright ©2024 by James Vongphasouk and Justin Hoang

Written by James Vongphasouk and Justin Hoang

Version 1

Sunday, April 26, 2024

## Table of Contents

- [Table of Contents](#table-of-contents)
- [Authors](#authors)
- [1. Executive Summary](#1-executive-summary)
  - [1.1 Game Concept](#11-game-concept)
  - [1.2 Genre](#12-genre)
  - [1.3 Target Audience](#13-target-audience)
- [2. Gameplay](#2-gameplay)
  - [2.1 Objectives](#21-objectives)
  - [2.2 In-game GUI](#22-in-game-gui)
- [3. Mechanics](#3-mechanics)
  - [3.1 Controls](#31-controls)
  - [3.2 Physics](#32-physics)
  - [3.3 Level Design](#33-level-design)
- [4. Assets](#4-assets)
  - [4.1 Music](#41-music)
  - [4.2 Sound effects and 3D Models](#42-sound-effects-and-3d-models)
  - [4.3 Terrain Generation](#43-terrain-generation)
- [5. Art](#5-art)
- [6. Product Backlog](#6-product-backlog)

## Authors

- [Justin Hoang](mailto:justinhoang@mines.edu)
- [James Vongphasouk](mailto:jvongphasouk@mines.edu)

## 1. Executive Summary

### 1.1 Game Concept

~~Player will glide through the mountains and land successfully in daredevil
style! Paralander was strongly influenced by the paragliders around Lookout
Mountain. We hope to capture not only the sense of elation and adrenaline from
gliding through the mountain tops, but also the beauty of the surrounding
nature.~~

~~The main attraction for Paralander is its quick arcade style and realistic and
interactive physics and flight. We are planning on developing the game in 3D
using the Unity game engine.~~

The player will take-off from a zone outside the procedurally generated terrain
and soar through the mountains. The player will have to maneuver a plane using
pitch, roll, and yaw steering and pick up food near the ground. The player will
also have to be careful not to hit the ground or its game over!

### 1.2 Genre

Arcade style flight simulator

### 1.3 Target Audience

The target audience used to be people who enjoyed realistic mountain scenery and
daring adventures. Now, I would say it is people who want a relaxing flight
simulator to escape the real world and occasionally pick up 3D bakery foods near
the ground for points.

## 2. Gameplay

### 2.1 Objectives

~~Paralander is an arcade styled game, so there isn't a story (at least right
now) that needs to be explored. The player will load in, read some instructions
about how to play, then immediately begin free-falling.~~

~~The player will eventually land in two ways: safely or not safely. The win
condition depends on the game-mode that was selected. In the classic game, the
goal is to land as gently and elegantly as possible; in a reversed game-mode, to
goal is to land but to cause as much damage as possible to the player model.
Players will be awarded points accordingly and given a rating. There will be
multiple goals that the player can land at. Riskier locations will award the
player more points.~~

<!-- ~~![Landing Locations]({{ '/assets/img/concept_art.png' | relative_url }})~~ -->

~~A stretch goal for the project is to give the player freedom to change the
material composition and shape of the wing. Different materials and
constructions would have different prices. This crafting feature would give the
player the freedom and flexibility to test out different builds.~~

There is only one character, the plane, and 3 kinds of 3D food models: donut,
cake, waffle. The plane is the controllable character and the plane picks up the
food by running into it.

### 2.2 In-game GUI

![Landing Locations]({{ '/assets/img/in_game_gui.png' | relative_url }})

The player will be able to see 6 things on their screen at all times listed here
from top left corner to bottom right corner. These are the frames per second
(FPS), score (increases by 50 every time a food target is collected), throttle
(stored as a percentage between 0 and 100), airspeed in km/h, altitude, and a
minimap which shows the player’s location as a neon green square and food
objects as stars.

## 3. Mechanics

### 3.1 Controls

~~In Paralander, the player will control an interactive third-person camera
using their mouse. The player will be able to pan around to see the whole
environment, as well as the player model and the paraglider itself.~~

~~Paralander will use the classic `wasd` scheme to control movements such as
dipping forward and back and leaning left and right. The whole time, the player
will be affected by gravity and be gliding along the air. It is the player's
responsibility to move in such a way to land at the goals. Remember, the landing
should delicate enough that the player does not break their legs (or anything
else) on impact.~~

~~At this stage (sprint 1, 2-14-24), we still have more research to do in order
to simulate realistic movement. As important as realism is to this game, we
still want to balance the fun-factor and interactivity for the player.~~

```text
SPACE => ACCELERATE

L-SHIFT => DECELERATE

A/D: YAW

W/S: PITCH

_optional_ mouse: YAW AND PITCH

Q/E: ROLL

PRESS ESCAPE TO SEE THE CONTROLS AGAIN
```

### 3.2 Physics

The plane operates realistically (to an extent) relying on initial lift force to
get off the ground, throttle force from when the player presses space/L-shift to
speed up/slow down the plane, etc. We planned on including realistic wind forces
too, but it was scrapped due to time constraints.

### 3.3 Level Design

Each level is procedurally generated by the `MeshGenerator` script. The logic is
credited in the Terrain Generation section of Assets

## 4. Assets

### 4.1 Music

None in this final version, but we planned on having the user be able to cycle
through a radio station during gameplay. It would include flying themed songs
like Airplanes - B.o.B, Big Jet Plane - Angus and Julia Stone, Space Oddity -
David Bowie, etc.

### 4.2 Sound effects and 3D Models

We used one sound effect, DM-CGS-45, for when the airplane crashes into terrain
from Dustyroom Casual Game Sound - One Shot SFX Pack located
[here](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116).

We also used plane model from Aztec Games located [here](
https://assetstore.unity.com/packages/tools/physics/plane-controller-glider-270737)
and some of bakery models from Layer Lab located
[here](https://assetstore.unity.com/packages/3d/props/food/3d-props-bakery-object-17167).

### 4.3 Terrain Generation

We borrowed the code from this [GitHub
page](https://github.com/Pang/ProceduralTerrainScripts/tree/main), and watched
the accompanying tutorials from [Pang
Dev](https://www.youtube.com/@pangdev7327).

## 5. Art

<!-- ~~![Cover Art]({{ '/assets/img/cover_art.png' | relative_url }})~~ -->

![Cover Art]({{ '/assets/img/new_cover_art.png' | relative_url }})

## 6. Product Backlog

[Product Backlog](https://github.com/users/suasuasuasuasua/projects/4/views/3)
