using System;
using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Abstracts.Inputs;
using MultiplayerPrototype.Inputs;
using MultiplayerPrototype.Movements;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] float _jumpForce;
        
        IPlayerInput _input;
        HorizontalMove _move;
        JumpPhysics _jump;
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

            Debug.Log(_input.IsJump);
            
            if (_input.IsJump)
            {
                _canJump = true;
            }
        }

        private void FixedUpdate()
        {
            _move.TickFixed(_horizontal);
            _jump.TickFixed(_jumpForce, _canJump);
            
            _canJump = false;
        }
    }
}