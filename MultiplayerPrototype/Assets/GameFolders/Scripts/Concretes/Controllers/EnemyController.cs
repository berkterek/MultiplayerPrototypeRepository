using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Abstracts.Movements;
using MultiplayerPrototype.Enums;
using MultiplayerPrototype.Managers;
using MultiplayerPrototype.Movements;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _maxLifeTime = 10f;
        [SerializeField] EnemyEnum _enemyEnum;
        
        IMover _mover;
        float _currentLifeTime;

        public EnemyEnum EnemyEnum => _enemyEnum;

        private void Awake()
        {
            _mover = new MoveVertical(this);
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > _maxLifeTime)
            {
                _currentLifeTime = 0f;
                KillYourself();
            }
        }

        private void FixedUpdate()
        {
            _mover.TickFixed(-1, _moveSpeed);
        }

        public void SetSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
        
        private void KillYourself()
        {
            EnemyManager.Instance.SetObjectPool(this);
        }
    }
}