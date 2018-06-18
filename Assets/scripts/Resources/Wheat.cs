using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat :Resource {

    public Wheat()
    {
        //set recipe for next 'tier' of resource
        this.recipe(new Recipe(this, null, null, new Bread(), .4f));
    }
	
}
