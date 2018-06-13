using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {
    public Deposit deposit;
    private Conveyer conveyer;
    private float timer = 5f;
    private void Start()
    {
        this.name = "Collector";
        conveyer = this.GetComponent<Conveyer>();
        conveyer.resource = deposit.resource;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (deposit.resource.amount() > 20)
            {
                //get resources from the deposit
                conveyer.resource.amount(deposit.resource.amount());
                deposit.resource.amount(-deposit.resource.amount());
                timer = 5f;
            }
            
        }
    }

}
