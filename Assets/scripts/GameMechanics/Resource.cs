using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {
    protected float _amount;
   protected Recipe _recipe;

    public float amount()
    {
        return this._amount;
    }
    public void amount(float f)
    {
        this._amount += f;
    }
    public Recipe recipe()
    {
        return this._recipe;
    }
    public void recipe(Recipe r)
    {
        this._recipe = r;
    }

}
