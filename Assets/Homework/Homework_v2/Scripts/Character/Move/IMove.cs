using UnityEngine;

namespace Homework.Homework_v2.Scripts.Character.Move
{
    public interface IMove
    {
        void Move(Vector2 vector2);

        Vector2 GetPosition();
    }
}