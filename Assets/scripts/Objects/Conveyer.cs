using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour {
    public int length = 1;
    public float transferPercentage = 1f;
    
    public Resource resource;
    
    public Conveyer receiver;

    
    public void send()
    {
        
        float transferAmount = 0;

        if (receiver == null) return;
        if (resource == null) return;
        if (resource.amount() < 0) resource.setAmount(0);

        transferAmount = this.resource.amount() * this.transferPercentage;

        

        if (receiver.GetComponent<City>() != null)
        {
            receiver.GetComponent<City>().profit(resource, transferAmount);
            this.resource.amount(-transferAmount);
        }
        else if (receiver.GetComponent<Factory>() != null)
        {
            receiver.GetComponent<Factory>().receive(resource, transferAmount);
            this.resource.amount(-transferAmount);
        }else if (receiver.resource == null || receiver.resource.GetType() != this.resource.GetType()) {
            receiver.resource = resource;
            receiver.resource.setAmount(0);
            receiver.resource.amount(transferAmount);
            this.resource.amount(-transferAmount);
        } else if (receiver.resource.GetType() == this.resource.GetType())
        {
            receiver.resource.amount(transferAmount);
            this.resource.amount(-transferAmount);
        }
    }

    private void Update()
    {
        if (resource != null)
        {
            if (resource.amount() > 10)
            {
                send();
            }
        }
    }


}
