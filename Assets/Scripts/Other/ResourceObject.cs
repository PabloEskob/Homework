using UnityEngine;

namespace Other
{
    public sealed class ResourceObject : MonoBehaviour
    {
        [SerializeField]
        public ResourceType resourceType;
        
        [SerializeField]
        public int remainingCount;
    }
}