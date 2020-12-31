using System;
using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Movements;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;

        IMover _mover;

        private void Awake()
        {
            
        }
        
        
    }    
}

