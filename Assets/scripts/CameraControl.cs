using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    void Update () {
        if (Input.GetAxis("Horizontal") < 0)
        {
            cam.transform.Translate(new Vector3(-5f * Time.deltaTime, 0, 0));
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            cam.transform.Translate(new Vector3(5f * Time.deltaTime, 0, 0));
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            cam.transform.Translate(new Vector3(0, -5f * Time.deltaTime,0));
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            cam.transform.Translate(new Vector3(0, 5f * Time.deltaTime,0));
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f) 
        {
            cam.orthographicSize += Input.GetAxis("Mouse ScrollWheel");
        }
    }
}
