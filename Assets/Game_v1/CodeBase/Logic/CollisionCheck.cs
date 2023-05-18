using System;
using Game_v1.CodeBase.System;
using UnityEngine;

namespace Game_v1.CodeBase.Logic
{
    public sealed class CollisionCheck : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private GameObject _destruction;

        public event Action<IDestruction> OnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_tag))
            {
                OnTrigger?.Invoke(_destruction.GetComponent<IDestruction>());
            }
        }
    }
}