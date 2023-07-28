using Declarative;
using UnityEngine;

namespace Homework.Scripts.Models.Player
{
    public sealed class PlayerModel : DeclarativeModel
    {
        [Section] [SerializeField] public PlayerModelCore PlayerModelCore;
        [Section] [SerializeField] public PlayerModelView PlayerModelView;
        [Section] [SerializeField] public PlayerModelComponents PlayerModelComponents;
    }
}