using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Managers;
using UnityEngine;

namespace MultiplayerPrototype.Uis
{
    public class CanvasMenu : MonoBehaviour
    {
        [SerializeField] GameObject _menuPanel;

        public void StartButton()
        {
            GameManager.Instance.StartGame();
        }

        public void ExitButton()
        {
            GameManager.Instance.Exit();
        }
    }
}
