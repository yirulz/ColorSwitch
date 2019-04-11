using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ColorSwitch
{
    public class UIManager : MonoBehaviour
    {
        public Text scoreText;
        public GameObject splashScreen;
        public GameObject gameOverScreen;
        public GameObject finishScreen;

        public Player player;

    // Use this for initialization
    void Start()
        {
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (splashScreen.activeSelf)
                {
                    splashScreen.SetActive(false);
                    Time.timeScale = 1;
                }
            }

            if (!player.alive)
            {
                GameOver();
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (!gameOverScreen.activeSelf)
                {
                    Time.timeScale = 0;
                    gameOverScreen.SetActive(true);
                }
                else if(gameOverScreen.activeSelf)
                {
                    Time.timeScale = 1;
                    gameOverScreen.SetActive(false);
                }
            }
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }

        public void ExitApplication()
        {
            Application.Quit();
        }

        public void WinGame()
        {
            finishScreen.SetActive(true);
        }
    }
}