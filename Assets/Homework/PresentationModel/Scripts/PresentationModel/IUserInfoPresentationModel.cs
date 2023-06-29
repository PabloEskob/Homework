using UnityEngine;

namespace Homework.PresentationModel.Scripts.PresentationModel
{
    public interface IUserInfoPresentationModel : IEventListener
    {
        string GetName();
        string GetDescription();
        Sprite GetIcon();
    }
}