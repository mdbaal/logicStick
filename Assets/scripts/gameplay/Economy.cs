using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy : MonoBehaviour {

   private int roads;
   private int factories;
   private int collectors;
   private int cities;
    //
    public void city(int _cities)
    {
        cities = _cities;
    }
    public int city()
    {
        return cities;
    }
    //
    public void road(int _roads)
    {
        roads = _roads;
    }
    public int road()
    {
        return roads;
    }
    //
    public void factory(int _factories)
    {
        factories = _factories;
    }
    public int factory()
    {
        return factories;
    }
    //
    public void collector(int _collectors)
    {
        collectors = _collectors;
    }
    public int collector()
    {
        return collectors;
    }
}
