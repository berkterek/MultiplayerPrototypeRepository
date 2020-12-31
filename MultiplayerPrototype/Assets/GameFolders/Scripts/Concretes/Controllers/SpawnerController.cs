using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MultiplayerPrototype.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [Range(0f,20f)]
        [SerializeField] float min = 5f;
        [Range(0f,20f)]
        [SerializeField] float max = 10f;
        
        [Header("Enemy Prefabs")]
        [SerializeField] EnemyController _enemyPrefab;

        public float RandomSpawnTime => Random.Range(min, max);

        private void Awake()
        {
            
        }
    }    
}

