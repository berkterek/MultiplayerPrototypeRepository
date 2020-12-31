using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [Range(0f,20f)]
        [SerializeField] float min = 5f;
        [Range(0f,20f)]
        [SerializeField] float max = 10f;

        public float RandomSpawnTime => Random.Range(min, max);
    }    
}

