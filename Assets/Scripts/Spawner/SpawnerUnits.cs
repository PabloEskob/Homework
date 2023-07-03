using System;
using Factory;
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
            _gameFactory.CreateUnit(_unit, _position);
        }
    }
}