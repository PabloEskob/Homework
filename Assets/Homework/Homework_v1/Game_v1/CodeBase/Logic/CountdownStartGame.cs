using System;
using System.Collections;
using Game_v1.CodeBase.UI.Elements;
using UnityEngine;

namespace Game_v1.CodeBase.Logic
{
    public sealed class CountdownStartGame : MonoBehaviour, IButtonService
    {
        public event Action Finished;

        [SerializeField] private int _countdownTime = 3;
        [SerializeField] private StartButton _startButton;

        private Coroutine _coroutine;

        private void Awake()
        {
            _startButton.Construct(this);
        }

        public void Use()
        {
            _coroutine = StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            Debug.Log(_countdownTime.ToString());

            yield return new WaitForSeconds(1f);

            for (int i = _countdownTime - 1; i >= 1; i--)
            {
                Debug.Log(i.ToString());
                yield return new WaitForSeconds(1f);
            }

            Debug.Log("GO!");
            yield return new WaitForSeconds(1f);

            StopCoroutine(_coroutine);

            Finished?.Invoke();
        }
    }
}