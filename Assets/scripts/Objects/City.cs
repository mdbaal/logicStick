using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    public List<Resource> acceptList = new List<Resource>();
    public Economy economy;


    private void Start()
    {
        this.name = "City";
        economy = GetComponentInParent<Economy>();

        float r;
        for(int i = 0;i < economy.resources.Length; i++)
        {
            r = Random.Range(0, 10);
            if(r < 3f)
            {

                acceptList.Add(economy.resources[i]);
            }
        }
        
    }
    
    //add profit made to the revenue
    public void profit(Resource resource,float amount)
    {
        if(checkAcceptedResource(resource)) return;
        float profit = 0;
        profit = resource.amount() * getPrice(resource) ; 
        this.GetComponentInParent<Economy>().revenue(profit);
    }
    
    private float getPrice(Resource r)
    {
        float price = 0;

        price = economy.resourceValues[r.ToString()];
    
        return price;
    }
    public bool checkAcceptedResource(Resource r)
    {
        for(int i = 0;i < acceptList.Count; i++)
        {
            if (r == acceptList[i]) return true;
        }

        return false;
    }
}
