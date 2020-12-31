using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class FloorController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        Material _material;
        
        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        private void Update()
        {
            Vector2 direction = Vector2.down * Time.deltaTime * _moveSpeed;
            _material.mainTextureOffset += direction;
        }
    }    
}

