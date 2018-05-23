using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    
    public float resource;

    private void Start()
    {
        this.name = "City";
    }
    //add profit made to the revenue
    public void profit(int _profit)
    {
        this.GetComponentInParent<Economy>().revenue(_profit);
    }
}
