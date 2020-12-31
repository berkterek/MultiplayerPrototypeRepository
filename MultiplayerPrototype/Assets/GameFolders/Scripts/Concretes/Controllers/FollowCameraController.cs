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
        IEntityController _entityController;
        
        private void Awake()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
            _entityController = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            _camera.Follow = _entityController.transform;
        }
    }    
}

