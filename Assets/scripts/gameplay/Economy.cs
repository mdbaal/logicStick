using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Economy : MonoBehaviour {

   private int roads = 0;
   private int factories = 0;
   private int collectors = 0;
   private float timer = 10f;

    public float currency = Mathf.Infinity;
    public int costs = 0;
    public int buildCosts = 0;
    public int maintenance = 0;
    public Text text;



    //
    public void road(int _roads)
    {
        roads += _roads;
    }
    public int road()
    {
        return roads;
    }
    //
    public void factory(int _factories)
    {
        factories += _factories;
    }
    public int factory()
    {
        return factories;
    }
    //
    public void collector(int _collectors)
    {
        collectors += _collectors;
    }
    public int collector()
    {
        return collectors;
    }
   

    private void Update()
    {
        

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            maintenance = roads * 2 + factories * 2 + collectors * 2;
            costs = maintenance + buildCosts;
            currency -= costs;
            buildCosts = 0;
            timer = 10f;
        }
        text.text = "Currency: " + currency + " Costs: " + costs;
    }
}
