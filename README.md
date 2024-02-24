# Survival Strategy Game

This is a small Unity game inspired by the Frontpunk strategy game.

## Game Idea

The idea is to create a survival strategy, where NPC's can build buildings, gather materials and food and water, improve on politics system and do whatever is neccessary to survive.

### Survive the cold

The main idea is for NPC to survive this cold apocalyptic world by gathering recources in order to stay healthy, fed and to generate heat and build a larger city.
NPC should react to longer exposures of cold in yet undetermined way (possibly by jsut getting sick or lowering their effectivity at work or even refusing to work in general)
One building that player should be able to build is some sort of heat generator (big inspiration in Fronstpunk) wherever is needed, though this building should be expensive.

### Building a city

Map is rather large and the main goal of a player should be to build a city as large as possible that will make it easier to generate heat. Though, larger city will make it harder to get enough food
and keep everyone happy as the politics system will need to be managed in order to keep some order in it. Larger city is much more exposed to crime like stealing, sickness spreading etc.... Also
materials may start to be rarer and rarer, which is why technologies has to be discovered or/and developed to gather materials effectivaly enough or to find other sources of it.

### Technologies

Player should be able to discover new things and to improve current system of heating, building, resource gathering and exploration. Technologies should be expensive so player will have to choose
carefully what to develop and research and what not.

### Politics

Player should be able to decide what NPC are allowed and not allowed to do. Politics should impact how the population behaves and reacts to ceratin events and orders

I am also considering implementing mechanics such as Exploration, Enemy atacks and how the population still grows. All of the above is up for discussion though.

## How to contribute

1. Clone the repository, most of what you need will be downloaded, though ofc as Github has a 100MB (or so) file size gap
2. Download unity manage [here](https://unity.com/download).
3. You will need a Unity v. 2022.3.5f1 or higher (probably better if you just get this one as I am too lazy to keep track of asset store packages compatibilities).
4. Thx to the Github gap (and due to some packages actually not being open source), you will have to install them one by one - list is provided further in the file.
5. Generally it does not matter which IDE you use, Microsoft's Visual Studio (no, not code, just Visual Studio) seems to be the best match, though other IDE's from Jet Brains or Monodevelop are afaik also very good and provide good support.
6. Then just press play and you are ready to go (it everything works as it supposed to, if not, just let me know and we will make it work!)

## What to work on

Ohh there is much to do, it is really very much in the beginning. Probably better if you contact me on discord (gannyk1) and we can brainstrom some ideas. As of know, following basics are created that can be improved on:

1. Basic Camera behavior
2. Small part of NPC behavior
3. Basics of Buildings behaviors (like mining rock)
4. Bit of UI

Structure of the code is very easy to understand, as I am not from a game industry, I have no clue whatsover ever what are the best practices in the matter, so as C# allows only one class to be inhertied from, that is exactly how the sctructure is done. So if you see a folder called Interactble, you are likely to find other folders in there which are inheriting from this Interactable base class. Other basic Managers like GameManager or UiManager ca be found in the Global folder.

## List of Packages

Here is a list of packages that have to be donwloaded:

- [Man NPC](https://assetstore.unity.com/packages/3d/characters/humanoids/humans/beard-man-in-jeans-and-shirt-221725#content)
- [Woman Npc](https://assetstore.unity.com/packages/3d/characters/humanoids/humans/woman-with-cap-and-jacket-221114)
- [GUI Borders, Sections, Buttons and Tabs](https://assetstore.unity.com/packages/2d/gui/icons/gui-parts-159068)
- [GUI Icons Pack](https://assetstore.unity.com/packages/2d/gui/icons/modern-rpg-free-icons-pack-264706)
- [Rocks Prefabs](https://assetstore.unity.com/packages/3d/props/exterior/rock-and-boulders-2-6947)
- [Buildings and other objects](https://assetstore.unity.com/packages/3d/environments/industrial/rpg-fps-game-assets-for-pc-mobile-industrial-set-v2-0-86679#content)
- [Snow FX](https://assetstore.unity.com/packages/vfx/fx-snow-240358#content)
- [Buildings](https://assetstore.unity.com/packages/3d/environments/urban/uk-terraced-houses-pack-free-63481)
- [Buildings](https://assetstore.unity.com/packages/3d/props/exterior/urban-building-130318)
- [Snow FX, Textures, Meshes, Audio](https://assetstore.unity.com/packages/3d/environments/landscapes/winter-zone-mini-107583)
