using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Abstracts.Movements;
using MultiplayerPrototype.Movements;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _maxLifeTime = 10f;

        IMover _mover;
        float _currentLifeTime;

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

        //Object Pooling Pattern will be use
        private void KillYourself()
        {
            Destroy(this.gameObject);
        }
    }
}