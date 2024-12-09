# Where Are My Neighbors?
<p align=center>
 <img src ="https://github.com/user-attachments/assets/9a3279a2-441e-4d5a-8040-24a20a8b57c7" width = 50%> 
</p>

<h3 align=center><b>Created by</b></h3> 
<p align=center>
<img src="https://github.com/user-attachments/assets/171a7d16-431f-4ff4-908d-933f94f32d30">
</p>
<p align=center>
Project Manager: David Yang </br>
Programming Lead: Austin Nguyen </br>
Programmers: Leah Hernandez, Zihao Yu, Matthew Maragos 
</p>


## Overview
Made with Unity, Where Are My Neighbors? is an endless 2D run-and-gun shooter inspired by the Super Nintendo Entertainment System title, Zombies Ate My Neighbors. 
The game has the player navigate through each level to find their neighbors while shooting through zombies. Once all the neighbors in a level have been obtained, a door will appear for the player to advance to the next level. As the level progression increases, the number of neighbors and zombies also increases. </br>

## How to Play
### Controls:
* Player Movement Controls:
  * Users use the **AWSD** keys to move the player character around the game
  * Users also use the **E** key to use a one-time-use item
  * Users also can alternate between one-time-use items with the keys: **1** and **2**
  * Users use the **mouse wheel** on their mouse to alernate between their weapons
* Aim:
  * Users use the mouse and its left-click button to point and shoot at the enemies on-screen.
