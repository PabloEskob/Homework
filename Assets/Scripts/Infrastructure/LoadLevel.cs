using System.Threading.Tasks;
using Data;
using Factory;
using Other;
using Repository;
using SaveLoad;
using Units;
using UnityEngine;

namespace Infrastructure
{
    public class LoadLevel
    {
        private readonly UnitFactory _unitFactory;
        private readonly ResourcesFactory _resourcesFactory;
        private readonly SaveLoadManager _saveLoadManager;
        private readonly GameRepository _gameRepository;
        private readonly SaveLoadUnit _saveLoadUnit;
        private readonly SaveLoadResources _saveLoadResources;

        public LoadLevel(UnitFactory unitFactory, GameRepository gameRepository,
            SaveLoadManager saveLoadManager, SaveLoadUnit saveLoadUnit,SaveLoadResources saveLoadResources,ResourcesFactory resourcesFactory)
        {
            _unitFactory = unitFactory;
            _saveLoadManager = saveLoadManager;
            _gameRepository = gameRepository;
            _saveLoadUnit = saveLoadUnit;
            _saveLoadResources = saveLoadResources;
            _resourcesFactory = resourcesFactory;
            _unitFactory.CleanUp();
        }

        public void InformProgressReader()
        {
            _saveLoadManager.Load();
        }

        public void Save()
        {
            _saveLoadManager.Save();
        }

        public void CreateLoadedUnit()
        {
            _gameRepository.LoadState();
            
            UnitData unitData = _saveLoadUnit.GetProgress(_gameRepository);
            
            if (unitData!=null)
            {
                foreach (SaveUnitData saveUnitData in unitData.SaveDataList)
                {
                    Task<UnitObject> unitTask = _unitFactory.Create((UnitTypeId)saveUnitData.TypeId,
                        saveUnitData.Position.AsUnityVector(),
                        saveUnitData.Rotation.AsUnityQuaternion());

                    unitTask.ContinueWith(task =>
                    {
                        UnitObject unit = task.Result;
                        unit.Id = saveUnitData.Id;
                        _saveLoadManager.Load();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }
        public void CreateLoadResources()
        {
            ResourcesData resourcesData = _saveLoadResources.GetProgress(_gameRepository);

            if (resourcesData!=null)
            {
                foreach (SaveResourcesData saveResources in resourcesData.SaveDataList)
                {
                    Task<ResourceObject> unitTask = _resourcesFactory.Create((ResourceType)saveResources.TypeId,
                        saveResources.Position.AsUnityVector(),
                        saveResources.Rotation.AsUnityQuaternion());

                    unitTask.ContinueWith(task =>
                    {
                        ResourceObject unit = task.Result;
                        unit.Id = saveResources.Id;
                        _saveLoadManager.Load();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }
    }
}