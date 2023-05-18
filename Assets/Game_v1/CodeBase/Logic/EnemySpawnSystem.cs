using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Game_v1.CodeBase.Logic
{
    public class EnemySpawnSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] _initialPoint;
        [SerializeField] private float _cooldown;

        private EnemyPool _enemyPool;
        private Coroutine _coroutine;

        private void Awake()
        {
            _enemyPool = new EnemyPool(this.transform);
        }

        private void Start()
        {
            _coroutine = StartCoroutine(Cooldown());
        }

        private void Spawn()
        {
            var random = Random.Range(0, _initialPoint.Length);
            var enemy = _enemyPool.GetFreeElement();
            enemy.transform.position = _initialPoint[random].transform.position;
            enemy.SetActive(true);
        }

        private IEnumerator Cooldown()
        {
            var newWaitForSecond = new WaitForSeconds(_cooldown);

            while (true)
            {
                Spawn();
                yield return newWaitForSecond;
            }
        }
    }
}