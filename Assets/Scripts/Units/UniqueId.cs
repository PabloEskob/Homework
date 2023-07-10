using System;
using Other;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(UnitObject))]
    public class UniqueId : MonoBehaviour
    {
        [ReadOnly] 
        [SerializeField] public string Id;

        private void Awake()
        {
            GenerateId();
        }

        private void GenerateId()
        {
            Id = $"{Guid.NewGuid().ToString()}_{DateTime.Now.Ticks}";
        }
    }
}