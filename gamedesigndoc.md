---
layout: page
title: Game Design Document
---

## Authors

- [Justin Hoang](mailto:justinhoang@mines.edu)
- [James Vongphasouk](mailto:jvongphasouk@mines.edu)

<!-- 
  Silent Hill 2 Design Document
  https://drive.google.com/file/d/1nxvdXasP-HsRCt62cHK3wF_pIrJpYx5T/view  
-->

## Concept

Player will glide through the mountains and land successfully in daredevil
style! Paralander was strongly influenced by the paragliders around Lookout
Mountain. We hope to capture not only the sense of elation and adrenaline from
gliding through the mountain tops, but also the beauty of the surrounding
nature.

The main attraction for Paralander is its quick arcade style and realistic and
interactive physics and flight. We are planning on developing the game in 3D
using the Unity game engine.

## Core Gameplay

### Flow

Paralander is an arcade styled game, so there isn't a story (at least right now)
that needs to be explored. The player will load in, read some instructions about
how to play, then immediately begin free-falling.

The player will eventually land in two ways: safely or not safely. The win
condition depends on the game-mode that was selected. In the classic game, the
goal is to land as gently and elegantly as possible; in a reversed game-mode, to
goal is to land but to cause as much damage as possible to the player model.
Players will be awarded points accordingly and given a rating. There will be
multiple goals that the player can land at. Riskier locations will award the
player more points.

![Landing Locations]({{ '/assets/img/concept_art.png' | relative_url }})

A stretch goal for the project is to give the player freedom to change the
material composition and shape of the wing. Different materials and
constructions would have different prices. This crafting feature would give the
player the freedom and flexibility to test out different builds.

### Controls

In Paralander, the player will control an interactive third-person camera using
their mouse. The player will be able to pan around to see the whole environment,
as well as the player model and the paraglider itself.

Paralander will use the classic `wasd` scheme to control movements such as
dipping forward and back and leaning left and right. The whole time, the player
will be affected by gravity and be gliding along the air. It is the player's
responsibility to move in such a way to land at the goals. Remember, the landing
should delicate enough that the player does not break their legs (or anything
else) on impact.

At this stage (sprint 1, 2-14-24), we still have more research to do in order to
simulate realistic movement. As important as realism is to this game, we still
want to balance the fun-factor and interactivity for the player.

## Art

![Cover Art]({{ '/assets/img/cover_art.png' | relative_url }})
