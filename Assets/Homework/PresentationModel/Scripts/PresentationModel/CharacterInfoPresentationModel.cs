using System;
using Lessons.Architecture.PM;
using Lessons.Architecture.PM.Popup;

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
            return _characterInfo.GetStat(name).Value.ToString();
        }

        public int GetStats()
        {
            return _characterInfo.GetStats().Length;
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
            OnStateChanged?.Invoke();
        }

        private void OnStatRemoved(CharacterStat characterStat)
        {
            characterStat.SetName();
            OnStateChanged?.Invoke();
        }
    }
}