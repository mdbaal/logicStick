using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {
    private Conveyer conveyer;
    private float timer = 2f;

    private Resource resource1;
    private Resource resource2;
    private Resource resource3;

    private Recipe recipe;

    private Resource output;

    private void Start()
    {
        conveyer = this.GetComponent<Conveyer>();
        this.name = "Factory";
    }

    private void Update()
    {
        if (recipe == null && resource1 != null) checkRecipe();
        //every 2 seconds double resources
        timer -= Time.deltaTime;
        if (timer <= 0)
        { 
            timer = 2f;
            craftResources();
            
        }
        if (conveyer.resource == null) conveyer.resource = output;

        if (conveyer.resource != null && output != null && output.amount() > 20) toConveyer();
        
    }
    //create output resource from input
    void craftResources()
    {
        if (recipe == null) return;
        if (resource1.GetType() != recipe.resource1.GetType() || recipe.resource1 == null)
        {
            recipe = null;
            checkRecipe();
            return;
        }
        //craft according to the size of the recipe
        

        switch (recipe.size)
        {
            case 1:
                output = recipe.output;
                output.amount(resource1.amount() * recipe.convertRatio);
                resource1.amount(-resource1.amount() * recipe.convertRatio);
                break;
            case 2:
                output = recipe.output;
                output.amount(resource1.amount() * recipe.convertRatio + resource2.amount() * recipe.convertRatio);
                resource1.amount(-resource1.amount() * recipe.convertRatio);
                resource2.amount(-resource2.amount() * recipe.convertRatio);
                break;

            case 3:
                output = recipe.output;
                output.amount(resource1.amount() * recipe.convertRatio + resource2.amount() * recipe.convertRatio + resource3.amount() * recipe.convertRatio);
                resource1.amount(-resource1.amount() * recipe.convertRatio);
                resource2.amount(-resource2.amount() * recipe.convertRatio);
                resource3.amount(-resource3.amount() * recipe.convertRatio);
                break;
        }
          
    }
    //check if there is a recipe for the current input resources
    private void checkRecipe()
    {
       if(resource1.recipe().resource2 != null)
        {
            if (resource2.GetType() == resource1.recipe().resource2.GetType())
            {
                if(resource1.recipe().resource3 != null)
                {
                    if(resource3 == resource1.recipe().resource3)
                    {
                        recipe = resource1.recipe();
                        recipe.size = 3;
                    }
                }
                else
                {
                    recipe = resource1.recipe();
                    recipe.size = 2;
                }
            }
        }
        else
        {
            recipe = resource1.recipe();
            recipe.size = 1;
        }
    }

    public void receive(Resource r,float amount)
    {
        if (resource1 == null)
        {
            resource1 = r;
        }
        else if(resource2 == null)
        {
            resource2 = r;
        }
        else if(resource3 == null)
        {
            resource3 = r;
        }

        if(resource1.GetType() == r.GetType())
        {
            resource1.amount(amount);
            return;
        }
        else if (resource2.GetType() == r.GetType())
        {
            resource2.amount(amount);
            return;
        }
        else if (resource3.GetType() == r.GetType())
        {
            resource3.amount(amount);
            return;
        }

        if (resource1.GetType() != r.GetType())
        {
            resource1 = r;
            resource1.amount(amount);
        }
        else if (resource2.GetType() != r.GetType())
        {
            resource2 = r;
            resource2.amount(amount);
        }
        else if (resource3.GetType() != r.GetType())
        {
            resource3 = r;
            resource3.amount(amount);
        }
    }

    public void toConveyer()
    {
        if (conveyer.resource.GetType() == output.GetType())
        {
            conveyer.resource.amount(output.amount());
            output.amount(-output.amount());
        }
        else
        {
            conveyer.resource = output;
            output.amount(-output.amount());
        }
    }
}