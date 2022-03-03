# APPROACH

Total time in development : (to be calculated)

![Moebius the G.O.A.T](WIP/lalala.jpg)

---
## Session 001
### 240 mins
Done
- Made a tiny, messy, not-fun-to-play mvp

V1:
![001](WIP/001.gif)
I didn't really like this movement, and the format won't really fit the art that I'm envisioning.

V2:
![002](WIP/002.gif)
A top down view with a free-roaming player will work much better I think, and a joystick suits that better than buttons. The world will be as if looking through a microscope, so I think a bit of float on the character controller will be good.

V3:
![003](WIP/003.gif)
Added hazards

V4:
![004](WIP/004.gif)
Added collectibles and a timer

V5:
![005](WIP/005.gif)
Added the core mechanic besides movement: transfer of energy. Touching and holding a hazard will move 'mana' from the player to the hazard, until it becomes friendly. If the player runs out of mana, it dies.

V6:
![006](WIP/006.gif)
Added moving hazards with various mana needs and drops. Converting hazards to friendlies will make more mana available to the player, and allow progress through the levels.

---

## Session 002
### 85 mins

TO DO
- video/gif pipeline (windows capture - blender - screentogif?)

DONE 
- Started a Trello board to organise production and marketing https://trello.com/b/LU8EUwUU/tardigradeofmana
- Video + GIF pipeline, just ScreenToGif for both!
- Added gifs and notes to session 001 above.

---

## Session 003
### 35 mins

TODO
- untrack mp4s
- round placeholder art (concave + convex)

DONE
- untrack mp4s
- round placeholder art (concave + convex)
- Make and untrack a Production folder for working files

---

## Session 004
### 30 mins

TODO
- Triangle placeholders
- Refactor
    - Delete unused scripts
    - Encapsulate data
    - Make GameManager accessible to all
    - Remove unused joystick assets + scripts

DONE
- Triangle placeholder art
- Removed unused joystick assets + scripts
- Deleted unused scripts and scenes

---

## Session 005
### 125 mins

TODO:
- Make ring placeholder sprites
- Encapsulate data
- Make GameManager accessible to all

DONE
- Make ring placeholder sprites
- Getter and setters for GameManager variables
- Removed getters and setters, overcomplicating
- Set up simple hazard
- Set up mana collectible
- Tried to push to phone, failed
- Reimported joystick pack and put files back where they were
- Pushed to phone

![007](WIP/007.gif)

---

## Session 006
### 70 mins

TODO
- Add agent to scene
- Refactor mana receiver
- Refactor mana giver

DONE
- Add agent to scene
- Make agent mana text
- Set hazard damage and agent manaMax
- Added a delay of a second when winning
- Added multitouch back to joystick script
- Pushed to phone

![008](WIP/008.gif)

---

## Session 007
### 60 mins

TODO
- README
- Make camera prefab

DONE
- Camera prefab
- Described idea in readme

---

## Session 008
### 30 mins

TODO
- User stories
- Tech stack notes
- Demo level design documents

DONE
- User stories
- Tech stack notes
- Noted the general beats for tutorial/demo level

---

## Session 009
### 35 mins

TODO
- Sketch demo map and annotate

DONE
- Sketched some scene layouts, focusing on introducing mechanics

## Session 010
### 30 mins

TODO
- Finish sketching demo level scenes
- Start building demo scenes

DONE
- Simple layout sketched

![p1](WIP/DemoSketchp1.jpg)

![p2](WIP/DemoSketchp2.jpg)

- Started a scene with a drawn wall

## Session 011
### 75 mins

TODO
- Add door collider and script to fade and load

DONE
- Add door object and collider
- Add script to load scene
- add fade animations
- made gamemanager a singleton so scripts can access it without a reference
- door triggers fadeout

![009](WIP/009.gif)

---

## Session 012
### 50 mins

TODO
- Swap to singleton access instead of manager refs
- Refactor
- Make second demo scene

DONE
- Read about events, decided to stick with singleton
- Moved some logic from Door and Player to GameManager
- Made second scene

![010](WIP/010.gif)

---

## Session 013
### 60 mins

TODO
- Make scene 3

DONE
- Draw map
- Added doors
- Add spinner hazards with animation
- Changed which scene dead scene loads
- Built to phone, fade animations not working
- Tried changing colour, no change
- Made a test raw image, shows
- Raw image with animator not working
- Remade gobo object with rawimage and animator, working on device
- Fixed animations and stopped being raycast target

![011](WIP/011.gif)

---

## Session 014
### 110 minutes

TODO
- Persist game manager as proper singleton created in any level
- make gamemanager find levelmanager (non-persistent)

