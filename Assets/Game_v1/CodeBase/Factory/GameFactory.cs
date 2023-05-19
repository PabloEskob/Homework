using UnityEngine;

namespace Game_v1.CodeBase.Factory
{
    public sealed class GameFactory : IGameFactory
    {
        private const string PlayerPath = "Player/[PLAYER]";
        private const string EnemyPath = "Enemy/Enemy";
        private const string HudPath = "UI/Hud";

        public GameObject CreateHud(Transform at)
        {
            return Instantiate(HudPath, at);
        }

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

        private GameObject Instantiate(string path, Transform at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at);
        }
    }
}