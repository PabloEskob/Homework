using UnityEngine;

namespace Game_v1.CodeBase.Factory
{
    public sealed class GameFactory : IGameFactory
    {
        private const string PlayerPath = "Player/[PLAYER]";
        private const string EnemyPath = "Enemy/Enemy";

        public GameObject CreatePlayer(Vector3 at)
        {
            return Instantiate(PlayerPath, at);
        }

        public GameObject CreateEnemy()
        {
            return Instantiate(EnemyPath);
        }
        
        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}