DONE
- Made gamemanager a proper persistent singleton
- Added a LevelManager to each scene
- gamemanager finds levelmanager if one in scene, using a listener on scenemanager
- made levelmanager static, point doors to that instead of gamemanager
- commented out gamemanager logic for finding levelManager, incase needed for later
- made level 3 finish load win screen

---

## Session 015
### 90 mins

TODO
- Make dead reload current scene
- Make scenes reload at correct door

DONE
- Moved some logic from game to level managers
- Dead loads scene died on
- Added spawn points array to level manager
- Added spawn from string array to level manager
- Set player to spawn at door from previous level
- Snap camera at scene start
- Snap camera not working on level 2
- Snap camera not working at all on android
- Moved camera snap call to levelmanager, works

---

## Session 016
### 65 mins

TODO
- Reload at correct spawnpoint if died
- Persist player state
- Add take damage animation to player

DONE
- Spawn point persists if died
- Damage animation
- Player mana written to playerprefs at level exit and loaded on level enter
- Bug

---

## Session 017
### 80 mins

TODO
- Hunt the bug
- Level 4

DONE
- Bug was saying there was no text object but there was. Removed and readded and it works again
- Player pref not working on device
- Installed logcat package to track log
- Log show mana is being written to
- Level 3 only shows correct mana
- Some scenes had multiple payler scripts for an unknown reason 
- Joystick not working on level 2
- Joystick wasn't set in editor
- Reset player mana at level 1

---

## Session 018
### 65 mins

TODO
- Level 4
    - Draw map
    - Make scene
    - Add fountain
    - Add NPC (guide)
    - Add dialogue system

DONE
- Level 4 map
- Scene connected to others
- Added fountain with emitter that shoots collectible particles in random direction
- Particles have their state set by fountain
- Particles self destruct

![012](WIP/012.gif)

---

## Session 019
### 50 mins

TODO
- Add NPC (guide)
- Add dialogue system

DONE
- Added a TMPro ui element that is written to at start
- Added typewriter effect
- Added box image behind text

![013](WIP/013.gif)

---

## Session 020
### 145 mins

TODO
- Dialogue from characters

DONE
- Added a scriptableobject for dialogue which can be created from the menu, and a datadialogue folder
- Dialogues are scrolled through and then the dialoguebox is closed
- Dialogues are scrolled through when tapped on instead of with spacebar
- Made a dialogue trigger area
- Made collectibles only collectible by player
- Player triggers dialogue
- Stopped dialogue box retriggering if active
- Fountain working on phone but dialogue getting not set to reference error
- Dialogue worked for a minute then stopped
- Doors on level 4 not working anymore
- Assigned references in editor rather than using getcomponent, works on phone too
- Changed canvas scaler options

![014](WIP/014.gif)

---

## Session 021
### 30 mins

TODO
- Player flash when receiving mana
- Add guide npc to revive on level 4

DONE
- Made a healed animation
- Made a Healed method on player that updates mana and triggers animation
- Drawn a new map for level 4

---

## Session 022
### 60 mins

TODO
- Add guide npc to revive
- Add barrier
- Hide life counter until finding first fountain

DONE
- NPC guide receives mana
- guide location has dialogue
- added barrier
- added a wall to remove after guide is helped
- added dialogue conditions script with method overloading for player/int

---

## Session 023
### 160 mins

TODO
- Add story beat switch statement with level specifics
- Turn dialogue trigger off after reviving guide
- Turn barrier off after reviving guide
- Have guide follow player after being revived
- Hide mana counter until finding first fountain
- Stop player receving mana if at max

DONE
- Removed dialogue conditionals
- Made a currentStoryBeat int on levelmanager
- dialoguetrigger refers to currentStoryBeat when choosing dialogue to display
- Made a storyBeatTrigger script to put on relevant object
- Switch statement on storyBeatTrigger that takes the current scene name
- nested switch statement for each scene that takes currentStoryBeat
- realised storytrigger has too many conditions, changing to individual scripts for each scene and beat

---

## Session 024
### 80 mins

TODO
- Insert events and listeners to progress story beats
    - Player gets max health
    - Guide gets max health
    - Last guide dialogue finished
- Persist story state between levels


DONE
- Collectibles not collected if player is at max mana
- Event and listener added for when player is at max
- Dialogue closes if player leaves trigger
- Calling dialogue box resets it before displaying
- Player mana text resets properly
- Story beat saved to prefs per level
- half a second wait after typewriter effect finishes
- Reset story state at awake
- sped up stypewriter
- end of dialogue triggers event

![015](WIP/015.gif)

---

## Session 24
### 60 mins

TODO
- Persist story state between levels
- Have guide follow player after being revived
- Turn barrier off after reviving guide

