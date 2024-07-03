# Unity Essentials
A package for the Unity game engine that brings a few features I found handy during game development.

## Key Features
There are various features that focus on different aspects on the game engine. Managing game folders, easy way to create sounds in-game with code, handy editor tools and more.

### Game Directories
Game Directories helps you manage and visualize persistent game folders.
A simple editor window that handles all the necessary boilerplate code for creating persistent game folders, so you don't have to touch any code.
<img width="606" alt="image" src="https://github.com/NotRewd/Unity-Essentials/assets/48103943/fa82757c-09b3-4a09-955f-e0aceccf1936">

### Game Sounds
<p>Game Sounds allows you to create game audio during runtime using only a few lines of code. No more messing around with a bunch of audio sources.</p>

```cs
using Essentials.Core.GameSounds;
using UnityEngine;

public class PlayASound : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private void Start() => GameSounds.PlaySound(_audioClip);
}
```

### PlayerPrefs Editor
Ever wanted to see your PlayerPrefs or change them through an editor? Well now you can.
<img width="608" alt="image" src="https://github.com/NotRewd/Unity-Essentials/assets/48103943/e24d1de9-c434-42aa-a511-414eebc8ace6">

Check out the [documentation](https://github.com/NotRewd/Unity-Essentials/wiki) to see more.
