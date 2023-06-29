using Homework.PresentationModel.Scripts.PresentationModel;

namespace Lessons.Architecture.PM.Popup
{
    public interface IPlayerLevelPresentationModel: IEventListener
    {
        string GetCurrentLevel();
        string GetExperience();
        float GetSliderValue();
        void LevelUp();
        bool GetAvailable();
        float GetSliderMaxValue();
    }
}