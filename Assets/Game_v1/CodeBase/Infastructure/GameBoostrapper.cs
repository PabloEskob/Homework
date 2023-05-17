using UnityEngine;

namespace Game_v1.CodeBase.Infastructure
{
    public class GameBoostrapper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            DontDestroyOnLoad(this);
        }
    }
}