using System;
using Homework.Scripts.Sections.Player;
using UnityEngine;

namespace Atomic
{
    [Serializable]
    public class TurnEngine
    {
        [SerializeField] public AtomicVariable<float> SmoothRotationTime = new();
        [HideInInspector] public AtomicEvent<Vector3> OnTurn = new();
        [HideInInspector] public AtomicVariable<bool> TurnRequired = new();
        [HideInInspector] public AtomicVariable<Vector3> TurnDirection = new();
        [HideInInspector] public AtomicEvent OnMouseTurn = new();

        private LateUpdateEngine _lateUpdateEngine = new();

        public void Construct(Life life, CharacterController characterController)
        {
            AtomicVariable<bool> isDeath = life.IsDeath;

            OnTurn += direction =>
            {
                if (isDeath.Value)
                {
                    return;
                }

                TurnRequired.Value = true;
                TurnDirection.Value = direction;
            };

            OnMouseTurn += () =>
            {
                if (isDeath.Value)
                {
                    return;
                }

                if (Camera.main != null)
                {
                    var directionToMouse = DirectionToMouse(characterController);

                    TurnRequired.Value = true;
                    TurnDirection.Value = directionToMouse;
                }
            };

            _lateUpdateEngine.Do(time =>
            {
                if (TurnRequired.Value)
                {
                    var currentVelocity = SmoothRotationTime.Value * time;
                    float targetAngle = Mathf.Atan2(TurnDirection.Value.x, TurnDirection.Value.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(characterController.transform.eulerAngles.y, targetAngle,
                        ref currentVelocity,
                        currentVelocity);
                    characterController.transform.rotation = Quaternion.Euler(0, angle, 0);
                }
            });
        }

        private static Vector3 DirectionToMouse(CharacterController characterController)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, Camera.main.transform.position.y));
            var position = characterController.transform.position;
            mousePosition.y = position.y;
            var directionToMouse = mousePosition - position;
            return directionToMouse;
        }
    }
}