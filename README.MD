# Lights Out
This is an implementation of the game "Lights Out" in built with Windows Forms.

## Installation and Requirements:
 * Clone the repo:

 ```bash
git clone https://github.com/GlassToeStudio/OOP-Final-Project-Lights-Out.git
 ```
#### Requirements:
 * Windows 10.X +
 * VS 2022
 * .NET8
 * Package: Newtonsoft.Json
    - Two options:
        - Tools/NuGet Package Manager/Package Manager Console/
            ```bash
                dotnet restore 
            ```
        - Tools/NuGet Package Manager/Manage NuGet Packages for Solution
            * Search: `newtonsoft.json` and install.


# Overview

Lights Out is a digital game released in 1995 by Tiger Electronics. The original design featured a 5 by 5 grid of lights. When the game starts the lights are randomly toggled on or off. Pressing any light will toggle its state and its neighbors state (On => Off, Off => On). The objective is turn off all of the lights with as few clicks as possible.


![GamePlay](GithubFiles/GamePlay.gif)


## Development

Levels are stored in .json format With Level number, Level size (3 for a 3x3 board), Minimum moves, which would be the least number of moves used to beat the level, BestScore to keep a record of the least moves used to beat the level, Stars (int) and StarsText (string) which are used to display up to three stars on the UI, 3 is the best 0 is the worst, a Name field used to display level name on the UI, and a array of integers called board, this is used for the initial condition (0 is Off and 1 is On).


```json
{
    "Level": 1,
    "Size": 3,
    "MinMoves": 2,
    "BestScore": 9000,
    "Stars": 0,
    "Board": [
    0,
    1,
    0,
    0,
    1,
    0,
    0,
    0,
    1
    ],
    "Name": "Level 1",
    "StarText": "☆☆☆"
}
```

This data is read from disk and deserialized into an c# struct.

```cs
public struct LevelData
{
    /// <summary>Return "Level {level}" Ex: "Level 1".</summary>
    public readonly string Name => $"Level {Level}";
    /// <summary>The number of this level. Ex: Level 1.</summary>
    public int Level;
    /// <summary>Size of board Ex: Size = 4 => 4x4 board.</summary>
    public int Size;
    /// <summary>Minimum moves required to complete the level.</summary>
    public int MinMoves;
    /// <summary>The minimum number of moves used to beat this level. 9000 to begin.</summary>
    public int BestScore = 9000;
    /// <summary>The number of Stars earned for this level. 0 to begin.</summary>
    public int Stars = 0;
    /// <summary>Integer array representing a data model of the Board.</summary>
    public int[] Board = [];
```


Some additional functionality is added to the struct by way of properties and methods.


```cs
/// <summary>
/// Update Board data to match the View data. 
/// </summary>
/// <param name="lights">Array of Lights that is the interactive View.</param>
public readonly void UpdateBoard(Light[] lights)
{
    foreach (var light in lights)
    {
        Board[light.Index] = (int)light.State;
    }
}

/// <summary>
/// Get a UI friendly string of stars based on number of stars earned for this level.
/// Ex: Stars = 2, StarText = "★★☆"
/// </summary>
public readonly string StarText =>

    this.Stars switch
    {
        0 => "☆☆☆",
        1 => "★☆☆",
        2 => "★★☆",
        3 => "★★★",
        _ => "☆☆☆",
    };
```

All inital levels are stored an a larger json object.


```json
{
  "Levels": [
    {
      "Level": 1,
      "Size": 3,
      "MinMoves": 2,
      "BestScore": 9000,
      "Stars": 0,
      "Board": [
        0,
        1,
        0,
        0,
        1,
        0,
        0,
        0,
        1
      ],
      "Name": "Level 1",
      "StarText": "☆☆☆"
    },
    {
      "Level": 2,
      "Size": 3,
      "MinMoves": 3,
      "BestScore": 9000,
      "Stars": 0,
      "Board": [
        0,
        1,
        0,
        1,
        1,
        0,
        1,
        1,
        1
      ],
      "Name": "Level 2",
      "StarText": "☆☆☆"
    }
}
```

Which is held in a simple struct, LevelDatabase. LevelDatabase has a List of LevelData and a index accessor.

```cs
    /// <summary>
    /// Container for all pre-made levels in a List of <see cref="LevelData"/>. Implements <see cref="IDatabase"/>.
    /// <para>The  <see cref="LevelDatabase"/> holds data for each pre-made Level in the game.
    /// The data is loaded at startup and new levels are initialized with their respective
    /// <see cref="LevelData"/> objects information.</para>
    /// </summary>
    public struct LevelDatabase : IDatabase
    {
        /// <summary>
        /// List of all pre-made <see cref="LevelData"/>. Levels are initialized with this data.
        /// </summary>
        public List<LevelData> Levels { get; set; }

        /// <inheritdoc/>
        public readonly LevelData this[int index] => Levels[index];

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelDatabase"/> struct.
        /// </summary>
        public LevelDatabase() => Levels = [];
    }
}
```

