using System.Threading.Tasks;
using Other;
using Units;
using UnityEngine;

namespace Factory
{
    public interface IGameFactory
    {
        Task<UnitObject> CreateUnit(UnitTypeId unitTypeId, Vector3 position, Quaternion rotation);
        void CleanUp();
    }
}