using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    [SerializeField]
    private int _size;
    private int cityAmount;
    private int depositAmount;

    public GameObject city;
    public GameObject deposit;

    public GameObject gameOverScreen;

    private Economy economy;

    public GameObject[] cities;
    public GameObject[] deposits;

    private void Start () {
        //if the world _size is lower then 10 do nothing
        if (_size < 10) return;
        //get the amount of things to generate
        cityAmount = Mathf.FloorToInt(_size / 5);
        depositAmount = Mathf.FloorToInt(_size / 3);
        cities = new GameObject[cityAmount];
        deposits = new GameObject[depositAmount];
        economy = this.GetComponent<Economy>();

        Vector3 spawnPos;
        //spawn cities
        for(int i = 0;i < cityAmount; i++)
        {
           spawnPos = new Vector3(Random.Range(0, _size - 1), Random.Range(0, _size - 1), 1);
           
           cities[i] = Instantiate(city, spawnPos, Quaternion.identity, this.transform);
        }
        //spawn deposits
        for (int i = 0; i < depositAmount; i++)
        {
            spawnPos = new Vector3(Random.Range(0, _size - 1), Random.Range(0, _size - 1), 1);

            deposits[i] = Instantiate(deposit, spawnPos, Quaternion.identity, this.transform);
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0;

        gameOverScreen.SetActive(true);
    }

    public void size(int i)
    {
        this._size = i;
    }

    public int size()
    {
        return this._size;
    }

   

}
