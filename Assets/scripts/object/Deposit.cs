using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour {
    public float generationPercentage = 1f;
    float generationRate = 1;
    public float resource;

    void Update () {
        generationRate = Mathf.RoundToInt(generationRate * generationPercentage);

        resource += generationRate;
	}
}
