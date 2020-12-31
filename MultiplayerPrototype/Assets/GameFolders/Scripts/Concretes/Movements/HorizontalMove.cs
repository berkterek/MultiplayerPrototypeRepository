using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Abstracts.Movements;
using UnityEngine;

namespace MultiplayerPrototype.Movements
{
    public class HorizontalMove : IMover
    {
        private IPlayerController _playerController;
        int _minMaxBoudary = 4;
        float _moveSpeed = 10f;

        public HorizontalMove(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public void TickFixed(float horizontal)
        {
            if (horizontal == 0f) return;

            _playerController.transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed * horizontal);
            
            float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_minMaxBoudary, _minMaxBoudary);
            _playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y, 0f);
        }
    }    
}