* WebGL link:
  * [PLAY THE GAME!!!](https://ankhoa1212.github.io/comp159-2d-randomly-generated-shooter/)

## Propose to Complete
**Sprint 1 Stories with Complexity Score**</br>
Player Movement Script = **3**</br>
Layout Spawner (How the level is spawned)	= **13**</br>
Pick-up Item (Items are picked up accounted for)	= **8**</br>
Weapons (Rifle & Shotgun function) = **8**</br>
Enemy Controller (How enemies behave in game)	= **3**</br>
Free Aim (Player can shoot in 360 degree direction)	= **5**</br>
Adding Audio (weapon shooting & player injured)	= **5**</br>
Invincibility (Player temporarily is invincible for a short time) =	**8**</br>
Camera (Follows and keeps player in center)	=	**3**</br>
Total Sprint Story Complexity = 56</br>
**Total Sprint Story Completed Complexity Score = 56**</br>

**Sprint 2 Stories with Complexity Score**</br>
Different Weapon Pick-up = **8**</br>
Level Progression = **8**</br>
Game Over Screen = **3**</br>
Health Pack (Prefab gives health to injured Player) = **5**</br>
Health Pack & Consumables = **8**</br>
Health Scripts (track Player & Enemy health) = **8**</br>
Player Health Bar = **5**</br>
Weapon Box Panel (display current weapon) = **8**</br>
Main Menu & Controls Scene	= **3**</br>
Total Sprint Story Complexity = 56</br>
**Total Sprint Story Completed Complexity Score = 40**</br>

**Sprint 3 Stories with Complexity Score**</br>
Ammo Box = **5**</br>
Guarantee ammo drop when zombie is killed	= **13**</br>
One-Time-Use: Landmine	= **21**</br>
One-Time-Use: Distraction Item	= **13**</br>
One-Time-Use: Portable Barricade	= **8**</br>
Display Number of Neighbors to Save	= **5**</br>
Mini-Map (displays where player has traveled & neighbors)	= **13**</br>
Background Music & Sound Effects	= **5**</br>
Ammo Countdown (Tracks available ammunition)	= **13**</br>
Sprites (for player, enemies, ammo, etc)	= **5**</br>
Total Complexity = 101</br>
**Total Completed for Sprint = 73 as of 06 DEC 2023**</br>

## Features

<p align=center><b>Weapon Switching</b></p>
<p align=center>!
<img src="https://github.com/user-attachments/assets/c31e8383-01c0-48d9-b79b-666658252130" width = 20%>
<img src="https://github.com/user-attachments/assets/cccd083e-ebcc-4f82-ad15-9f50d0edfba5" width = 20%>
</p>
<p align=center>
 Image above showcases the ability for players to alternate between their weapons
</p>

<p align=center><b>Guaranteed Ammo Drop</b></p>
<p align=center>
<img src="https://github.com/user-attachments/assets/8529f6be-dd3a-480e-be33-50ffe2b5059f" width = 20%>
<img src="https://github.com/user-attachments/assets/864009fb-841c-48e6-a56c-de0de251cfb0" width = 20%>
</p>
<p align=center>
 Image above showcases destroying an zombie with a specific weapon, yields ammunition of weapon type that destroyed the zombie
</p>

<p align=center><b>Level Progression</b></p>
<p align=center>
<img src="https://github.com/user-attachments/assets/5420dce8-793f-4d8f-8553-242dd0fe052e" width = 20%>
<img src="https://github.com/user-attachments/assets/858eebae-2c57-4703-9a5b-f0d45beec486" width = 20%>
</p>
<p align=center>
 Image above showcases the collection of the final neighbor to save instantiates a door to advance to the next level.
</p>

<p align=center><b>Mini-Map</b></p>
<p align=center>
<img src="https://github.com/user-attachments/assets/a33a2559-c33d-40ae-9065-7e8060eea58d" width = 30%>
<img src="https://github.com/user-attachments/assets/9848c866-d542-44ab-991a-784a2e10a586" width = 30%>
<img src="https://github.com/user-attachments/assets/4a837484-aa25-470d-bc64-ac3375ff1f1d" width = 30%>
</p>
<p align=center>
 Image above showcases the mini-map that displays building the player has yet to enter and updates it, along with where neighbors are within buildings.
</p>

## Words of Wisdom
David: “*Sketch a visual design of the game prior to even writing a line of code. The visual provides a reference to build code towards the visual and make changes when necessary.*”

Zihao: “*Figure out the logic before writing a line of code specially if you are working with a member on your team, otherwise would cause problem if you have different idea or ways to do it.*”

Austin: “*Communication is important to make sure that everyone on the team is able to contribute effectively.*”

Leah: “*At one point some of the tasks had some layover so it was hard to not redo some of the code others had written.*”

Matthew: "*Getting used to GitHub is like learning to ride a bike – challenging at first, but with practice, it becomes second nature.*"

## References with Annotation
**Logo**:</br>
Logo was edited with GIMP and originally generated from [Looka](https://looka.com/editor/160530106)

**Audio Assets**:</br>
Shotgun audio was edited with Audacity and originally from [freesounds.org](https://freesound.org/people/JavierZumer/sounds/257234/)</br>
Rifle audio was edited with Audacity and originally from [freesounds.org](https://freesound.org/people/coolabc/sounds/569174/)</br>
Zombie audio was edited with Audacity and originally from [freesounds.org](https://freesound.org/people/alirabiei/sounds/491855/)</br>
Main menu music was edited with Audacity and originally from [freesounds.org](https://freesound.org/people/deadrobotmusic/sounds/570867/)</br>
Health Increase sound was edited with Audacity and originally from [here](https://www.sounds-resource.com/game_boy_advance/advancewars/sound/8850/)</br>
Landmine beeping audio was edited with Audacity and originally from [freesounds.org](https://freesound.org/people/PITCHEDsenses/sounds/488811/)</br>
Explosion audio was from [freesounds.org](https://freesound.org/people/derplayer/sounds/587190/)</br>
Player “Oof” sound was from [freesounds.org](https://freesound.org/people/fotoshop/sounds/47356/)</br>


**Sprites Assets**:</br>
Items & Weapons Sprite Sheet was edited with GIMP and originally from [here](https://www.spriters-resource.com/fullview/153551/)</br>
Landmine Sprite Sheet was edited with GIMP and originally from [here](https://www.spriters-resource.com/fullview/170478/)</br>
Rifle icon is originally from [iconfinder.com](https://www.iconfinder.com/icons/1743644/cartoon_gun_hunter_rifle_shotgun_war_weapon_icon)</br>
Shotgun icon was edited with GIMP and originally from [freepik.com](https://www.freepik.com/icon/shotgun_7445438)</br>
Exit Door is originally from [here](https://www.spriters-resource.com/fullview/32191/)</br>
Minimap background circle is originally from [bing.com](https://th.bing.com/th/id/R.30140326c79b99c92e5c2812bbc31090?rik=PVmQYeWjy6%2fNwg&riu=http%3a%2f%2fclipart-library.com%2fimages_k%2fshape-transparent%2fshape-transparent-7.png&ehk=HiPcLyXHhHF5IML5Y2YSheTlQ4gefHzBq94qYCd2VnU%3d&risl=&pid=ImgRaw&r=0)</br>
Explosion was taken from: COMP 159 2D Lab - Lab 3</br>
Keyboard image was edited with GIMP and taken from [here](https://t4.ftcdn.net/jpg/04/27/48/01/360_F_427480164_e44iMshBoPt2GTIuMhfvhxgNCcaFi9bC.jpg)</br>
Mouse image was edited with GIMP and taken from [here](https://static3.depositphotos.com/1000410/139/v/450/depositphotos_1390005-stock-illustration-computer-mouse.jpg)
