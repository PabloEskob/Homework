using System;
using UnityEngine;

namespace Game_v1.CodeBase.Logic
{
    public sealed class CollisionCheck : MonoBehaviour
    {
        public event Action<Collider> Touched;

        private void OnTriggerEnter(Collider other)
        {
            Touched?.Invoke(other);
        }
    }
}