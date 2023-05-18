using Game_v1.CodeBase.Controllers;
using Game_v1.CodeBase.System;
using UnityEngine;

namespace Game_v1.CodeBase.Enemy.Components
{
    public class EnemyDeathComponent : MonoBehaviour, IDestruction
    {
        [SerializeField] private EnemyMove _parent;

        public void Die()
        {
            _parent.gameObject.SetActive(false);
        }
    }
}