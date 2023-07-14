using System.IO;
using Data;
using PersistentProgress;
using SaveLoad;
using UnityEngine;

namespace Infrastructure
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly SaveLoadManager _saveLoadManager;

        public SaveLoadService(IPersistentProgressService progressService,SaveLoadManager saveLoadManager)
        {
            _progressService = progressService;
            _saveLoadManager = saveLoadManager;
        }
        
        public void SaveProgress(SavePaths savePaths)
        {
            string path = Path.Combine(Application.streamingAssetsPath, $"{savePaths.ToString()}.json");
            _saveLoadManager.Save(_progressService.WorldProgress);
            File.WriteAllText(path, _progressService.WorldProgress.ToJson());
        }

        public WorldProgress LoadProgress(SavePaths savePaths)
        {
            string path = Path.Combine(Application.streamingAssetsPath, $"{savePaths.ToString()}.json");

            if (File.Exists(path))
            {
                WorldProgress toDeserialized = DataExtensions.ToDeserialized<WorldProgress>(path);
                return toDeserialized;
            }

            return null;
        }
    }
}