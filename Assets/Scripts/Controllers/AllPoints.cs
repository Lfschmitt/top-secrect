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
    public bool saveOn;
    public bool load;
    public bool deletePrefs;

    public void AddTechnology (int more)
    {
        technology += more;
        SavePoints("Technology", technology);
    }
    public void AddScience(int more)
    {
        science += more;
        SavePoints("Science", science);
    }
    public void AddArmy(int more)
    {
        army += more;
        SavePoints("Army", army);
    }
    public void Addfood(int more)
    {
        food += more;
        SavePoints("Food", food);
    }
    public void AddWater(int more)
    {
        water += more;
        SavePoints("Water", water);
    }
    public void AddPopulation(int more)
    {
        population += more;
        SavePoints("Population", population);
    }
    public void AddPower(int more)
    {
        power += more;
        SavePoints("Power", power);
    }
    public void AddNature(int more)
    {
        nature += more;
        SavePoints("Nature", nature);
    }
    public void AddMoney(int more)
    {
        money += more;
        SavePoints("Money", money);
    }

    public void SavePoints(string name, int points)
    {
        if (saveOn)
        PlayerPrefs.SetInt(name, points);
    }
    public void LoadPoints()
    {
        technology = PlayerPrefs.GetInt("Technology");
        science = PlayerPrefs.GetInt("Science");
        army = PlayerPrefs.GetInt("Army");
        food = PlayerPrefs.GetInt("Food");
        water = PlayerPrefs.GetInt("Water");
        population = PlayerPrefs.GetInt("Population");
        power = PlayerPrefs.GetInt("Power");
        nature = PlayerPrefs.GetInt("Nature");
        money = PlayerPrefs.GetInt("Money");
    }
    public void DeletePoints()
    {
        PlayerPrefs.DeleteAll();
        technology = 0;
        science = 0;
        army = 0;
        food = maxValue/10;
        water = maxValue/2;
        population = maxValue/10;
        power = 0;
        money = maxValue/10;
        nature = maxValue;
    }
    public void ResetGame() {
        DeletePoints();
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

        if (load)
        {
            LoadPoints();
            load = !load;
        }
        if (deletePrefs)
        {
            DeletePoints();
            deletePrefs = !deletePrefs;
        }
    } 
}