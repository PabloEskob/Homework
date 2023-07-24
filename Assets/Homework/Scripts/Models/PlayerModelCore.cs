using System;
using Declarative;
using UnityEngine;

namespace Homework.Scripts.Models
{
    [Serializable]
    public class PlayerModelCore
    {
        [Section]
        [SerializeField]
        public PlayerModelMove PlayerModelMove;
    }
}