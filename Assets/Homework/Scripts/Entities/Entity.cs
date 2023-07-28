using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homework.Scripts.Entities
{
    public class Entity : MonoBehaviour
    {
        private readonly List<object> _components = new();

        public T Get<T>()
        {
            for (int i = 0, count = _components.Count; i < count; i++)
            {
                var component = _components[i];
                if (component is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Component of type {typeof(T).Name} is not found!");
        }

        public bool TryGet<T>(out T result)
        {
            for (int i = 0, count = _components.Count; i < count; i++)
            {
                var component = _components[i];
                if (component is T tComponent)
                {
                    result = tComponent;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public void Add(object component)
        {
            _components.Add(component);
        }

        public void AddRange(IEnumerable<object> component)
        {
            _components.AddRange(component);
        }

        public void Remove(object component)
        {
            _components.Remove(component);
        }
    }
}