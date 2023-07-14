using System.Threading.Tasks;
using Factory;
using Other;
using Sirenix.OdinInspector;
using Units;
using UnityEngine;
using VContainer;

namespace Spawner
{
    public class SpawnerUnits : MonoBehaviour
    {
        [SerializeField] private UnitTypeId _unit;
        [SerializeField] private Transform _position;

        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        [Button]
        public void Spawn()
        {
            Task<UnitObject> unitTask = _gameFactory.CreateUnit(_unit, _position.position, Quaternion.identity);
            
            unitTask.ContinueWith(task =>
            {
                UnitObject unit = task.Result;
                unit.GenerateId();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}