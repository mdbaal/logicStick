﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public int size;
    int cityAmount;
    int depositAmount;

    public GameObject city;
    public GameObject deposit;

    Economy economy;

    public GameObject[] cities;
    public GameObject[] deposits; 

    void Start () {
        //if the world size is lower then 10 do nothing
        if (size < 10) return;
        //get the amount of things to generate
        cityAmount = Mathf.RoundToInt(size / 5);
        depositAmount = Mathf.RoundToInt(size / 3);
        cities = new GameObject[cityAmount];
        deposits = new GameObject[depositAmount];
        economy = this.GetComponent<Economy>();

        Vector3 spawnPos;
        //spawn cities
        for(int i = 0;i < cityAmount; i++)
        {
           spawnPos = new Vector3(Random.Range(0, size-1), Random.Range(0, size-1), 1);
           
           cities[i] = Instantiate(city, spawnPos, Quaternion.identity, this.transform);
        }
        //spawn deposits
        for (int i = 0; i < depositAmount; i++)
        {
            spawnPos = new Vector3(Random.Range(0, size-1), Random.Range(0, size-1), 1);

            deposits[i] = Instantiate(deposit, spawnPos, Quaternion.identity, this.transform);
        }
    }
   

}
