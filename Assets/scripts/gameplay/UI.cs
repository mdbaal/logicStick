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
        if(controls != null) controls.text = " Camera: \n W = up\n S = down \n A = left\n D = right\n mouseWheel = zoom\n\n Building: \n C = collector\n F = factory\n R = road\n \n P = pause";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pause != null)
        {
            pause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void play()
    {
        SceneManager.LoadSceneAsync("Prototype", LoadSceneMode.Single);
    }

    public void resume()
    {
        pause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void stop()
    {
        if (SceneManager.GetActiveScene().name == "Prototype")
        {
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        }
        else
        {
            Application.Quit();
        }
    }

}
