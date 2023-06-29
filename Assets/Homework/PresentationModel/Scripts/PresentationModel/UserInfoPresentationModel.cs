using System;
using Lessons.Architecture.PM;
using UnityEngine;

namespace Homework.PresentationModel.Scripts.PresentationModel
{
    public class UserInfoPresentationModel : IUserInfoPresentationModel
    {
        private readonly UserInfo _userInfo;

        public UserInfoPresentationModel(UserInfo userInfo)
        {
            _userInfo = userInfo;
        }

        public event Action OnStateChanged;

        public string GetName()
        {
            return _userInfo.Name;
        }

        public string GetDescription()
        {
            return _userInfo.Description;
        }

        public Sprite GetIcon()
        {
            return _userInfo.Icon;
        }

        public void Start()
        {
            _userInfo.OnNameChanged += OnNameChanged;
            _userInfo.OnDescriptionChanged += OnDescriptionChanged;
            _userInfo.OnIconChanged += OnIconChanged;
        }

        public void Stop()
        {
            _userInfo.OnNameChanged -= OnNameChanged;
            _userInfo.OnDescriptionChanged -= OnDescriptionChanged;
            _userInfo.OnIconChanged -= OnIconChanged;
        }
        
        private void OnIconChanged(Sprite icon)
        {
            OnStateChanged?.Invoke();
        }

        private void OnNameChanged(string name)
        {
            OnStateChanged?.Invoke();
        }

        private void OnDescriptionChanged(string description)
        {
            OnStateChanged?.Invoke();
        }
    }
}