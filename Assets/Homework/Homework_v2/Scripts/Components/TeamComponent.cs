using UnityEngine;

namespace Homework.Homework_v2.Scripts.Components
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public bool IsPlayer => _isPlayer;

        [SerializeField] private bool _isPlayer;
    }
}