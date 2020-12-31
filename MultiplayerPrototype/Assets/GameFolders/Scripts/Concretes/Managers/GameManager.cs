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

        public void Restart()
        {
            Time.timeScale = 1f;
            StartCoroutine(RestartAsync());
        }

        private IEnumerator RestartAsync()
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
            Time.timeScale = 0f;
        }
    }    
}

