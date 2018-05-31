using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {
    public Resource resource1;
    public Resource resource2;
    public Resource resource3;

    public Resource output;

    public float convertRatio = 1;

    public int size = 0;

    //set recipe for resource, with input resources, output resource and a convertion ratio for the input to output
    public Recipe(Resource _resource1, Resource _resource2, Resource _resource3, Resource _ouput,float _convertRatio)
    {
        this.resource1 = _resource1;
        this.resource2 = _resource2;
        this.resource3 = _resource3;
        this.output = _ouput;
        this.convertRatio = _convertRatio;
    }
    public bool equalsInput(Recipe _recipe)
    {
        if (this.resource1 == _recipe.resource1)
        {
            if (this.resource2 == _recipe.resource2)
            {
                if (this.resource3 == _recipe.resource3)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool equals( Recipe _recipe)
    {
        if (this == _recipe) return true;
        return false;
    }
}
