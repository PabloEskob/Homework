using Data;
using SaveLoad;
using UnityEngine;

namespace Other
{
    public sealed class UnitObject : MonoBehaviour, ISaveProgress
    {
        [SerializeField] public int hitPoints;

        [SerializeField] public int speed;

        [SerializeField] public int damage;
        
        
        public void UpdateProgress(WorldProgress worldProgress)
        {
            Debug.Log("a");
            worldProgress.WorldData.Position = transform.position.AsVectorData();
        }

        public void LoadProgress(WorldProgress worldProgress)
        {
            Debug.Log("b");
            Vector3Data savedPosition = worldProgress.WorldData.Position;

            if (savedPosition != null)
            {
                transform.position = savedPosition.AsUnityVector();
            }
        }
    }
}