using Game_v1.CodeBase.Logic;
using Game_v1.CodeBase.Managers;
using Game_v1.CodeBase.Services.ServiceLocator;
using Game_v1.CodeBase.UI.Elements;
using UnityEngine;

namespace Game_v1.CodeBase.UI
{
    public sealed class Hud : MonoBehaviour, IButtonService
    {
        [SerializeField] private PauseButton _pauseButton;
        [SerializeField] private CountdownStartGame _countdownStartGame;

        private IGameManager _gameManager;

        private bool _pause;


        private void OnEnable()
        {
            _countdownStartGame.Finished += OnFinish;
        }

        private void OnDisable()
        {
            _countdownStartGame.Finished -= OnFinish;
        }

        private void Awake()
        {
            _pauseButton.Construct(this);
        }

        private void Start()
        {
            _gameManager = AllServices.Container.Single<IGameManager>();
        }

        public void Use()
        {
            if (_pause == false)
            {
                _gameManager.PauseGame();
                _pause = true;
            }
            else
            {
                _gameManager.ResumeGame();
                _pause = false;
            }
        }

        private void OnFinish()
        {
            _gameManager.StartGame();
        }
    }
}