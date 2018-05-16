using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {
    float resource;
    public Deposit deposit;
    Conveyer conveyer;
    private void Start()
    {
        this.name = "Collector";
        conveyer = this.GetComponent<Conveyer>();
    }

    private void Update()
    {
        //get resources from the deposit
        this.resource += deposit.resource;
        deposit.resource = 0;
        conveyer.resource += this.resource;
        this.resource = 0;
    }

}
