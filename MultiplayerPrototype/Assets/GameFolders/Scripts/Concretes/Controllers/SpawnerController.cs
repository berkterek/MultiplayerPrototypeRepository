using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Enums;
using MultiplayerPrototype.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MultiplayerPrototype.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [Range(0f, 20f)] [SerializeField] float min = 5f;
        [Range(0f, 20f)] [SerializeField] float max = 10f;

        float _maxDelayTime;
        float _currentSpawnTime;
        float _currentLevelTime;
        int _index;
        float _newEnemyTime;

        public float RandomSpawnTime => Random.Range(min, max);

        private void Awake()
        {
            _maxDelayTime = RandomSpawnTime;
        }

        private void Start()
        {
            _newEnemyTime = EnemyManager.Instance.NewEnemyTime;
        }

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;

            if (_currentSpawnTime > _maxDelayTime)
            {
                Spawn();

                _currentSpawnTime = 0f;
                _maxDelayTime = RandomSpawnTime;
            }

            if (_currentLevelTime < Time.time)
            {
                _currentLevelTime = Time.time + _newEnemyTime;
                SetNewEnemyIndex();
            }
        }

        private void Spawn()
        {
            IEnemyController newEnemy = EnemyManager.Instance.GetObjectPool((EnemyEnum)Random.Range(0,_index));
            newEnemy.transform.position = this.transform.position;
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.gameObject.SetActive(true);
        }

        private void SetNewEnemyIndex()
        {
            if (_index < EnemyManager.Instance.Count)
            {
                _index++;
            }
        }
    }
}