using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MultiplayerPrototype.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [Range(0f, 20f)] [SerializeField] float min = 5f;
        [Range(0f, 20f)] [SerializeField] float max = 10f;

        [Header("Enemy Prefabs")] [SerializeField]
        EnemyController[] _enemyPrefabs;

        float _maxDelayTime;
        float _currentTime;

        public float RandomSpawnTime => Random.Range(min, max);

        private void Awake()
        {
            _maxDelayTime = RandomSpawnTime;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxDelayTime)
            {
                Spawn();

                _currentTime = 0f;
                _maxDelayTime = RandomSpawnTime;
            }
        }

        private void Spawn()
        {
           IEntityController newEnemy = Instantiate(_enemyPrefabs[0], transform.position, transform.rotation);
           newEnemy.transform.parent = this.transform;
        }
    }
}