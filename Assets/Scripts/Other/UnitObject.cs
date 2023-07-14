using System;
using Units;
using UnityEngine;

namespace Other
{
    public sealed class UnitObject : MonoBehaviour
    {
        [SerializeField] public int HitPoints;
        [SerializeField] public int Speed;
        [SerializeField] public int Damage;
        [SerializeField] public string Id;

        public UnitTypeId UnitTypeId { get; set; }
        
        public void GenerateId()
        {
            Id = $"{Guid.NewGuid().ToString()}_{DateTime.Now.Ticks}";
        }
    }
}