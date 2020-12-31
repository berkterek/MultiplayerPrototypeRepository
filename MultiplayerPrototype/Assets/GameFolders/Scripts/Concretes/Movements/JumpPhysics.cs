using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using UnityEngine;

namespace MultiplayerPrototype.Movements
{
    public class JumpPhysics
    {
        private Rigidbody _rigidbody;

        public JumpPhysics(IPlayerController playerController)
        {
            _rigidbody = playerController.transform.GetComponent<Rigidbody>();
        }

        public void TickFixed(float jumpForce, bool canJump)
        {
            if (_rigidbody.velocity != Vector3.zero || !canJump) return;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}