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

        public void SaveProgress()
        {
            foreach (ISaveLoadProgress saveProgress in _unitSaveLoadManager.SaveLoad)
            {
                saveProgress.UpdateProgress(_progressService.WorldProgress);
                PlayerPrefs.SetString("Progress", _progressService.WorldProgress.ToJson());
                PlayerPrefs.Save();
                Debug.Log("save!");
            }
        }

        public WorldProgress LoadProgress()
        {
            WorldProgress toDeserialized = PlayerPrefs.GetString("Progress")?.ToDeserialized<WorldProgress>();
            Debug.Log(toDeserialized.WorldData.Position.Z);
            return toDeserialized;
        }
    }
}