using UnityEngine;
using UnityEngine.UI;

namespace Game_v1.CodeBase.UI.Elements
{
    public abstract class GameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        protected IButtonService buttonService;

        private void Awake()
        {
            _button.onClick.AddListener(Use);
        }

        public void Construct(IButtonService button)
        {
            buttonService = button;
        }

        protected abstract void Use();
    }
}