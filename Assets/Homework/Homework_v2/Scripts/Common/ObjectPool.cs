using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Homework.Homework_v2.Scripts.Common
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        public List<T> Pool { get; set; }

        private readonly T _prefab;
        private readonly Transform _container;
        private readonly int _count;

        public ObjectPool()
        {
            Pool = new List<T>();
        }

        public ObjectPool(T prefab, int count, Transform container)
        {
            _prefab = prefab;
            _container = container;
            _count = count;

            Create();
        }

        public void Add(T element)
        {
            Pool.Add(element);
            element.gameObject.SetActive(false);
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
            {
                return element;
            }

            return null;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var mono in Pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        private void Create()
        {
            Pool = new List<T>();

            for (int i = 0; i < _count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActive = false)
        {
            var createObject = Object.Instantiate(_prefab, _container);
            createObject.gameObject.SetActive(isActive);
            Pool.Add(createObject);
            return createObject;
        }
    }
}