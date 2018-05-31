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
        resource1 = new Ore();
        resource1.amount(100);
        
        conveyer = this.GetComponent<Conveyer>();
        this.name = "Factory";
    }

    private void Update()
    {
        //every 2 seconds double resources
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            conveyer.resource = conveyer.resource * 2f;
            timer = 2f;
        }
        if (resource1 != null) checkRecipe();
        craftResources();
        print(output + " amount:  " + output.amount());
    }
    void craftResources()
    {
        if (recipe == null) return;
        if (resource1.GetType() != recipe.resource1.GetType() || recipe.resource1 == null)
        {
            recipe = null;
            checkRecipe();
            return;
        }

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

}
