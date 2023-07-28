using System;
using Declarative;
using Homework.Scripts.Sections.Player;
using UnityEngine;

namespace Homework.Scripts.Models.Player
{
    [Serializable]
    public class PlayerModelCore
    {
        [Section] [SerializeField] public Move Move;
        [Section] [SerializeField] public Life Life;
    }
}