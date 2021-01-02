using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Managers;
using MultiplayerPrototype.ScriptableObjects;
using UnityEngine;

namespace MultiplayerPrototype.Controllers
{
    public class DiffucultyContoller : MonoBehaviour
    {
        LevelDifficultyData _levelDifficultyData;
        
        private void Awake()
        {
            _levelDifficultyData = GameManager.Instance.LevelDifficultyData;
        }

        private void Start()
        {
            RenderSettings.skybox = _levelDifficultyData.SkyBox;
            Instantiate(_levelDifficultyData.FloorController);
            Instantiate(_levelDifficultyData.Spawners);
            _levelDifficultyData.SetMoveSpeed();
            EnemyManager.Instance.SetNewEnemyTime(_levelDifficultyData.NewEnemyTime);
        }
    }    
}

