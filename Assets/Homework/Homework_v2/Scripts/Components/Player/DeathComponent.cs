using UnityEngine;
using VContainer;

namespace Homework.Homework_v2.Scripts.Components
{
    public class DeathComponent : MonoBehaviour
    {
        private HitPointsComponent _hitPointsComponent;
        private GameManager.GameManager _gameManager;

        [Inject]
        private void Construct(GameManager.GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _hitPointsComponent = GetComponent<HitPointsComponent>();
        }

        private void OnEnable()
        {
            _hitPointsComponent.HpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.HpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }
    }
}