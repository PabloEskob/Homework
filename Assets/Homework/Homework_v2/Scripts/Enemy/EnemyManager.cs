using System.Collections;
using System.Collections.Generic;
using Homework.Homework_v2.Scripts.Components;
using UnityEngine;
using VContainer;

namespace Homework.Homework_v2.Scripts.Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        private readonly HashSet<GameObject> m_activeEnemies = new();
        private EnemySpawner _enemySpawner;

        [Inject]
        private void Construct(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemy = _enemySpawner.SpawnEnemy();
                if (enemy != null)
                {
                    if (m_activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().HpEmpty += this.OnDestroyed;
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpEmpty -= this.OnDestroyed;

                _enemySpawner.UnspawnEnemy(enemy);
            }
        }
    }
}