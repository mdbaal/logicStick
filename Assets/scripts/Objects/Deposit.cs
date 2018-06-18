using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour {
    public float generationPercentage = 1f;
    private float generationRate = .3f;
    private float timer = .5f;
    private Resource[] resources = { new Ore(), new Wood(),new Water(),new Coal(),new Wheat()};
    public Resource resource;


    private void Start()
    {
        SpriteRenderer r = this.GetComponent<SpriteRenderer>();
       int i =  Random.Range(0, resources.Length);
        resource = resources[i];
        if(resource == resources[0])
        {
            r.color = Color.grey;
        }
        if(resource == resources[1])
        {
            r.color = Color.cyan;
        }
        if (resource == resources[2])
        {
            r.color = Color.blue;
        }
        if (resource == resources[3])
        {
            r.color = Color.black;
        }
        if (resource == resources[4])
        {
            r.color = Color.yellow;
        }





        this.name = "Deposit";
    }
    //generate resources
    private void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            resource.amount(generationRate * generationPercentage);
            timer = .5f;
        }
        
    }
}
