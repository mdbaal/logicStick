using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour {
    [SerializeField]
    private bool initialized = false;
    private string[] commands = {"fcam","lcam","onebillion","nothing","highvalue","lowvalue","1x","2x","3x"};
    [SerializeField]
    private string input = null;

    private Economy economy;
    private Game game;
    private Camera cam;
    private void Start()
    {
        economy = this.GetComponent<Economy>();
        game = this.GetComponent<Game>();
        cam = Camera.main;
    }

    private void initConsole()
    {
        if (initialized)
        {
            deInitCosole();
            return;
        }
        cam.GetComponent<CameraControl>().canMove = false;
        initialized = true;

    }
    private void deInitCosole()
    {
        cam.GetComponent<CameraControl>().canMove = true;
        initialized = false;
        input = null;

    }
    private void getConsoleInput()
    {
        if (Input.GetKeyDown(KeyCode.F1)) initConsole();
        if (Input.GetKeyDown(KeyCode.Backspace)) input = null;
        if (!initialized) return;

        if (Input.anyKeyDown)
        {
            input += Input.inputString;
        }
        
        for(int i = 0;i < commands.Length; i++)
        {
            if(input == commands[i])
            {
                handleCommand(input);
                input = null;
                return;
            }
        }   
    }
    private void handleCommand(string _input)
    {
        switch (_input)
        {
            case "fcam":
                print("free cam");
                cam.GetComponent<CameraControl>().restricted = false;
                return;
            case "lcam":
                print("locked cam");
                cam.GetComponent<CameraControl>().restricted = true;
                return;
            case "onebillion":
                print("billionare");
                economy.treasure(1000000000);
                return;
            case "highvalue":
                print("market rise");
                return;
            case "lowvalue":
                print("market drop");
                return;
            case "1x":
                Time.timeScale = 1;
                print("time scale 1");
                return;
            case "2x":
                Time.timeScale = 2;
                print("time scale 2");
                return;
            case "3x":
                Time.timeScale = 3;
                print("time scale 3");
                return;
            case "nothing":
                economy.treasure(-economy.treasure());
                print("nothing at all");
                return;

        }
    }

    private void Update()
    {
        getConsoleInput();
    }

}
