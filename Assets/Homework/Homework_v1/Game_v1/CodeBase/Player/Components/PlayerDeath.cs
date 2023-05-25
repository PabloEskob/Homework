using System;
using UnityEngine;

namespace Game_v1.CodeBase.Player.Components
{
    public sealed class PlayerDeath : MonoBehaviour
    {
        public event Action Died;
        
        public void TakeDamage()
        {
            Debug.Log("TheEnd");
            Died?.Invoke();
        }
    }
}