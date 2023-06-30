using System.Collections.Generic;
using Homework.PresentationModel.Scripts.PresentationModel;
using Lessons.Architecture.PM.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Lessons.Architecture.PM.Popup
{
    public sealed class CharacterPopup : Popup
    {
        [SerializeField] private LevelUpButton _levelUpButton;
        [SerializeField] private Button _closeButton;
        [Space] [SerializeField] private TextMeshProUGUI _textHeader;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _icon;
        [Space] [SerializeField] private TextMeshProUGUI _experience;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private Slider _sliderExperience;
        [Space] [SerializeField] private List<TextMeshProUGUI> _stats;

        private IUserInfoPresentationModel _infoPresentationModel;
        private IPlayerLevelPresentationModel _playerLevel;
        private ICharacterInfoPresentationModel _characterInfo;

        [Inject]
        private void Construct(IUserInfoPresentationModel infoPresentationModel,
            IPlayerLevelPresentationModel playerLevel, ICharacterInfoPresentationModel characterInfo)
        {
            _infoPresentationModel = infoPresentationModel;
            _playerLevel = playerLevel;
            _characterInfo = characterInfo;
        }

        protected override void OnShow(object args)
        {
            AssignValuesUserInfo();
            AssignValuesPlayerLevel();

            _levelUpButton.AddListener(OnLevelUpClicked);
            _closeButton.onClick.AddListener(OnCloseClicked);

            StartEvents();

            _infoPresentationModel.OnStateChanged += OnStateChangedUserInfo;
            _playerLevel.OnStateChanged += OnStateChangedPlayerLevel;
            _characterInfo.OnStateChanged += OnStateChangedCharacterInfo;
        }

        protected override void OnHide()
        {
            _levelUpButton.RemoveListener(OnLevelUpClicked);
            _closeButton.onClick.RemoveListener(OnCloseClicked);

            StopEvents();

            _infoPresentationModel.OnStateChanged -= OnStateChangedUserInfo;
            _playerLevel.OnStateChanged -= OnStateChangedPlayerLevel;
            _characterInfo.OnStateChanged -= OnStateChangedCharacterInfo;
        }

        private void StartEvents()
        {
            _infoPresentationModel.Start();
            _playerLevel.Start();
            _characterInfo.Start();
        }

        private void StopEvents()
        {
            _infoPresentationModel.Stop();
            _playerLevel.Stop();
            _characterInfo.Stop();
        }

        private void AssignValuesPlayerLevel()
        {
            _level.text = _playerLevel.GetCurrentLevel();
            _experience.text = _playerLevel.GetExperience();
            _sliderExperience.value = _playerLevel.GetSliderValue();
            _sliderExperience.maxValue = _playerLevel.GetSliderMaxValue();
            _levelUpButton.SetAvailable(_playerLevel.GetAvailable());
        }

        private void AssignValuesUserInfo()
        {
            _textHeader.text = _infoPresentationModel.GetName();
            _description.text = _infoPresentationModel.GetDescription();
            _icon.sprite = _infoPresentationModel.GetIcon();
        }

        private void AssignValuesCharacterInfo()
        {
            for (int i = 0; i < _stats.Count; i++)
            {
                _stats[i].text = _characterInfo.GetValue(_stats[i].transform.parent.name);
            }
        }

        private void OnStateChangedUserInfo()
        {
            AssignValuesUserInfo();
        }

        private void OnStateChangedCharacterInfo()
        {
            AssignValuesCharacterInfo();
        }

        private void OnStateChangedPlayerLevel()
        {
            AssignValuesPlayerLevel();
        }

        private void OnCloseClicked()
        {
            RequestClose();
        }

        private void OnLevelUpClicked()
        {
            _playerLevel.LevelUp();
        }
    }
}