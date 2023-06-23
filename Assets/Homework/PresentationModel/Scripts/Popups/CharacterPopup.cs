using Lessons.Architecture.PM.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM.Popup
{
    public sealed class CharacterPopup : Popup
    {
        [SerializeField] private LevelUpButton _levelUpButton;
        [SerializeField] private Button _closeButton;

        protected override void OnShow(object args)
        {
            
        }

        protected override void OnHide()
        {
            
        }
    }
}