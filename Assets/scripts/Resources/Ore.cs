using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : Resource
{
    public Ore()
    {
        //set recipe for next 'tier' of resource
        this.recipe(new Recipe(this, null, null, new Iron(),.3f));
    }
}
