
using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Controllers;
using UnityEngine;

namespace MultiplayerPrototype.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Level Difficulty",order = 1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] FloorController _floorPrefab;
        [SerializeField] GameObject _spawners;
        [SerializeField] Material _skyBox;

        public FloorController FloorController => _floorPrefab;

        public GameObject Spawners => _spawners;
        public Material SkyBox => _skyBox;
    }    
}

