using Data;
using Factory;
using PersistentProgress;
using SaveLoad;
using Units;

namespace Infrastructure
{
    public class LoadLevel
    {
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly UnitSaveLoadManager _unitSaveLoadManager;
        
        public LoadLevel(IGameFactory gameFactory, IPersistentProgressService progressService,ISaveLoadService saveLoadService,UnitSaveLoadManager unitSaveLoadManager)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _unitSaveLoadManager = unitSaveLoadManager;
            LoadProgressOrInitNew();
            _gameFactory.CleanUp();
        }

        public void InformProgressReader()
        {
            foreach (ISaveLoadProgress saveProgressReader in _unitSaveLoadManager.SaveLoad)
            {
                saveProgressReader.LoadProgress(_progressService.WorldProgress);
            }
        }

        public void LoadProgressOrInitNew()
        {
            _progressService.WorldProgress = _saveLoadService.LoadProgress() ?? new WorldProgress();
        }
    }
}