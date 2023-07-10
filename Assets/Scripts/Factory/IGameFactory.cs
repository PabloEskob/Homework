using System.Threading.Tasks;
using Units;
using UnityEngine;

namespace Factory
{
    public interface IGameFactory
    {
        Task<GameObject> CreateUnit(UnitTypeId unitTypeId, Vector3 position,Quaternion rotation);
        void CleanUp();
    }
}