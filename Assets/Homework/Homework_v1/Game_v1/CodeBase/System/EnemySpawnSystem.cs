﻿using System;
using System.Collections;
using Game_v1.CodeBase.Logic;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.Services.ServiceLocator;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Game_v1.CodeBase.System
{
    public sealed class EnemySpawnSystem : MonoBehaviour,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener,
        IGameStartListener
    {
        [SerializeField] private GameObject[] _initialPoint;
        [SerializeField] private float _cooldown;

        private EnemyPool _enemyPool;
        private Coroutine _coroutine;
        private Action<IGameListener> _register;

        private void Awake()
        {
            _register = AllServices.Container.Single<IGameStateManagement>().Register;
            _register(this);
            _enemyPool = new EnemyPool(transform);
        }

        private void Spawn()
        {
            var random = Random.Range(0, _initialPoint.Length);
            var enemy = _enemyPool.GetFreeElement();
            enemy.transform.position = _initialPoint[random].transform.position;
            enemy.SetActive(true);
        }

        private IEnumerator Cooldown()
        {
            var newWaitForSecond = new WaitForSeconds(_cooldown);

            while (true)
            {
                Spawn();
                yield return newWaitForSecond;
            }
        }

        public void OnFinishGame()
        {
            if (_coroutine is not null)
            {
                StopCoroutine(_coroutine);
            }
        }

        public void OnPauseGame()
        {
            if (_coroutine is not null)
            {
                StopCoroutine(_coroutine);
            }
        }

        public void OnResumeGame()
        {
            _coroutine = StartCoroutine(Cooldown());
        }

        public void OnStartGame()
        {
            _coroutine = StartCoroutine(Cooldown());
        }
    }
}