using System.Threading.Tasks;
using Data;
using Factory;
using Other;
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

        public LoadLevel(IGameFactory gameFactory, IPersistentProgressService progressService,
            ISaveLoadService saveLoadService, UnitSaveLoadManager unitSaveLoadManager)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _unitSaveLoadManager = unitSaveLoadManager;
            _gameFactory.CleanUp();
            LoadProgressOrInitNew();
        }

        public void InformProgressReader()
        {
            foreach (ISaveLoadProgress saveProgressReader in _unitSaveLoadManager.ListSaveLoad)
            {
                saveProgressReader.LoadProgress(_progressService.WorldProgress);
            }
        }

        public void LoadProgressOrInitNew()
        {
            _progressService.WorldProgress =
                _saveLoadService.LoadProgress(SavePaths.InitialData) ?? new WorldProgress();
        }

        public void CreateLoadedUnit()
        {
            foreach (SaveUnitData saveUnitData in _progressService.WorldProgress.WorldData.SavedUnitData)
            {
                Task<UnitObject> unitTask = _gameFactory.CreateUnit((UnitTypeId)saveUnitData.UnitTypeId,
                    saveUnitData.Position.AsUnityVector(),
                    saveUnitData.Rotation.AsUnityQuaternion());
                
                unitTask.ContinueWith(task =>
                {
                    UnitObject unit = task.Result;
                    unit.Id = saveUnitData.UniqueId;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }
}