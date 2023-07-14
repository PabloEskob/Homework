using System;
using Data;
using SaveLoad;
using Units;
using UnityEngine;

namespace Other
{
    public sealed class UnitObject : MonoBehaviour, ISaveLoadProgress
    {
        [SerializeField] public int HitPoints;
        [SerializeField] public int Speed;
        [SerializeField] public int Damage;
        [SerializeField] public string Id;

        public UnitTypeId UnitTypeId { get; set; }

        private SaveUnitData _saveUnitData;

        private void Start()
        {
            _saveUnitData = new SaveUnitData(Id, UnitTypeId);
        }

        public void UpdateProgress(WorldProgress worldProgress)
        {
            _saveUnitData.UniqueId = Id;
            _saveUnitData.Position = transform.position.AsVectorData();
            _saveUnitData.Rotation = transform.rotation.AsQuaternionData();
            worldProgress.WorldData.AddToList(_saveUnitData);
        }

        public void LoadProgress(WorldProgress worldProgress)
        {
            SaveUnitData saveUnit = worldProgress.WorldData.FindById(Id);
            transform.position = saveUnit.Position.AsUnityVector();
            transform.rotation = saveUnit.Rotation.AsUnityQuaternion();
        }

        public void GenerateId()
        {
            Id = $"{Guid.NewGuid().ToString()}_{DateTime.Now.Ticks}";
        }
    }
}