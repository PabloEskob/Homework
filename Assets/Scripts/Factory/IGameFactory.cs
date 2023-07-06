using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Other;
using SaveLoad;
using Units;
using UnityEngine;

namespace Factory
{
    public interface IGameFactory
    {
        Task<GameObject> CreateUnit(UnitTypeId unitTypeId, Transform transform);
        void CleanUp();
        List<ISaveProgressReader> SaveProgressReaders { get; }
        List<ISaveProgress> ProgressWriters { get; }
    }
}