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

    public int getProfit()
    {
        int prof = Mathf.RoundToInt(resource);
        resource = 0;
        return prof;
    }

}
