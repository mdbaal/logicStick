using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {
    

    private void Start()
    {
        this.name = "City";
       
    }
    
    //add profit made to the revenue
    public void profit(Resource resource,float amount)
    {
        float profit = 0;
        profit = resource.amount() * resource.price(); 
        this.GetComponentInParent<Economy>().revenue(profit);
        print("profit: " + profit);
    }
    

}
