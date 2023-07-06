using System.Collections.Generic;
using Data;
using PersistentProgress;
using SaveLoad;
using UnityEngine;
using VContainer;

namespace Infrastructure
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IPersistentProgressService _progressService;

        public SaveLoadService(IObjectResolver objectResolver,IPersistentProgressService progressService)
        {
            _objectResolver = objectResolver;
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            foreach (ISaveProgress saveProgress in _objectResolver.Resolve<IEnumerable<ISaveProgress>>())
            {
                Debug.Log(saveProgress);
                saveProgress.UpdateProgress(_progressService.WorldProgress);
                PlayerPrefs.SetString("Progress",_progressService.WorldProgress.ToJson());
            }
        }

        public WorldProgress LoadProgress()
        {
            WorldProgress toDeserialized = PlayerPrefs.GetString("Progress")?.ToDeserialized<WorldProgress>();
            return toDeserialized;
        }
    }
}