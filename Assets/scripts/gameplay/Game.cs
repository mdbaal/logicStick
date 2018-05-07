using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public int size;
    int citiesSize;
    public GameObject city;
    Economy economy;
    GameObject[] cities;

    void Start () {
        if (citiesSize <= 0) return;
        citiesSize = size / 5;
        cities = new GameObject[citiesSize];
        economy.city(citiesSize);
        economy = this.gameObject.AddComponent<Economy>();

        Vector3 spawnPos;
        for(int i = 0;i < citiesSize; i++)
        {
           spawnPos = new Vector3(Random.Range(0, size), Random.Range(0, size), 1);

           cities[i] = Instantiate(city, spawnPos, Quaternion.identity, this.transform);
        }
    }

}
