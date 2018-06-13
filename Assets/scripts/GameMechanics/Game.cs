using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField]
    private int size;
    private int cityAmount;
    private int depositAmount;

    public GameObject city;
    public GameObject deposit;

    private Economy economy;

    private GameObject[] cities;
    private GameObject[] deposits;

    private void Start () {
        //if the world size is lower then 10 do nothing
        if (size < 10) return;
        //get the amount of things to generate
        cityAmount = Mathf.FloorToInt(size / 5);
        depositAmount = Mathf.FloorToInt(size / 3);
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

    public int getSize()
    {
        return this.size;
    }
   

}
