using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour {
    public int length = 1;
    public float resource = 0;
    public float count;
    public float transferPercentage = 1f;

    public Conveyer receiver;
    private City recCity;
    

    public void send()
    {
        if (receiver == null) return;
        
        if(resource <= 0 || resource - resource * transferPercentage < 0)
        {
            resource = 0;
            return;
        }
        receiver.resource += (Mathf.RoundToInt(this.resource * transferPercentage));
        this.resource -= this.resource * transferPercentage;
    }

    

    private void Update()
    {
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
            count = 2f;
        }
    }

}
