using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPoints : MonoBehaviour {
    public int maxValue;
    public int minValue;
    public int technology;
    public int science;
    public int army;
    public int food;
    public int water;
    public int population;
    public int power;
    public int nature;
    public int money;

    public void AddTechnology (int more)
    {
        technology += more;
    }
    public void AddScience(int more)
    {
        science += more;
    }
    public void AddArmy(int more)
    {
        army += more;
    }
    public void Addfood(int more)
    {
        food += more;
    }
    public void AddWater(int more)
    {
        water += more;
    }
    public void AddPopulation(int more)
    {
        population += more;
    }
    public void AddPower(int more)
    {
        power += more;
    }
    public void AddNature(int more)
    {
        nature += more;
    }
    public void AddMoney(int more)
    {
        money += more;
    }

    public void Update()
    {
        if (technology > maxValue)
            technology = maxValue;
        else if (science > maxValue)
            science = maxValue;
        else if (army > maxValue)
            army = maxValue;
        else if (food > maxValue)
            food = maxValue;
        else if (water > maxValue)
            water = maxValue;
        else if (population > maxValue)
            population = maxValue;
        else if (nature > maxValue)
            nature = maxValue;
        else if (power > maxValue)
            power = maxValue;

        if (technology < minValue)
            technology = minValue;
        else if (science < minValue)
            science = minValue;
        else if (army < minValue)
            army = minValue;
        else if (food < minValue)
            food = minValue;
        else if (water < minValue)
            water = minValue;
        else if (population < minValue)
            population = minValue;
        else if (nature < minValue)
            nature = minValue;
        else if (power < minValue)
            power = minValue;
    } 
}