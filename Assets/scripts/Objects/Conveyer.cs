using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour {
    public int length = 1;
    public float resource = 0;
    private float count = 0;
    public float transferPercentage = 1f;

    public Conveyer receiver;
    private City recCity;
    
    //send resources to receiver
    public void send()
    {
        if (receiver == null) return;
        
        if(resource <= 0 || resource - resource * transferPercentage < 0)
        {
            resource = 0;
            return;
        }
        //transfer resources to the receiver, if its a city, calulate profit
        receiver.resource += (Mathf.RoundToInt(this.resource * transferPercentage));
        if (recCity != null) recCity.profit((Mathf.RoundToInt(this.resource * transferPercentage)));
        this.resource -= this.resource * transferPercentage;
    }

    

    private void Update()
    {
        //if recCity isn't known yet, get it
        if (recCity == null && receiver != null)
        {
            if (receiver.gameObject.name == "City")
            {
                recCity = receiver.GetComponent<City>();
            }
        }
        count -= Time.deltaTime;
        if(count <= 0)
        {
            send();
            count = length * .1f * length;
        }
    }

}
