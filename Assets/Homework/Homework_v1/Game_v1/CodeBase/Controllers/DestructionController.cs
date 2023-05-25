using Game_v1.CodeBase.Enemy.Components;
using Game_v1.CodeBase.Logic;
using Game_v1.CodeBase.Managers;
using Game_v1.CodeBase.Player.Components;
using UnityEngine;

namespace Game_v1.CodeBase.Controllers
{
    public sealed class DestructionController : MonoBehaviour
    {
        private const string Player = "Player";
        private const string Obstacle = "Obstacle";

        [SerializeField] private CollisionCheck _collisionCheck;
        [SerializeField] private EnemyDeathComponent _enemyDeathComponent;

        private PlayerDeath _playerDeath;
        
        private void OnEnable()
        {
            _collisionCheck.Touched += OnTouched;
        }

        private void OnDisable()
        {
            _collisionCheck.Touched -= OnTouched;
        }

        private void OnTouched(Collider target)
        {
            if (target.CompareTag(Player))
            {
                _playerDeath = target.GetComponent<Entity>().Get<PlayerDeath>();
                _playerDeath.TakeDamage();
            }

            if (target.CompareTag(Obstacle))
            {
                _enemyDeathComponent.Die();
            }
        }
    }
}