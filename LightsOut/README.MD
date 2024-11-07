# Lights Out
This is an implementation of the game "Lights Out" in built with Windows Forms.

## Overview

Lights Out is a digital game released in 1995 by Tiger Electronics. The original design featured a 5 by 5 grid of lights. When the game starts the lights are randomly toggled on or off. Pressing any light will toggle its state and its neighbors state (On => Off, Off => On). The objective is turn off all of the lights with as few clicks as possible.

## Game Play
![GamePlay](GithubFiles/GamePlay.gif)
## Development

## Debug Options

### Solver

### Level Generation

Levels are stored in .json format With Level number, Level size (3 for a 3x3 board), Minimum moves, which would be the least number of moves used to beat the level, and a array of integers called board, this is used for the initial condition (0 is Off and 1 is On).
```json
{
    "Level": 1,
    "Size": 3,
    "MinMoves": 2,
    "Board": [ 0, 1, 0, 0, 1, 0, 0, 0, 1 ]
}
```

This data is read from disk and deserialized into an c# struct.
```cs
public struct LevelData
{
    public int Level;
    public int Size;
    public int MinMoves;
    public int[] Board = [];
}
```
Some additional functionality is added to the struct by way of properties and methods.
```cs
// For easily displaying the level on the UI
public readonly string Name => $"Level {Level}"; //=> Level 1

// To keep the board view and data in sync
public readonly void UpdateBoard(Light[] lights)
{
    foreach (var light in lights)
    {
        Board[light.index] = (int)light.State;
    }
}
```
All levels are stored an a larger json object.

```json
{
	"Levels": [
		{
			"Level": 1,
			"Size": 3,
			"MinMoves": 2,
			"Board": [ 0, 1, 0, 0, 1, 0, 0, 0, 1 ]
		},
		{
			"Level": 2,
			"Size": 3,
			"MinMoves": 3,
			"Board": [ 0, 1, 0, 1, 1, 0, 1, 1, 1 ]
		},
		{
			"Level": 3,
			"Size": 3,
			"MinMoves": 3,
			"Board": [ 1, 0, 1, 1, 1, 1, 1, 0, 1 ]
		},
        ...
```
Which is held in a simple struct, AllLevels. Which just has an array of LevelData.
```cs
public struct AllLevels
{
    public LevelData[] Levels;

    public AllLevels()
    {
        Levels = [];
    }
}
```

And extension method helps load the data.
```cs
public static AllLevels LoadLevels(this AllLevels levels)
{
    string jsonString;
    using (var streamReader = new StreamReader(FileUtil.GetLevelFile("Levels.json")))
    {
        jsonString = streamReader.ReadToEnd();
    }
    return JsonConvert.DeserializeObject<AllLevels>(jsonString);
}
```

Used like:
```cs
// cbxLevelSelect is a dropdown box that shows all loaded levels by name. 
// Each level can be selected and then loaded by the index of the level selected in the combo box.
// A new LevelData struct is created.
levelData = new LevelData(levels.Levels[cbxLevelSelect.SelectedIndex]);
```
### Level Saving