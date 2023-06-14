using Homework.Homework_v2.Scripts.Enemy.Agents;
using UnityEngine;
using VContainer;

namespace Homework.Homework_v2.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _character;
        [SerializeField] private Transform _worldTransform;

        private EnemyPool _enemyPool;

        [Inject]
        private void Construct(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public GameObject SpawnEnemy()
        {
            if (!_enemyPool.GetEnemyPool().TryDequeue(out var enemy))
            {
                return null;
            }

            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_character);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_enemyPool.Container);
            _enemyPool.GetEnemyPool().Enqueue(enemy);
        }
    }
}