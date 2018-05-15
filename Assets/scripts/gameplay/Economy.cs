using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Economy : MonoBehaviour {
    private int roads = 0;
    private int factories = 0;
    private int collectors = 0;

   private float timer = 10f;

    public int treasure;
    public int income = 0;
    public int buildCosts = 0;
    public int maintenance = 0;
    public int revenue;

    Game game;

    public Text moneyText;
    public Text incomeText;

    private void Start()
    {
        game = this.GetComponent<Game>();
        treasure = 100000000;
        timer = 10f;
    }

    //
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
    public int collector()
    {
        return collectors;
    }

    private void Update()
    {
        
        maintenance = roads * 2 + factories * 2 + collectors * 2;
        game.updateEconomy();
        timer -= Time.deltaTime;
        income = -maintenance + -buildCosts + revenue;

        if (timer <= 0)
        {
            treasure += income;
            buildCosts = 0;
            revenue = 0;
            timer = 10f;
        }
        moneyText.text = "treasure: " + treasure;
        incomeText.text = "income: " + income;
    }
}
