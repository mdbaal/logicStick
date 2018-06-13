using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour {
    public float generationPercentage = 1f;
    private float generationRate = .3f;
    private float timer = .5f;
    private Resource[] resources = { new Ore(), new Wood() };
    public Resource resource;


    private void Start()
    {
       int i =  Random.Range(0, resources.Length);
        resource = resources[0];
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
