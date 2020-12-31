using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using MultiplayerPrototype.Abstracts.Controllers;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class FollowCameraController : MonoBehaviour
    {
        CinemachineVirtualCamera _camera;
        IPlayerController _playerController;
        
        private void Awake()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            _camera.Follow = _playerController.transform;
        }
    }    
}

