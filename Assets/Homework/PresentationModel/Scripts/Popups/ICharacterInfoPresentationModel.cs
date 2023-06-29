using Homework.PresentationModel.Scripts.PresentationModel;

namespace Lessons.Architecture.PM.Popup
{
    public interface ICharacterInfoPresentationModel: IEventListener
    {
        string GetValue(string name);
        int GetStats();
    }
}