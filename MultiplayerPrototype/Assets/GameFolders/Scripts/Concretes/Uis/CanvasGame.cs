using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Managers;
using UnityEngine;

namespace MultiplayerPrototype.Uis
{
    public class CanvasGame : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;
        [SerializeField] GameObject _mobileInputs;
        int _index;

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnOnGameOver;
            GameManager.Instance.OnSceneChanged += HandleOnSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnOnGameOver;
            GameManager.Instance.OnSceneChanged -= HandleOnSceneChanged;
        }

        public void YesButton()
        {
            GameManager.Instance.StartGame(_index);
            _gameOverPanel.SetActive(false);
        }

        public void NoButton()
        {
            GameManager.Instance.Menu();
            _gameOverPanel.SetActive(false);
        }

        private void HandleOnOnGameOver(int index)
        {
            _gameOverPanel.SetActive(true);
            _index = index;
        }

        private void HandleOnSceneChanged(bool result)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _mobileInputs.SetActive(result);    
            }
        }
    }
}