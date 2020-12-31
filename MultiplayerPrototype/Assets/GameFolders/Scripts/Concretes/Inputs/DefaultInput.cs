using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Inputs;
using NUnit.Framework;
using UnityEngine;

namespace MultiplayerPrototype.Inputs
{
    public class DefaultInput : IPlayerInput
    {
        DefaultControls _input;

        public float Horizontal { get; private set; }
        public bool IsJump { get; private set; }

        public DefaultInput()
        {
            _input = new DefaultControls();

            _input.Player.Move.performed += context => Horizontal = context.ReadValue<float>();

            _input.Player.Jump.started += context => IsJump = true;
            _input.Player.Jump.canceled += context => IsJump = false;

            _input.Player.Enable();
        }
    }
}

