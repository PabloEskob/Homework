using System;
using Declarative;
using Homework.Scripts.Components;
using Homework.Scripts.Entities;
using UnityEngine;

namespace Homework.Scripts.Models.Player
{
    [Serializable]
    public class PlayerModelComponents
    {
        [SerializeField] public Entity Entity;

        [Construct]
        private void Construct(PlayerModelCore playerModelCore)
        {
            Entity.AddRange(new object[]
            {
                new MoveComponent(playerModelCore.Move.MoveEngine.OnMove),
                new TurnComponent(playerModelCore.Move.TurnEngine.OnTurn,playerModelCore.Move.TurnEngine.OnMouseTurn),
                new TakeDamageComponent(playerModelCore.Life.OnTakeDamage)
            });
        }
    }
}