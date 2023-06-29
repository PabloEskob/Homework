﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lessons.Architecture.PM.Buttons
{
    public sealed class LevelUpButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [Space] 
        [SerializeField] private Image _buttonBackground;
        [SerializeField] private Sprite _availableButtonSprite;
        [SerializeField] private Sprite _lockedButtonSprite;
        [Space] 
        [SerializeField] private TextMeshProUGUI _text;
        [Space]
        [SerializeField] private State _state;
        
        public void AddListener(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }
        public void RemoveListener(UnityAction action)
        {
            _button.onClick.RemoveListener(action);
        }
        
        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable ? State.Available : State.Locked;
            SetState(state);
        }

        public void SetState(State state)
        {
            _state = state;

            if (state == State.Available)
            {
                _button.interactable = true;
                _buttonBackground.sprite = _availableButtonSprite;
            }
            else if (state == State.Locked)
            {
                _button.interactable = false;
                _buttonBackground.sprite = _lockedButtonSprite;
            }
            else
            {
                throw new Exception($"Undefined button state {state}!");
            }
        }


#if UNITY_EDITOR

        private void OnValidate()
        {
            try
            {
                SetState(_state);
            }
            catch (Exception)
            {
                Debug.Log("Exception");
            }
        }

#endif
    }
}

public enum State
{
    Available = 0,
    Locked = 1
}