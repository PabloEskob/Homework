using System;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.Services.ServiceLocator;
using Game_v1.CodeBase.System;
using Game_v1.CodeBase.UI;
using UnityEngine;

namespace Game_v1.CodeBase.Controllers
{
    public sealed class GameOverScreenController : MonoBehaviour, IGameFinishListener
    {
        [SerializeField] private GameOverScreen _gameOverScreen;
        
        private Action<IGameListener> _register;

        private void Awake()
        {
            _register = AllServices.Container.Single<IGameStateManagement>().Register;
            _register(this);
        }

        public void OnFinishGame()
        {
            _gameOverScreen.Show();
        }
    }
}