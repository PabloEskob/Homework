using UnityEngine;
using UnityEngine.UI;

namespace Game_v1.CodeBase.UI.Elements
{
    public abstract class GameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        protected IButtonService ButtonService;

        private void OnEnable()
        {
            _button.onClick.AddListener(Use);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Use);
        }

        public void Construct(IButtonService button)
        {
            ButtonService = button;
        }

        protected abstract void Use();
    }
}