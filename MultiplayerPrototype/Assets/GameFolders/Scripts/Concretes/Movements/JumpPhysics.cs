using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Abstracts.Movements;
using UnityEngine;

namespace MultiplayerPrototype.Movements
{
    public class JumpPhysics : IJump
    {
        private Rigidbody _rigidbody;

        public JumpPhysics(IEntityController entityController)
        {
            _rigidbody = entityController.transform.GetComponent<Rigidbody>();
        }

        public bool TickFixed(float jumpForce, bool canJump)
        {
            if (_rigidbody.velocity != Vector3.zero || !canJump) return false;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * jumpForce);

            return false;
        }
    }
}