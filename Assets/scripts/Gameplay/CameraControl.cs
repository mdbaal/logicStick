using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    private Camera cam;
    public Game game;
    private void Start()
    {
        cam = Camera.main;
    }
    void Update () {
        moveCamera();
    }
    //move the camera and check the restrictions after and correct if needed
    void moveCamera()
    {
        //left/right
        if (Input.GetAxis("Horizontal") < 0)
        {
            cam.transform.Translate(new Vector3(-5f * Time.deltaTime, 0, 0));
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            cam.transform.Translate(new Vector3(5f * Time.deltaTime, 0, 0));
        }
        //up/down
        if (Input.GetAxis("Vertical") < 0)
        {
            cam.transform.Translate(new Vector3(0, -5f * Time.deltaTime, 0));
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            cam.transform.Translate(new Vector3(0, 5f * Time.deltaTime, 0));
        }
        //zoom
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            cam.orthographicSize += -Input.GetAxis("Mouse ScrollWheel");
        }
        checkRestrictions();
    }
    void checkRestrictions()
    {
        //restrictions
        if (cam.orthographicSize < 2f)
        {
            cam.orthographicSize = 2f;
        }
        else if (cam.orthographicSize > 5f)
        {
            cam.orthographicSize = 5f;
        }
        //left
        if (cam.transform.position.x < 0)
        {
            cam.transform.position = new Vector2(0, transform.position.y);
        }
        //right
        if (cam.transform.position.x > game.size)
        {
            cam.transform.position = new Vector2(game.size, transform.position.y);
        }
        //up
        if (cam.transform.position.y < 0)
        {
            cam.transform.position = new Vector2(transform.position.x, 0);
        }
        //down
        if (cam.transform.position.y > game.size)
        {
            cam.transform.position = new Vector2(transform.position.x, game.size);
        }
    }
}
