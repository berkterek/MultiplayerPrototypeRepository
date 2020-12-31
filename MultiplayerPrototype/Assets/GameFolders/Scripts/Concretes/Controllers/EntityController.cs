using System;
using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Abstracts.Inputs;
using MultiplayerPrototype.Abstracts.Movements;
using MultiplayerPrototype.Inputs;
using MultiplayerPrototype.Movements;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class EntityController : MonoBehaviour, IEntityController
    {
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] float _moveSpeed = 10f;

        IPlayerInput _input;
        IMover _move;
        IJump _jump;
        float _horizontal;
        bool _canJump;

        private void Awake()
        {
            _input = new DefaultInput();
            _move = new HorizontalMove(this);
            _jump = new JumpPhysics(this);
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;

            if (_input.IsJump)
            {
                _canJump = true;
            }
        }

        private void FixedUpdate()
        {
            _move.TickFixed(_horizontal,_moveSpeed);
            _canJump = _jump.TickFixed(_jumpForce, _canJump);
        }
    }
}