This data is loaded from disk when the game starts and all Levels are based off this initial state.


And extension method helps load the data.

```cs
public static class DatabaseExtensions
{
    /// <summary>
    /// Load game data from disk for this LevelDatabase Object.
    /// </summary>
    /// <param name="gameDb">this level <see cref="LevelDatabase"/></param>
    /// <returns></returns>
    public static LevelDatabase LoadLevelDatabase(this LevelDatabase gameDb)
    {
        return gameDb.LoadDatabase<LevelDatabase>("Game.json");
    }

    ...

    /// <summary>
    /// Load database from disk.
    /// </summary>
    /// <typeparam name="T">LevelDatabase or UserDatabase.</typeparam>
    /// <param name="db">this database</param>
    /// <param name="databaseName">database name in .json format: User.json or Game.json.</param>
    /// <returns>this Database populated with data from disk.</returns>
    private static T LoadDatabase<T>(this T db, string databaseName)
    {
        string jsonString;
        using (var streamReader = new StreamReader(FileUtil.GetDatabase(databaseName)))
        {
            jsonString = streamReader.ReadToEnd();
        }
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
}
```

Used like:

```cs
private LevelDatabase game = new LevelDatabase().LoadLevelDatabase();
```

### Level Saving

User data is managed in a similar way. A UserDatabase struct holds the data like the LevelDatabase struct, but with some extra functionality for updating and adding data.

```cs
    /// <summary>
    /// Database for holding user save data for each level and general game play. Implements <see cref="IDatabase"/>.
    /// The data is loaded at startup. Completed levels are added and updated for user records.
    /// /// </summary>
    public struct UserDatabase : IDatabase
    {
        /// <summary>
        /// List of <see cref="LevelData"/>. Holds users save data for each level.
        /// </summary>
        public List<LevelData> Levels { get; set; }
        /// <summary>
        /// The index of the current selected level in the  <see cref="IDatabase"/>.
        /// </summary>
        public int SelectedIndex { get; set; } = 0;
        /// <summary>
        /// The maximum index selectable in the  <see cref="IDatabase"/>. Indicates highest unlocked level.
        /// </summary>
        public int MaxIndex { get; set; } = 0;
        /// <summary>
        /// The current selected level.
        /// </summary>
        public readonly LevelData CurrentLevel => Levels[SelectedIndex];
        /// <inheritdoc/>
        public readonly LevelData this[int index] => Levels[index];

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDatabase"/> struct.
        /// </summary>
        public UserDatabase() => Levels = [];

        /// <summary>
        /// Add a level to the database. When a level is first cleared, the level at the next index is added to this Levels list.
        /// </summary>
        /// <param name="levelData"></param>
        public readonly void AddLevel(LevelData levelData)
        {
            Levels.Add(levelData);
        }

        /// <summary>
        /// Update the <see cref="LevelData"/> object for the level loaded at the <see cref="SelectedIndex"/> with new data.
        /// </summary>
        /// <param name="levelData">Updated <see cref="LevelData"/> to overwrite the data at the current levels index.</param>
        public readonly void UpdateLevel(LevelData levelData)
        {
            Levels[SelectedIndex] = levelData;
        }
    }
```

Its .json data is as follows. This is the initial state for a new user. One level is added to Levels and its at the initial state. Once played this data is updated and upon beating a level the next level is added to the list. The current level that is selected when the user closes the application is stored and is loaded back when the user plays again. 

```json
{
  "Levels": [
    {
      "Level": 1,
      "Size": 3,
      "MinMoves": 2,
      "BestScore": 9000,
      "Stars": 0,
      "Board": [
        0,
        1,
        0,
        0,
        1,
        0,
        0,
        0,
        1
      ],
      "Name": "Level 1",
      "StarText": "☆☆☆"
    }
  ],
  "SelectedIndex": 0,
  "MaxIndex": 0,
  "CurrentLevel": {
      "Level": 1,
      "Size": 3,
      "MinMoves": 2,
      "BestScore": 9000,
      "Stars": 0,
      "Board": [
        0,
        1,
        0,
        0,
        1,
        0,
        0,
        0,
        1
      ],
      "Name": "Level 1",
      "StarText": "☆☆☆"
    }
}
```

Like the LevelDatabase, the UserDatabase is loaded via an extension method:

```cs
    /// <summary>
    /// Load user data from disk for this UserDatabase Object.
    /// </summary>
    /// <param name="userDb">this <see cref="UserDatabase"/></param>
    /// <returns></returns>
    public static UserDatabase LoadUserDatabase(this UserDatabase userDb)
    {
        return userDb.LoadDatabase<UserDatabase>("User.json");
    }
```

Used like:

