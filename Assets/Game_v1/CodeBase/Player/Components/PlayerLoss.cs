using System;
using Game_v1.CodeBase.System;
using UnityEngine;

namespace Game_v1.CodeBase.Player.Components
{
    public sealed class PlayerLoss : MonoBehaviour, IDestruction
    {
        public event Action OnLoss;

        public void Die()
        {
            Debug.Log("TheEnd");
            OnLoss?.Invoke();
        }
    }
}