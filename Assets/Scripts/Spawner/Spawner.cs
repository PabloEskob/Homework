using System.Threading.Tasks;
using Factory;
using Other;
using Sirenix.OdinInspector;
using Units;
using UnityEngine;
using VContainer;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private UnitTypeId _unit;
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private Transform _position;

        private UnitFactory _gameFactory;
        private ResourcesFactory _resourcesFactory;

        [Inject]
        private void Construct(UnitFactory gameFactory,ResourcesFactory resourcesFactory)
        {
            _resourcesFactory = resourcesFactory;
            _gameFactory = gameFactory;
        }

        [Button]
        public void SpawnUnit()
        {
            Task<UnitObject> unitTask = _gameFactory.Create(_unit, _position.position, Quaternion.identity);
            
            unitTask.ContinueWith(task =>
            {
                UnitObject unit = task.Result;
                unit.GenerateId();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        
        [Button]
        public void SpawnResources()
        {
            Task<ResourceObject> unitTask = _resourcesFactory.Create(_resourceType, _position.position, Quaternion.identity);
            
            unitTask.ContinueWith(task =>
            {
                ResourceObject resource = task.Result;
                resource.GenerateId();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}