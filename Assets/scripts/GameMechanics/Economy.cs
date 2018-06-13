using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Economy : MonoBehaviour {
    private int roads = 0;
    private int factories = 0;
    private int collectors = 0;

   private float timer = 10f;

    private float _treasure;
    private float _income = 0;
    private float _buildCosts = 0;
    private float _maintenance = 0;
    private float _revenue;

    private Game game;

    public Text moneyText;
    public Text incomeText;

    private void Start()
    {
        game = this.GetComponent<Game>();
        _treasure = 1000;
        timer = 10f;
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
        timer -= Time.deltaTime;
        //calculate the maintenance and income
        _maintenance = roads * 2 + factories * 2 + collectors * 2;
        _income = -_maintenance + -_buildCosts + _revenue;
        //when timer is done, calculate new treasury
        if (timer <= 0)
        {
            _treasure += _income;
            _buildCosts = 0;
            _revenue = 0;
            timer = 10f;
        }
        moneyText.text = "treasure: " + _treasure;
        incomeText.text = "income: " + _income;
    }
}
