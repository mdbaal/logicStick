using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour {
    private bool initialized = false;
    //list of all commands
    private string[] commands = {"fcam","lcam","onebillion","nothing","highvalue","lowvalue","1x","2x","3x"};
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
    //if not initialized initialize the console, else de initialize it
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
    //de initialize console
    private void deInitCosole()
    {
        cam.GetComponent<CameraControl>().canMove = true;
        initialized = false;
        input = null;

    }
    //get the input from console
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
    //handle the commands
    private void handleCommand(string _input)
    {
        switch (_input)
        {
            case "fcam":
                print("free cam");
                cam.GetComponent<CameraControl>().restricted = false;
                deInitCosole();
                return;
            case "lcam":
                print("locked cam");
                cam.GetComponent<CameraControl>().restricted = true;
                deInitCosole();
                return;
            case "onebillion":
                print("billionare");
                economy.treasure(1000000000);
                deInitCosole();
                return;
            case "highvalue":
                print("market rise");
                deInitCosole();
                return;
            case "lowvalue":
                print("market drop");
                deInitCosole();
                return;
            case "1x":
                Time.timeScale = 1;
                print("time scale 1");
                deInitCosole();
                return;
            case "2x":
                Time.timeScale = 2;
                print("time scale 2");
                deInitCosole();
                return;
            case "3x":
                Time.timeScale = 3;
                print("time scale 3");
                deInitCosole();
                return;
            case "nothing":
                economy.treasure(-economy.treasure());
                print("nothing at all");
                deInitCosole();
                return;

        }
        
    }

    private void Update()
    {
        getConsoleInput();
    }

}
