using UnityEngine;

namespace Homework.Scripts.Components
{
    public interface ITurnComponent
    {
        void Turn(Vector3 direction);
        void MouseTurn();
    }
}