using Atomic;
using UnityEngine;

namespace Homework.Scripts.Components
{
    public class TurnComponent : ITurnComponent
    {
        private readonly IAtomicAction<Vector3> _onTurn;
        private readonly IAtomicAction _onMouseTurn;

        public TurnComponent(AtomicEvent<Vector3> turn,IAtomicAction onMouseTurn)
        {
            _onTurn = turn;
            _onMouseTurn = onMouseTurn;
        }

        public void Turn(Vector3 direction)
        {
            _onTurn.Invoke(direction);
        }

        public void MouseTurn()
        {
            _onMouseTurn.Invoke();
        }
    }
}