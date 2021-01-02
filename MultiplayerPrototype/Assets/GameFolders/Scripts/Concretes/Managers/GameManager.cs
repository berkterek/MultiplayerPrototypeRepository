﻿using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MultiplayerPrototype.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] LevelDifficultyData[] _levelDifficultyDatas;

        int _difficultyIndex;
        
        public static GameManager Instance { get; set; }
        public event System.Action<int> OnGameOver;
        public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[_difficultyIndex];

        private void Awake()
        {
            SingletonObject();
        }

        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
        }

        private void SingletonObject()
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

        public void StartGame(int index)
        {
            _difficultyIndex = index;
            StartCoroutine(LoadMySceneAsync("Menu","Game"));
        }
        
        public void Menu()
        {
            StartCoroutine(LoadMySceneAsync("Game","Menu"));
        }

        private IEnumerator LoadMySceneAsync(string from, string to)
        {
            Time.timeScale = 1f;

            if (SceneManager.GetSceneByName(from).name != null)
            {
                yield return SceneManager.UnloadSceneAsync(from);    
            }

            if (SceneManager.GetSceneByName(to).name != null)
            {
                yield return SceneManager.UnloadSceneAsync(to);
            }
            
            yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(to));
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void GameOver()
        {
            OnGameOver?.Invoke(_difficultyIndex);
            Time.timeScale = 0f;
        }
    }    
}