```cs
private UserDatabase user = new UserDatabase().LoadUserDatabase();

```

Both LevelDatabase and UserDatabase implement the interface IDatabase. IDatabase ensures each object has a list of LevelData and an indexer for the list.

```cs
    /// <summary>
    /// Provides List of <see cref="LevelData"/> objects and an indexer for accesing <see cref="LevelData"/> objects in List.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// List of <see cref="LevelData"/> objects containing preset data for each level in the game.
        /// </summary>
        public List<LevelData> Levels { get; set; }

        /// <summary>
        /// Get a <see cref="LevelData"/> object for a specific level by index from the <see cref="IDatabase"/> database.
        /// </summary>
        /// <param name="index"> Index of level in list. Ex: Level 1 index is 0</param>
        /// <returns>The <see cref="LevelData"/> at the selected index.</returns>
        public LevelData this[int index] => Levels[index];
    }
```

We pass the IDatabase object to a SaveDatabase method when saving user data to disk. This is mainly used for UserDatabase but can accept a LevelDatabase since they are both IDatabase objects.

```cs
    /// <summary>
    /// Save the given IDatabase object to disk. Saves to internal program resources directory.Saves to working project directory for development if DEBUG.
    /// <para>File extension ".json" is appended to file name so pass file anme without extension.</para>
    /// </summary>
    /// <param name="database">The database to serialize to disk. GameDatabase or UserDatabase.</param>
    /// <param name="databaseName">The name of the file that is written to disk, "Game" or"User"</param>
    private static void SaveDatabase(IDatabase database, string databaseName)
    {
        var data = JsonConvert.SerializeObject(database);
        // Write to internal directory
        File.WriteAllText(GetDatabase($"{databaseName}.json"), data);

        // Write to project directory to keep project and repo up to date with changes.
        File.WriteAllText($"{PROJECT_DIR}{databaseName}.json", data);
    }
```

All data is managed via a DataHandler object which loads all data from disk, maintains current level and performs any logic required to determine which LevelData is returned and how to update user data and save to disk.

```cs
/// <summary>
/// Class for handling game data. 
/// Loading data from disk,
/// Incrementing and decrement level,
/// Updating user progress,
/// Saving data to disk.
/// </summary>
public class DataHandler()
{
    /// Load UserDatabase and GameDatabase from disk.
    private UserDatabase user = new UserDatabase().LoadUserDatabase();
    private LevelDatabase game = new LevelDatabase().LoadLevelDatabase();
        
    ...

```

### Level Generation

There are 60 pre-made levels for this game. Twenty 3x3, twenty 4x4, and twenty 5x5. Some were manually created by choosing what 'light', index, should be zero and what would be one. Some were created with the random level generator. 

#### Manual

Manual Level data is generated by using the built game board and turning on/off lights at specific indices to create a pattern. This data is kept in the LevelData object and saved to disk as a .json. This allowed for a high level of control and ensured levels were solvable. Once could also generate unique patterns for cool looking levels. 

#### Random Generation

A level generator was also created to assist with level creation. The level generator uses the built-in pre-built game board and chooses, at random, which light (index) to turn, on. There is some level of control of a predetermined number of minimum moves required to solve a level and/or how many lights should start as on and off. 

```cs
        #region Generation
        private void GenerateRandomLevel()
        {
            moves = 0;
            int size = GetBoardSizeForRandomGen();
            GenerateGameBoardsAndSelect();
            Random rnd = new();
            int minMoves = -1;

            // numMinMoves is a NumericUpDown control where we have seleected a desired
            // value for minimum moves. Loop until we have a solution that equals our
            // desired value.
            while (minMoves != numMinMoves.Value)
            {
                foreach (var light in lights)
                {
                    light.TurnOff();
                }

                List<int> used = [];
                int iterations = rnd.Next(size * size + 1);
                for (int i = 0; i < iterations; i++)
                {
                    int randLight = rnd.Next(0, size * size);

                    // We do this so that we can only ever touch each light once.
                    while (used.Contains(randLight))
                    {
                        randLight = rnd.Next(0, size * size);
                    }
                    used.Add(randLight);

                    lights[randLight].ClickLight();
                }

                levelData = new LevelData(handler.Levels.Count, size, 0);
                levelData.UpdateBoard(lights);
                levelData.MinMoves = Solver.GetSolutionMatrix(levelData).Sum();
                lblLog.Text = DebugBoardState();

                // If we did not select a value for min moves, take the current solution.
                if (numMinMoves.Value == 0)
                {
                    break;
                }
            }

            btnSaveLevel.Enabled = true;
           
            txtFileName.Text = $"{levelData}_generated";
        }
```

### Solver

To assist with testing, a puzzle solver is programmed to solve the puzzle in as few moves as possible. The solver is also used with the manual and random level generation to calculate minimum moves to solve. 


### Debug Options