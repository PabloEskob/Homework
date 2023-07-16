using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Other
{
    public sealed class ResourceObject : MonoBehaviour
    {
        [SerializeField]
        public ResourceType resourceType;
        
        [SerializeField]
        public int remainingCount;
        
        [ReadOnly]
        [SerializeField] public string Id;

        public ResourceType ResourceType
        {
            get => resourceType;
            set => resourceType = value;
        }

        public void GenerateId()
        {
            Id = $"{Guid.NewGuid().ToString()}_{DateTime.Now.Ticks}";
        }
    }
}