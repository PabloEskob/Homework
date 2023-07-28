using System;
using Atomic;
using UnityEngine;

namespace Homework.Scripts.Sections.Player
{
    [Serializable]
    public class Life
    {
        public AtomicVariable<bool> IsDeath = new();

        [HideInInspector] 
        public AtomicEvent<int> OnTakeDamage = new();

        [SerializeField] 
        private AtomicVariable<int> _healthPoints = new();


        public void Construct()
        {
            OnTakeDamage += damage =>
            {
                _healthPoints.Value -= damage;
            };

            _healthPoints.OnChanged += healthPoints =>
            {
                if (healthPoints <= 0)
                {
                    IsDeath.Value = true;
                }
            };
        }
    }
}