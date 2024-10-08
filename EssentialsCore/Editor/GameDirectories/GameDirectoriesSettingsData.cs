using System;
using UnityEngine;

namespace Essentials.Internal.GameDirectories
{
    [Serializable]
    public class GameDirectoriesSettingsData
    {
        public string className = "DirectoriesList";
        public string classLocation = "Assets";

        [TextArea]
        public string gameDirectoriesData = "{}";
    }

    [Serializable]
    public class GameDirectoryData
    {
        public string path;
        public string reference;

        public GameDirectoryData(string path, string reference)
        {
            this.path = path;
            this.reference = reference;
        }
    }
}