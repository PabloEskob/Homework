using System;

namespace Homework.PresentationModel.Scripts.PresentationModel
{
    public interface IEventListener
    {
        event Action OnStateChanged;
        
        void Start();
        void Stop();
    }
}