using System;
using Lessons.Architecture.PM;
using Lessons.Architecture.PM.Popup;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Homework.PresentationModel.Scripts.PresentationModel
{
    public class CharacterInfoPresentationModel : ICharacterInfoPresentationModel
    {
        public event Action OnStateChanged;
        
        private readonly CharacterInfo _characterInfo;
        
        public CharacterInfoPresentationModel(CharacterInfo characterInfo)
        {
            _characterInfo = characterInfo;
        }

        public string GetValue(string name)
        {
            var stats = GetStats();
            
            for (var i = 0; i < stats.Length; i++)
            {
                var characterStat = stats[i];
                
                if (characterStat.Name == name)
                {
                    return $"{name}: {_characterInfo.GetStat(name).Value}";
                }
            }

            return $"{name}: 0";
        }

        public CharacterStat[] GetStats()
        {
            return _characterInfo.GetStats();
        }

        public void Start()
        {
            _characterInfo.OnStatAdded += OnStatAdded;
            _characterInfo.OnStatRemoved += OnStatRemoved;
        }

        public void Stop()
        {
            _characterInfo.OnStatAdded -= OnStatAdded;
            _characterInfo.OnStatRemoved -= OnStatRemoved;
        }

        private void OnStatAdded(CharacterStat characterStat)
        {
            characterStat.SetName(characterStat.gameObject.name);
            characterStat.OnValueChanged += OnValueChanged;
            OnStateChanged?.Invoke();
        }

        private void OnStatRemoved(CharacterStat characterStat)
        {
            characterStat.SetName();
            characterStat.OnValueChanged -= OnValueChanged;
            OnStateChanged?.Invoke();
        }

        private void OnValueChanged(int obj)
        {
            OnStateChanged?.Invoke();
        }
    }
}