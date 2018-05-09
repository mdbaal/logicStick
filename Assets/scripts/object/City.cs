using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    Conveyer conveyer;
    public float resource;

    private void Start()
    {
        conveyer = this.GetComponent<Conveyer>();
        this.name = "City";
    }

    private void Update()
    {
        this.resource += conveyer.resource;
        conveyer.resource = 0;
    }

}
