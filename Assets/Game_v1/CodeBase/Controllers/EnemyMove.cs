using Game_v1.CodeBase.Logic;
using UnityEngine;

namespace Game_v1.CodeBase.Controllers
{
    public sealed class EnemyMove : MonoBehaviour
    {
        [SerializeField] private Movement _movement;

        private void FixedUpdate()
        {
            _movement.Move(Vector3.back);
        }
    }
}