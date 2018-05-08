using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {
    float resource;
    public Deposit deposit;


    private void Update()
    {
        this.resource += deposit.resource;
        deposit.resource = 0;
        this.GetComponent<Conveyer>().resource += this.resource;
        this.resource = 0;
    }

}
