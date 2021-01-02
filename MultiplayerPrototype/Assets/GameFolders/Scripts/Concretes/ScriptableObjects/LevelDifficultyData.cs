
using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Controllers;
using MultiplayerPrototype.Managers;
using UnityEngine;

namespace MultiplayerPrototype.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Level Difficulty",order = 1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] FloorController _floorPrefab;
        [SerializeField] GameObject _spawners;
        [SerializeField] Material _skyBox;
        [SerializeField] float _moveSpeed = 15f;
        [SerializeField] float _newEnemyTime = 60f;

        public FloorController FloorController => _floorPrefab;

        public GameObject Spawners => _spawners;
        public Material SkyBox => _skyBox;
        public float NewEnemyTime => _newEnemyTime;

        public void SetMoveSpeed()
        {
            EnemyManager.Instance.SetEnemiesMoveSpeed(_moveSpeed);
        }
    }    
}

