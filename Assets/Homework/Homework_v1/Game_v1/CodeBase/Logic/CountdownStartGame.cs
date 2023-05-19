using System;
using System.Collections;
using Game_v1.CodeBase.UI.Elements;
using TMPro;
using UnityEngine;

namespace Game_v1.CodeBase.Logic
{
    public sealed class CountdownStartGame : MonoBehaviour, IButtonService
    {
        [SerializeField] private int _countdownTime = 3;
        [SerializeField] private TextMeshProUGUI _countdownText;
        [SerializeField] private StartButton _startButton;
        
        public event Action OnFinished;

        private void Awake()
        {
            _startButton.Construct(this);
        }

        public void Use()
        {
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            _countdownText.text = _countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            for (int i = _countdownTime - 1; i >= 0; i--)
            {
                _countdownText.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            _countdownText.text = "Go!";
            yield return new WaitForSeconds(1f);

            OnFinished?.Invoke();
            _countdownText.gameObject.SetActive(false);
        }
    }
}