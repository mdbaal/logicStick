using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : Resource
{
    public Iron()
    {
        //set recipe for next 'tier' of resource
        this.recipe(new Recipe(this, new Wood(), null, new Tools(),.3f));
    }
}
   
