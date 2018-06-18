using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Resource
{
    public Wood()
    {
        //set recipe for next 'tier' of resource
        this.recipe(new Recipe(this, null, null, new Furniture(), .2f));
    }
}
   
