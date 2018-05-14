using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {
   public Text controls;
   public Image pause;

    private void Start()
    {
        controls.text = " Camera: \n w = up\n s = down \n a = left\n d = right\n mouseWheel = zoom\n\n Building: \n c = collector\n f = factory\n r = road\n \n p = pause";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void resume()
    {
        pause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void stop()
    {
        Application.Quit();
    }

}
