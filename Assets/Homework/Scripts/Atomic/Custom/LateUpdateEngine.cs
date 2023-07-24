using System;
using Declarative;

namespace Atomic
{
    public class LateUpdateEngine : ILateUpdateListener
    {
        private Action<float> _action;

        public void OnUpdate(Action<float> update)
        {
            _action = update;
        }
        
        public void LateUpdate(float deltaTime)
        {
            _action.Invoke(deltaTime);
        }
    }
}