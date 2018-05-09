using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour {
    public float generationPercentage = 1f;
    float generationRate = .3f;
    public float resource;
    private void Start()
    {
        this.name = "Deposit";
    }

    void Update () {
        resource += generationRate * generationPercentage;
        resource = Mathf.CeilToInt(resource);
    }
}