DONE
- Made a transform orbiting the player
- Set orbiter animation layer weight
- Realigned fountain emitter
- Levelmanager story beat enables guide
- Guide moves towards orbiter
- Guide moves smoothly to orbiter


![016](WIP/016.gif)

---

## Session 25
###  60 mins

TODO
- Refactor

DONE
- Modelling the classes for refactor

![classes](WIP/mana.drawio.png)

---

## Session 026
### 35 mins

TODO
- Test current build on phone
- Continue modelling the classes and control flow
- Persist story state between levels
- Turn barrier off after reviving guide

DONE
- found Guide moves very slowly on android
- Guide speed in android matches editor
- found index array error for dialogue
- removed unnecessary argument in dialogue method
- added a try catch block for dialogue triggering

---

## Session 027
### 55 mins

TODO
- Implement level events interface on individual scripts per level
- Continue modelling the classes and control flow
- Persist story state between levels
- Turn barrier off after reviving guide

DONE
- Continue modelling the classes and control flow

![classes](WIP/classModelling_02.drawio.png)

---

## Session 028
### 120 mins

TODO
- Refactor mana
- Create an agent class for mana holders to inherit from and have methods triggered by mana changes

DONE
- Created a mana script with properly accessed variables
- Agent class inheriting from monobehaviour
- playeragent class inheriting from agent
- mana component looks for agent component on object
- mana component throws exception if no agent component found
- agent component looks for mana component on object
- agent component throws exception if no agent component found
- playeragent calls base start method before it's own
- player agent gets animator component, throws exception if it can't find one
- playeragent triggers heal/damage animations


---

## Session 29
### 85 mins

TODO

- Merge the mana and mana agent classes, inherit agents from it
- Continue modelling the classes and control flow
- Persist story state between levels
- Turn barrier off after reviving guide

DONE

- Continue modelling the classes

![classes](WIP/classModelling_03.drawio.png)

- Merge the mana and mana agent classes, inherit agents from it
- Collectibles work with player agent
- Hazards work with player agent
- Made manual getters and setters for mana
- manual getter for max mana (auto get/set was returning wrong value)
- protected methods

---

## Session 030
### 75 mins

TODO
- Refactor the mana exchange mechanic
- Continue modelling the classes and control flow

DONE
- Refactored mana exchange mechanic using manaagents
- Edited demo level and level manager script to test refactor so far on android
- Single test level works as expected on android

---

## Session 031
##  100 mins

TODO
- UI and canvas fades
- Move dialogue behaviour to canvas manager
- Level manager story event announcements

DONE
- Canvas triggers it's own fade in on each level so far
- Level manager triggers canves fade out
- Move dialogue behaviour to canvas manager
- Dialogue trigger references canvas instead of level manager
- reordered mana logic to make player display correct mana
- edited player animations
- reset unity as player running slow, fine now
- clean level manager script
- level manager has five story events that can have targets assigned in the editor


---

## Session 032
### 120 mins

TODO
- Persist game + player + guide + story state between levels using scriptable objects
- Place player at correct spawn point
- Place guide at player
- Turn barrier off after reviving guide

DONE
- GameData scriptable object with previous and current level parameters
- gameData not showing values in inspector, only in debug console, don't know how to fix this
- player moves itself to spawnpoints 
- win level resets game state (prev and current levels)
- cleaned scene heirarchies and set spawn points
- Player moves cam to it's spawn point
- Tested on android

---

## Session 033
### 70 mins

TODO
- Persist player state between levels using scriptable objects
- Player state (mana and max mana) persist across levels
- rewind player state to last load if died

DONE
- player state object written to at level close
- player state and game state reset at game start
- fixed game manager singleton logic
- player state doesn't save when dying
- tested on android
- Placed gamemanager prefab in each level so far

---

## Session 034
###  65 mins

TODO
- Canvas prefab
- Guide agent script inheriting from mana agent
- Persist guide + story state between levels using scriptable objects
- Place guide at player (spawn on load level if following)
- Turn barrier off after reviving guide

DONE
- Fade out trigger on canvas manager
- Canvas prefab on each scene so far
- Remodelling classes

![classes](WIP/classModelling_04.drawio.png)

- Guide friend component which inherits from Friend class

---

## Session 035
### 50 mins

TODO
- Persist guide + story state between levels using scriptable objects
- Place guide at player
- Player spawns guide if has guide is true
- Turn barrier off after reviving guide
- Bounce player away from hazard when damaged

DONE
- Guide friend component is set to follow player when npc agent component at max mana
- Player data has a hasguide bool
- Player references guide prefab
- Player spawns guide at start if not already set to reference one in scene

---

## Session 036
### 90 mins

