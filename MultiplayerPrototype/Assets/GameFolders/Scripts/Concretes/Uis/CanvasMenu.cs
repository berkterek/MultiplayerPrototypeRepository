using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Managers;
using UnityEngine;

namespace MultiplayerPrototype.Uis
{
    public class CanvasMenu : MonoBehaviour
    {
        public void StartButton(int index)
        {
            GameManager.Instance.StartGame();
        }

        public void ExitButton()
        {
            GameManager.Instance.Exit();
        }
    }
}
