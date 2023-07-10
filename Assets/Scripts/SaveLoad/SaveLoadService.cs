using System.IO;
using Data;
using PersistentProgress;
using SaveLoad;
using Units;
using UnityEngine;

namespace Infrastructure
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly UnitSaveLoadManager _unitSaveLoadManager;

        public SaveLoadService(IPersistentProgressService progressService, UnitSaveLoadManager unitSaveLoadManager)
        {
            _progressService = progressService;
            _unitSaveLoadManager = unitSaveLoadManager;
        }

        public void SaveProgress(SavePaths savePaths)
        {
            string path = Path.Combine(Application.streamingAssetsPath, $"{savePaths.ToString()}.json");

            foreach (ISaveLoadProgress saveProgress in _unitSaveLoadManager.ListSaveLoad)
            {
                saveProgress.UpdateProgress(_progressService.WorldProgress);
                File.WriteAllText(path, _progressService.WorldProgress.ToJson());
            }
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