TODO
- Player spawns guide if has guide is true
- Persist story state between levels using scriptable objects and events
- Turn barrier off after reviving guide
- Bounce player away from hazard when damaged

DONE
- Guide spawns if there isn't one and player can
- Mana agents have an event to announce when they hit max mana, recipients set in editor
- Player agent has public methods to change has guide state
- Resetting player state sets has guide to false
- Guide sets sprite when becomes friend
- Set guide sprite default sprite and renderer
- Player at max mana on demo_004 updates levelmanager to story beat 1
- Guide doesn't trigger on touch for some reason
- Manaagent triggers moved from editor events to script
- Guide only triggers if istrigger bool is changed during runtime?!
- Guide sometimes triggers after changing levels
- Very confused, can't find the bug, have reset editor, no change

---

## Session 037
### 55 mins

TODO
- Solve npc trigger bug 

DONE
- Placed new guide prefab in different level, works
- Made a hazard in a different level, registers touch
- Placed NPC prefab in other level, works
- Moved guide on demo_004 out of dialogue trigger, works now
- Made a dialoguetrigger layer and assigned dialogue trigger to it
- Told 2d physics raycaster on camera prefab to ignore dialoguetrigger layer
- Guide can be pressed again, thank goodness that was tricky
- Guide can be pressed through joystick, bug
- Touches are reading as one even with no finger or mouse on screen (need to check on android)
- Canvas text showing current touch length
- Android has 0 touches default. will just have to ignore in editor
- Changed npc touches to accept any number if joystick isn't being used, or at least two if jostick is being used
- Works as expected on android

---

## Session 038
### 135 mins

TODO
- Trigger dialogue after reviving guide
- Guide(s) adds to max mana


DONE
- Player at max mana triggers updates level manager 
- Guide at max mana triggers Level manager triggers dialogue
- Player data objects have a number of guides state
- Guide number state on player increases when reviving guide
- Player spawns as many guides as is set in state data
- Levelstate string list which hold a list of guides to collect
- level state saves which guides collected
- gamemanager resets levelstate
- realised don't need an array of guides to collect, will only be max one per level. Will need an array of mana agents though
- changed guide collected state to single bool
- added agenttoconvert arrays to level manager and level state objects
- Guides are spawned at max mana

---

## Session 039
### 210 mins

TODO
- Persist story (agentsConverted and dialogue events) state between levels using scriptable objects and events
- Guide(s) adds to max mana
- Bounce player away from hazard when damaged
- Change guide follow behaviour to approach and stop instead of orbit
- Game state checks if continuing or new game
- fix dialogue event

DONE
- Dialogue event fixed in level_004
- Dialogue finishing progresses story beat
- Improved story beat progression logic to catch skipping
- Max mana increases with each guide collected
- Level state (guides) not saving properly
- Didn't change anything and they did work properly?!
- Added ranodmness to guide location when following
- Multiple guides spawn and follow properly
- Game state not saving properly

---

## Session 040
### 240 mins

TODO
- Fix game state save and load, only works sometimes
- Game state checks if continuing or new game
- Bounce player away from hazard when damaged

DONE
- Added a listener to scene unload in gamemanager
- Gamemanager keeps strack of current and previous levels properly
- Levelstate objects are being changed somewhere I can't see
- Gamemanager doesn't track levels properly  
- Fixed level tracking, rogue semicolon after an if parameter and before block
- Tried deleting state data files and remaking, still doesn't work
- Apparently scriptable objects don't save their data when they aren't serialized, so when their reference goes, the state goes
- Gave the levelstateobjects to the gamemanager to hold so they are persisted, it works!
- Testing on android, it works!
- Updated dialogue to give better instruction

![017](WIP/017.gif)

---

## Session 040
### 30 mins

TODO
- Bounce player away from hazard when damaged
- Level remembers hazard to friend

DONE
- Hazard conversion triggers next story beat
- New empty classes for friends/hazard

---

## Session 041
### 160 mins

TODO
- Bounce player away from hazard when damaged
- Level remembers hazard to friend in list

DONE
- Level remembers and sets which hazards are converted
- Hazard collider sends vector to player movement which uses it to bounce away
- Hazard was converted, not working on android anymore, working in editor
- Getcomponent not working in Start on android
- Setting component in editor works
- Setting up levels needs a lot of settings, might be worth checking and throwing errors to help

![018](WIP/018.gif)

---

## Session 042
### 50 mins

TODO
- Inherit from hazard class
- Add receiving/giving visual cues
- Throw errors on level setups
- Rebuild levels

DONE
- Inherit from hazard class
- Not sure inheritance and so many class types is necessary, started remodelling classes based on prefabs of components