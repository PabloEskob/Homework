using Homework.Homework_v2.Scripts.Bullets;
using Homework.Homework_v2.Scripts.Common;
using Homework.Homework_v2.Scripts.Enemy.Agents;
using UnityEngine;
using VContainer;

namespace Homework.Homework_v2.Scripts.Components
{
    public class EnemyFireComponent : MonoBehaviour
    {
        private BulletSystem _bulletSystem;
        private EnemyAttackAgent _enemyAttackAgent;

        [Inject]
        private void Construct(BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
        }

        private void Awake()
        {
            _enemyAttackAgent = GetComponent<EnemyAttackAgent>();
        }

        private void OnEnable()
        {
            _enemyAttackAgent.OnFire += OnFire;
        }

        private void OnDisable()
        {
            _enemyAttackAgent.OnFire -= OnFire;
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)PhysicsLayer.ENEMY_BULLET,
                color = Color.red,
                damage = 1,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}