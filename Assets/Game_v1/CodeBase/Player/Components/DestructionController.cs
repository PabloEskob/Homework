using Game_v1.CodeBase.Logic;
using Game_v1.CodeBase.System;
using UnityEngine;

namespace Game_v1.CodeBase.Player.Components
{
    public sealed class DestructionController : MonoBehaviour
    {
        [SerializeField] private CollisionCheck _collisionCheck;

        private void OnEnable()
        {
            _collisionCheck.OnTrigger += OnDie;
        }

        private void OnDisable()
        {
            _collisionCheck.OnTrigger -= OnDie;
        }

        private void OnDie(IDestruction destruction)
        {
            destruction.Die();
        }
    }
}