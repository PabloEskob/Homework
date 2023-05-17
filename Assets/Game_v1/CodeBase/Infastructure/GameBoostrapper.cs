using UnityEngine;

namespace Game_v1.CodeBase.Infastructure
{
    public class GameBoostrapper : MonoBehaviour
    {
        private Bootstrap _bootstrap;

        private void Awake()
        {
            _bootstrap = new Bootstrap();
            DontDestroyOnLoad(this);
        }
    }
}