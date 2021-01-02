using System;
using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Managers;
using UnityEngine;

namespace MultiplayerPrototype.Uis
{
    public class CanvasGame : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnOnGameOver;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnOnGameOver;
        }

        public void YesButton()
        {
            GameManager.Instance.StartGame();
            _gameOverPanel.SetActive(false);
        }

        public void NoButton()
        {
            GameManager.Instance.Menu();
            _gameOverPanel.SetActive(false);
        }
        
        private void HandleOnOnGameOver()
        {
            _gameOverPanel.SetActive(true);
        }
    }    
}

