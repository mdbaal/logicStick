using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI : MonoBehaviour {
   public Text controls;
   public Image pause;

    private void Start()
    {
        //set UI control keys
        if(controls != null) controls.text = " Camera: \n W = up\n S = down \n A = left\n D = right\n mouseWheel = zoom\n\n Building: \n C = collector\n F = factory\n R = road\n \n P = pause\n B = bulldoze";
    }

    private void Update()
    {
        //check if the game needs to be paused
        if (Input.GetKeyDown(KeyCode.P) && pause != null)
        {
            pause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void play()
    {
        //start a new game
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void resume()
    {
        //resume from the pause menu
        pause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void stop()
    {
        //if in main menu, stop the application, if in pause menu, go back to main menu
        if (SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        }
        else
        {
            Application.Quit();
        }
    }

}
