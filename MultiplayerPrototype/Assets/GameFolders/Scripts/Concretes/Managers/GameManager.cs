using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MultiplayerPrototype.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

        public event System.Action OnGameOver;

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

        public void StartGame()
        {
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
            
            yield return null;
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
            Time.timeScale = 0f;
        }
    }    
}

