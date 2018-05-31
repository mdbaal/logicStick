using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : Resource
{
    public Ore()
    {
        this.recipe(new Recipe(this, null, null, new Iron(),.3f));
    }
}
