using UnityEngine;

namespace Homework.Homework_v2.Scripts.GameManager
{
    public sealed class GameManager
    {
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}