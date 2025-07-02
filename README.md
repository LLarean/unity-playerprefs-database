# ![unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)  PlayerPrefs JSON Database

[![CodeFactor](https://www.codefactor.io/repository/github/llarean/unity-playerprefs-database/badge)](https://www.codefactor.io/repository/github/llarean/unity-playerprefs-database)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](https://github.com/llarean/unity-playerprefs-database/blob/master/LICENSE.md)
![stability-unstable](https://img.shields.io/badge/stability-unstable-red.svg)
[![Releases](https://img.shields.io/github/v/release/llarean/unity-playerprefs-database)](https://github.com/llarean/unity-playerprefs-database/releases)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://GitHub.com/Naereen/StrapDown.js/graphs/commit-activity)  

A simple, modular save system for Unity using PlayerPrefs + JSON.  
Save/load any serializable class with 2 lines of code. Supports collections (List/Dictionary) and error handling.  
Made for small games!  

A lightweight, flexible save system for Unity that uses PlayerPrefs and JSON serialization to store game data. Perfect for small to medium projects, it supports:
- Any serializable C# class (e.g., player stats, inventory, settings).
- Easy save/load with just one line of code.
- Runtime and Editor compatibility.  


### Example:

```csharp
// Save data
GenericSaveManager.Save("player", new PlayerData(...));

// Load data
PlayerData data = GenericSaveManager.Load<PlayerData>("player");
```

### Features:  
- No external dependencies  
- Handles lists, dictionaries, and custom classes  
- Minimal setup required  

### Limitations:

- Not for large datasets  
- Data is not encrypted  

### Ideal for:

- Prototypes
- Mobile games
- Player preferences and progress