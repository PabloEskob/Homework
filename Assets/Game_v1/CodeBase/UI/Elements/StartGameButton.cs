using UnityEngine;
using UnityEngine.UI;

namespace Game_v1.CodeBase.UI.Elements
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IWindowService _windowService;

        private void Awake()
        {
            _button.onClick.AddListener(StartGame);
        }

        public void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }

        private void StartGame()
        {
            _windowService.StartGame();
            gameObject.SetActive(false);
        }
    }
}