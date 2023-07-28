using Atomic;
using UnityEngine;

namespace Homework.Scripts.Components
{
    public class MoveComponent : IMoveComponent
    {
        private readonly IAtomicAction<Vector3> _onMove;

        public MoveComponent(AtomicEvent<Vector3> moveEngineOnMove)
        {
            _onMove = moveEngineOnMove;
        }

        public void Move(Vector3 direction)
        {
            _onMove.Invoke(direction);
        }
    }
}