using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {

    Conveyer conveyer;
    float timer = 2f;

    private void Start()
    {
        conveyer = this.GetComponent<Conveyer>();
        this.name = "Factory";
    }

    private void Update()
    {
        //every 2 secconds double resources
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            conveyer.resource = conveyer.resource * 2f;
            timer = 2f;
        }
    }

}
