# ![unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)  PlayerPrefs JSON Database

[![CodeFactor](https://www.codefactor.io/repository/github/llarean/unity-playerprefs-database/badge)](https://www.codefactor.io/repository/github/llarean/unity-playerprefs-database)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](https://github.com/llarean/unity-playerprefs-database/blob/master/LICENSE.md)
![stability-unstable](https://img.shields.io/badge/stability-unstable-red.svg)
[![Releases](https://img.shields.io/github/v/release/llarean/unity-playerprefs-database)](https://github.com/llarean/unity-playerprefs-database/releases)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://GitHub.com/Naereen/StrapDown.js/graphs/commit-activity)

**PlayerPrefs JSON Database** is a lightweight and modular storage system for Unity based on PlayerPrefs and JSON.  
Save and load any serializable classes in 1-2 lines. Supports collections (List/Dictionary) and error handling.  
Perfect for small games and prototyping!

A lightweight, flexible save system for Unity that uses PlayerPrefs and JSON serialization to store game data. Perfect for small to medium projects, it supports:
- Any serializable C# class (e.g., player stats, inventory, settings).
- Easy save/load with just one line of code.
- Runtime and Editor compatibility.
- **Tested on Unity 2020+**

### Features:
- No external dependencies
- Handles lists, dictionaries, and custom classes
- Minimal setup required

### Limitations:

- Not for large datasets
- Data is not encrypted
- Unity’s JsonUtility does **not** support nested collections (например, `List<List<T>>` или `Dictionary<string, List<T>>`) и некоторые типы (например, `GameObject`, `Sprite`).

### Ideal for:

- Prototypes
- Mobile games
- Player preferences and progress

### INSTALLATION

There are 3 ways to install this plugin:

- import [PlayerPrefsDatabase.unitypackage](https://github.com/llarean/unity-playerprefs-database/releases) via *Assets-Import Package*
- clone/[download](https://github.com/llarean/unity-playerprefs-database/archive/master.zip) this repository and move the *Plugins* folder to your Unity project's *Assets* folder
- *(via Package Manager)* Select Add package from git URL from the add menu. A text box and an Add button appear. Enter a valid Git URL in the text box:
  - `"https://github.com/llarean/unity-playerprefs-database.git"`
- *(via Package Manager)* add the following line to *Packages/manifest.json*:
  - `"com.llarean.eventbus": "https://github.com/llarean/unity-playerprefs-database.git",`

### EXAMPLE CODE

1. Creating Serializable Classes

To save custom data in the database, create a `[Serializable]` class with your fields. Example:

```csharp
[Serializable]
public class PlayerProfile
{
    public string Username;
    public int Score;
}
```

2. Fill in the created classes

```csharp
PlayerProfile player = new PlayerProfile()
{
    Username = "Player1",
    Score = 100,
};
```

3. Saving Data to the Database

To persist your serializable class, pass it to the Database.Save() method with a unique key:

```csharp
Database.Save("player_profile", profile);
```

4. Loading Data from the Database

To retrieve saved data, call Database.Load<T>() with the same key used for saving.

```csharp
PlayerProfile loadedProfile = Database.Load<PlayerProfile>("player_profile");  

if (loadedProfile != null)  
{
    _inputField.text = loadedProfile.Message;  
    Debug.Log($"Loaded message: {loadedProfile.Message}");  
}
```

### Best Practices and Key Concepts

#### When to Save
Call `Save()` when:
- The player exits the game (`OnApplicationQuit()`)
- Important values change (e.g., currency updates)
- Manually triggered (e.g., save buttons)

#### Serializable Classes
- Add `[Serializable]` to your classes
- Required for JSON conversion in Unity

*Why `[Serializable]`?*  
Unity’s `JsonUtility` requires this attribute to serialize objects.

#### Supported Field Types
- Primitive types (`int`, `string`, `bool`)
- Arrays/Lists (`List<T>`, `T[]`)
- Dictionaries (`Dictionary<TKey, TValue>`)
- Other `[Serializable]` classes

*Avoid:*
- Unity-specific types (e.g., `GameObject`, `Sprite`)
- Non-serializable fields (`[NonSerialized]`)

#### Loading Data
- Always specify the type (`<PlayerProfile>`) when loading
- Check for `null` if the key might not exist

#### Key Management
- Use unique and descriptive keys (e.g., `"player_profile"`)
- Store keys as constants to avoid typos:

```csharp
public static class SaveKeys
{
    public const string Profile = "player_profile";
    public const string Settings = "game_settings";
}
Database.Save(SaveKeys.Profile, profile);
```