using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace CubeGame
{
    public class GameController : Singleton<GameController>
    {
        private void Update()
        {
            CheckExit();
        }

        private void CheckExit()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }
    }
}

