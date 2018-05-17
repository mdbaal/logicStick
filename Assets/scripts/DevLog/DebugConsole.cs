using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour {
    [SerializeField]
    private bool initialized = false;
    private string[] commands = {"fcam","lcam","onebillion","highvalue","lowvalue"};
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

    void initConsole()
    {
        if (initialized)
        {
            deInitCosole();
            return;
        }
        initialized = true;

    }
    void deInitCosole()
    {
        initialized = false;
        input = null;

    }
    void getConsoleInput()
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
    void handleCommand(string _input)
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
                economy.treasure = 1000000000;
                return;
            case "highvalue":
                print("market rise");
                return;
            case "lowvalue":
                print("market drop");
                return;
        }
    }

    private void Update()
    {
        getConsoleInput();
    }

}
