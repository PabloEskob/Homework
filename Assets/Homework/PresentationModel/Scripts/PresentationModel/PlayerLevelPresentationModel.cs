using System;
using Lessons.Architecture.PM;
using Lessons.Architecture.PM.Popup;

namespace Homework.PresentationModel.Scripts.PresentationModel
{
    public class PlayerLevelPresentationModel : IPlayerLevelPresentationModel
    {
        public event Action OnStateChanged;

        private readonly PlayerLevel _playerLevel;

        public PlayerLevelPresentationModel(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
        }

        public void Start()
        {
            _playerLevel.OnExperienceChanged += OnExperienceChanged;
            _playerLevel.OnLevelUp += OnLevelUp;
        }

        public void Stop()
        {
            _playerLevel.OnExperienceChanged -= OnExperienceChanged;
            _playerLevel.OnLevelUp -= OnLevelUp;
        }

        public string GetCurrentLevel()
        {
            return $"LEVEL:{_playerLevel.CurrentLevel}";
        }

        public string GetExperience()
        {
            return $"XP:{_playerLevel.CurrentExperience}/{_playerLevel.RequiredExperience}";
        }

        public float GetSliderValue()
        {
            return _playerLevel.CurrentExperience;
        }

        public void LevelUp()
        {
            _playerLevel.LevelUp();
        }

        public bool GetAvailable()
        {
            return _playerLevel.CanLevelUp();
        }

        public float GetSliderMaxValue()
        {
            return _playerLevel.RequiredExperience;
        }

        private void OnExperienceChanged(int obj)
        {
            OnStateChanged?.Invoke();
        }

        private void OnLevelUp()
        {
            OnStateChanged?.Invoke();
        }
    }
}