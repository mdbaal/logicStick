using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {
    protected float _amount = 0;
    protected Recipe _recipe;
    protected float _price = 0;

    public float amount()
    {
        return this._amount;
    }
    public void amount(float f)
    {
        this._amount += f;
    }
    public float price()
    {
        return this._price;
    }
    public void price(float f)
    {
        this._price = f;
    }
    public void setAmount(float f)
    {
        this._amount = f;
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
