using System.Collections.Generic;
using Data;
using Factory;
using PersistentProgress;
using SaveLoad;
using VContainer;

namespace Infrastructure
{
    public class LoadLevel
    {
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IObjectResolver _objectResolver;

        public LoadLevel(IGameFactory gameFactory, IPersistentProgressService progressService,ISaveLoadService saveLoadService,IObjectResolver objectResolver)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _objectResolver = objectResolver;
            _gameFactory.CleanUp();
        }

        public void LoadProgressOrInitNew()
        {
            _progressService.WorldProgress = _saveLoadService.LoadProgress() ?? new WorldProgress();
        }

        private void InformProgressReader()
        {
            foreach (var saveProgressReader in _objectResolver.Resolve<IEnumerable<ISaveProgressReader>>())
            {
                saveProgressReader.LoadProgress(_progressService.WorldProgress);
            }
        }

        
    }
}