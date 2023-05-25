using Game_v1.CodeBase.Controllers;
using Game_v1.CodeBase.Services.ServiceLocator;
using Game_v1.CodeBase.UI.Elements;
using UnityEngine;

namespace Game_v1.CodeBase.UI
{
    public sealed class GameOverScreen : MonoBehaviour, IButtonService
    {
        [SerializeField] private RestartButton _restartButton;
        [SerializeField] private CanvasGroup _canvasGroup;

        private ISceneController _sceneController;

        private void Awake()
        {
            _restartButton.Construct(this);
        }

        private void Start()
        {
            _sceneController = AllServices.Container.Single<ISceneController>();
        }
        
        public void Use()
        {
            Hide();
            _sceneController.RestartCurrentScene();
        }

       
        public void Show()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
        }

        private void Hide()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}