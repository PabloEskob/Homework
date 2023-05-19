using System.Collections.Generic;
using System.Linq;
using Game_v1.CodeBase.Factory;
using Game_v1.CodeBase.Services.ServiceLocator;
using UnityEngine;

namespace Game_v1.CodeBase.Logic
{
    public class EnemyPool
    {
        private readonly Transform _container;
        private GameObject _prefab;
        private List<GameObject> _pool;
        private readonly IGameFactory _gameFactory;

        public EnemyPool(Transform container, int count = 10)
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _container = container;
            CreatePool(count);
        }

        public GameObject GetFreeElement()
        {
            var gameObject = _pool.FirstOrDefault(x => x.activeSelf == false);

            if (gameObject != null)
            {
                return gameObject;
            }

            return CreateObject();
        }

        private void CreatePool(int count)
        {
            _pool = new List<GameObject>();

            for (int i = 0; i < count; i++)
            {
                _pool.Add(CreateObject());
            }
        }

        private GameObject CreateObject(bool isActiveByDefault = false)
        {
            var createObject = _gameFactory.CreateEnemy();
            createObject.transform.parent = _container;
            createObject.gameObject.SetActive(isActiveByDefault);
            return createObject;
        }
    }
}