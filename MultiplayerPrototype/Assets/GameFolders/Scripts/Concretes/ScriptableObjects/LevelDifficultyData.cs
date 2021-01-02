
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
    }    
}

