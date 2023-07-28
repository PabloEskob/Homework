using System;
using Declarative;

namespace Atomic
{
    public class FixedUpdateMechanics : IFixedUpdateListener
    {
        private Action<float> _update;

        public void Do(Action<float> update)
        {
            _update = update;
        }

        public void FixedUpdate(float deltaTime)
        {
            _update.Invoke(deltaTime);
        }
    }
}