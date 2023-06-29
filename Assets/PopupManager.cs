using Lessons.Architecture.PM.Popup;
using Sirenix.OdinInspector;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private CharacterPopup _characterPopup;

    [Button]
    public void ActivatePopup()
    {
        _characterPopup.Show();
    }

    [Button]
    public void DeActivatePopup()
    {
        _characterPopup.Hide();
    }
}