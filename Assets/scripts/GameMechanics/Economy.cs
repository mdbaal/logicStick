using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Economy : MonoBehaviour {
    private int roads = 0;
    private int factories = 0;
    private int collectors = 0;

    private float timer = 20f;

    private bool newMarket = true;

    private float _treasure;
    private float _income = 0;

    public Resource[] resources = { new Iron(),  new Water(), new Coal(),new Furniture(), new Tools(), new Bread() };

    public Dictionary<string, float> resourceValues = new Dictionary<string, float>();

    private float _buildCosts = 0;

    public float _roadCost = 2;
    public float _factoryCost = 20;
    public float _collectorCost = 15;

    private float _maintenance = 0;

    private float _roadMaintenance =2;
    private float _factoryMaintenance = 5;
    private float _collectorMaintenance = 3;

    private float _revenue;

    private Game game;

    public Text moneyText;
    public Text incomeText;

    private void Start()
    {
        game = this.GetComponent<Game>();
        _treasure = 1000;
        timer = 20f;

        resourceValues.Add("Iron", 18);
        resourceValues.Add("Water", 9);
        resourceValues.Add("Coal", 25);
        resourceValues.Add("Furniture", 20);
        resourceValues.Add("Tools", 13);
        resourceValues.Add("Bread", 6);

    }

    //getters/setters for all important values of the economy
    public void road(int _roads)
    {
        roads += _roads;
    }
    public int road()
    {
        return roads;
    }
    //
    public void factory(int _factories)
    {
        factories += _factories;
    }
    public int factory()
    {
        return factories;
    }
    //
    public void collector(int _collectors)
    {
        collectors += _collectors;
    }
    //
    public int collector()
    {
        return collectors;
    }
    //
    public float treasure()
    {
        return _treasure;
    }
    public void treasure(float value)
    {
         _treasure += value;
    }
    //
    public float buildCosts()
    {
        return _buildCosts;
    }
    public void buildCosts(float value)
    {
        _buildCosts += value;
    }
    //
    public float revenue()
    {
        return _revenue;
    }
    public void revenue(float value)
    {
        _revenue += value;
    }
    private void Update()
    {
        if (newMarket)
        {
            calculateMarket(resources[0], 0);
            newMarket = false;
        }
        timer -= Time.deltaTime;
        //calculate the maintenance and income
        _maintenance = roads * _roadMaintenance + factories * _factoryMaintenance + collectors * _collectorMaintenance;
        _income = -_maintenance + -_buildCosts + _revenue;
        //when timer is done, calculate new treasury
        if (timer <= 0)
        {
            if (_treasure <= 0) game.gameOver();
            _treasure += _income;
            _buildCosts = 0;
            _revenue = 0;
            timer = 10f;
        }
        moneyText.text = "treasure: " + _treasure;
        incomeText.text = "income: " + _income;
    }

    private void calculateMarket(Resource r, int index)
    {
        if (r == null) return;
        float valueMod;
        int citiesFreq = 0;
        int depositFreq = 0;
        int factoryFreq = 0;

        for(int i = 0; i < game.cities.Length; i++)
        {
            for(int j = 0;j < game.cities[i].GetComponent<City>().acceptList.Count;j++)
            {
                if (game.cities[i].GetComponent<City>().acceptList[j].GetType() == r.GetType()) citiesFreq ++;
            }
        }

        for (int i = 0; i < game.deposits.Length; i++)
        {
            if (game.deposits[i].GetType() == r.GetType()) depositFreq++;
        }

        foreach(Factory R in GameObject.FindObjectsOfType<Factory>())
        {
            if (R.output.GetType() == r.GetType()) factoryFreq++;
        }

        if (citiesFreq == 0 || depositFreq == 0 || factoryFreq == 0) valueMod = 1; else valueMod = citiesFreq / depositFreq / factoryFreq;

        if (citiesFreq > depositFreq && citiesFreq > factoryFreq)
        {
            resourceValues[r.ToString()] = resourceValues[r.ToString()] * (1 + valueMod);
        }
        else
        {
            resourceValues[r.ToString()] = resourceValues[r.ToString()] * valueMod;
        }

        print(r + " " + resourceValues[r.ToString()]);

        try
        {
            calculateMarket(resources[index + 1], index + 1);
        }catch(System.IndexOutOfRangeException e)
        {

        }
    }
}
