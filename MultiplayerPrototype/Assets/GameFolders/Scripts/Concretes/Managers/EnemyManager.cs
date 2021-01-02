using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Controllers;
using MultiplayerPrototype.Enums;
using UnityEngine;

namespace MultiplayerPrototype.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] EnemyController[] _enemyPrefabs;

        private static Dictionary<EnemyEnum, Queue<IEnemyController>> _enemies =
            new Dictionary<EnemyEnum, Queue<IEnemyController>>();

        public int Count => _enemies.Count;

        public static EnemyManager Instance { get; private set; }

        private void Awake()
        {
            SingletonThisGameObject();
            InitializePool();
        }

        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void InitializePool()
        {
            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<IEnemyController> queue = new Queue<IEnemyController>();

                for (int j = 0; j < 5; j++)
                {
                    IEnemyController newEnemy = Instantiate(_enemyPrefabs[i]);
                    newEnemy.transform.parent = this.transform;
                    newEnemy.transform.gameObject.SetActive(false);
                    queue.Enqueue(newEnemy);
                }

                _enemies.Add((EnemyEnum) i, queue);
            }
        }

        public void SetObjectPool(IEnemyController enemyController)
        {
            enemyController.transform.gameObject.SetActive(false);
            enemyController.transform.transform.parent = this.transform;

            Queue<IEnemyController> enemyQueue = _enemies[enemyController.EnemyEnum];
            enemyQueue.Enqueue(enemyController);
        }

        public IEnemyController GetObjectPool(EnemyEnum enemyEnum)
        {
            Queue<IEnemyController> enemyQueue = _enemies[enemyEnum];

            if (enemyQueue.Count == 0)
            {
                IEnemyController newEnemy = Instantiate(_enemyPrefabs[(int) enemyEnum]);
                enemyQueue.Enqueue(newEnemy);
            }

            return enemyQueue.Dequeue();
        }
    }
}