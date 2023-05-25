using System;
using UnityEngine;

namespace Game_v1.CodeBase.Managers
{
    public sealed class Entity : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] _components;

        public T Get<T>()
        {
            for (int i = 0, count = _components.Length; i < count; i++)
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
            for (int i = 0, count = _components.Length; i < count; i++)
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
    }
}