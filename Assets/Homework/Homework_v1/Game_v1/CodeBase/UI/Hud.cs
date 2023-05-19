using System;
using Game_v1.CodeBase.Logic;
using Game_v1.CodeBase.UI.Elements;
using UnityEngine;

namespace Game_v1.CodeBase.UI
{
    public class Hud : MonoBehaviour, IButtonService
    {
        [SerializeField] private PauseButton _pauseButton;
        [SerializeField] private CountdownStartGame _countdownStartGame;

        public event Action<bool> OnClick;
        public event Action OnClosed;

        private bool _click;


        private void OnEnable()
        {
            _countdownStartGame.OnFinished += OnFinish;
        }

        private void OnDisable()
        {
            _countdownStartGame.OnFinished -= OnFinish;
        }

        private void Awake()
        {
            _pauseButton.Construct(this);
        }

        public void Use()
        {
            _click = _click != true;

            OnClick?.Invoke(_click);
        }

        private void OnFinish()
        {
            OnClosed?.Invoke();
        }
    }
}