﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour {

    private AllPoints allPoints;
    private RandonDestroy randonDestroy;
    private RemovePointsController removePoints;
    private TimeController timeController;
    private TechnologyItens technology;
    private ScienceItens science;
    private ArmyItens army;
    private FoodItens food;
    private WaterItens water;
    private PopulationsItens population;
    private NatureItens nature;
    private EnergyItens energy;
    private WorldController worldController;

    private int music;
    private int sound;
    private float difficult;

    void Start()
    {
        //Debug.Log(PlayerPrefs.GetFloat("Difficult"));
        allPoints = GetComponent<AllPoints>();
        randonDestroy = GetComponent<RandonDestroy>();
        removePoints = GetComponent<RemovePointsController>();
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        if (timeController == null)
            Debug.Log("The object 'TimeController' not find in scene");

        worldController = GameObject.Find("LevelManager").GetComponent<WorldController>();
        if (worldController == null)
            Debug.Log("The object 'LevelManager' not find in scene");
        
        technology = GameObject.Find("ItensBuyManager").GetComponent<TechnologyItens>();
        science = GameObject.Find("ItensBuyManager").GetComponent<ScienceItens>();
        army = GameObject.Find("ItensBuyManager").GetComponent<ArmyItens>();
        food = GameObject.Find("ItensBuyManager").GetComponent<FoodItens>();
        water = GameObject.Find("ItensBuyManager").GetComponent<WaterItens>();
        population = GameObject.Find("ItensBuyManager").GetComponent<PopulationsItens>();
        nature = GameObject.Find("ItensBuyManager").GetComponent<NatureItens>();
        energy = GameObject.Find("ItensBuyManager").GetComponent<EnergyItens>();

        if(PlayerPrefs.GetInt("NewGame") == 1)
        {
            randonDestroy.LotteryNumbers();
            SavePrefabs("Save");
            DeleteData();
            ResetData();
            SavePrefabs("Load");
            SaveData();
        }
        else
        {
            LoadData();
        }
    }

    private void SavePrefabs(string name)
    {
        if (name == "Save")
        {
            music = PlayerPrefs.GetInt("Music");
            sound = PlayerPrefs.GetInt("Sound");
            difficult = PlayerPrefs.GetFloat("Difficult");
        }
        else if (name == "Load")
        {
            PlayerPrefs.SetFloat("Difficult", difficult);
            PlayerPrefs.SetInt("Music", music);
            PlayerPrefs.SetInt("Sound", sound);
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("SaveGame", 1);
        PlayerPrefs.SetInt("Technology", allPoints.technology);
        PlayerPrefs.SetInt("Science", allPoints.science);
        PlayerPrefs.SetInt("Army", allPoints.army);
        PlayerPrefs.SetInt("Food", allPoints.food);
        PlayerPrefs.SetInt("Water", allPoints.water);
        PlayerPrefs.SetInt("Population", allPoints.population);
        PlayerPrefs.SetInt("Power", allPoints.power);
        PlayerPrefs.SetInt("Nature", allPoints.nature);
        PlayerPrefs.SetInt("Money", allPoints.money);

        PlayerPrefs.SetInt("TechnologyLimit", allPoints.technologyLimit);
        PlayerPrefs.SetInt("ScienceLimit", allPoints.scienceLimit);
        PlayerPrefs.SetInt("ArmyLimit", allPoints.armyLimit);
        PlayerPrefs.SetInt("FoodLimit", allPoints.foodLimit);
        PlayerPrefs.SetInt("PopulationLimit", allPoints.populationLimit);
        PlayerPrefs.SetInt("PowerLimit", allPoints.powerLimit);

        PlayerPrefs.SetInt("Days", timeController.totalDays);

        PlayerPrefs.SetInt("TechnologyNumberOfCompany", technology.NumberOfCompany);
        PlayerPrefs.SetInt("ScienceNumberOfCompany", science.NumberOfCompany);
        PlayerPrefs.SetInt("ArmyNumberOfCompany", army.NumberOfCompany);
        PlayerPrefs.SetInt("FoodNumberOfCompany", food.NumberOfCompany);
        PlayerPrefs.SetInt("WaterNumberOfCompany", water.NumberOfCompany);
        PlayerPrefs.SetInt("PopulationNumberOfCompany", population.NumberOfCompany);
        PlayerPrefs.SetInt("NatureNumberOfCompany", nature.NumberOfCompany);
        PlayerPrefs.SetInt("EnergyNumberOfCompany", energy.NumberOfCompany);

        PlayerPrefs.SetInt("Destroy1", randonDestroy.destroy1);
        PlayerPrefs.SetInt("Destroy2", randonDestroy.destroy2);
        PlayerPrefs.SetInt("Destroy3", randonDestroy.destroy3);
        PlayerPrefs.SetInt("Destroy4", randonDestroy.destroy4);
        PlayerPrefs.SetInt("Destroy5", randonDestroy.destroy5);
        PlayerPrefs.SetInt("Destroy6", randonDestroy.destroy6);
    }

    public void LoadData()
    {
        allPoints.technology = PlayerPrefs.GetInt("Technology");
        allPoints.science = PlayerPrefs.GetInt("Science");
        allPoints.army = PlayerPrefs.GetInt("Army");
        allPoints.food = PlayerPrefs.GetInt("Food");
        allPoints.water = PlayerPrefs.GetInt("Water");
        allPoints.population = PlayerPrefs.GetInt("Population");
        allPoints.power = PlayerPrefs.GetInt("Power");
        allPoints.nature = PlayerPrefs.GetInt("Nature");
        allPoints.money = PlayerPrefs.GetInt("Money");

        allPoints.technologyLimit = PlayerPrefs.GetInt("TechnologyLimit");
        allPoints.scienceLimit = PlayerPrefs.GetInt("ScienceLimit");
        allPoints.armyLimit = PlayerPrefs.GetInt("ArmyLimit");
        allPoints.foodLimit = PlayerPrefs.GetInt("FoodLimit");
        allPoints.populationLimit = PlayerPrefs.GetInt("PopulationLimit");
        allPoints.powerLimit = PlayerPrefs.GetInt("PowerLimit");

        timeController.totalDays = PlayerPrefs.GetInt("Days");

        technology.NumberOfCompany = PlayerPrefs.GetInt("TechnologyNumberOfCompany");
        science.NumberOfCompany = PlayerPrefs.GetInt("ScienceNumberOfCompany");
        army.NumberOfCompany = PlayerPrefs.GetInt("ArmyNumberOfCompany");
        food.NumberOfCompany = PlayerPrefs.GetInt("FoodNumberOfCompany");
        water.NumberOfCompany = PlayerPrefs.GetInt("WaterNumberOfCompany");
        population.NumberOfCompany = PlayerPrefs.GetInt("PopulationNumberOfCompany");
        nature.NumberOfCompany = PlayerPrefs.GetInt("NatureNumberOfCompany");
        energy.NumberOfCompany = PlayerPrefs.GetInt("EnergyNumberOfCompany");

        technology.CompanyValue = PlayerPrefs.GetInt("TechnologyCompanieValue");
        science.CompanyValue = PlayerPrefs.GetInt("ScienceCompanieValue");
        population.CompanyValue = PlayerPrefs.GetInt("PopulationCompanieValue");
        army.CompanyValue = PlayerPrefs.GetInt("ArmyCompanieValue");
        food.CompanyValue = PlayerPrefs.GetInt("FoodCompanieValue");
        water.CompanyValue = PlayerPrefs.GetInt("WaterCompanieValue");
        energy.CompanyValue = PlayerPrefs.GetInt("EnergyCompanieValue");
        nature.CompanyValue = PlayerPrefs.GetInt("NatureCompanieValue");

        randonDestroy.destroy1 = PlayerPrefs.GetInt("Destroy1");
        randonDestroy.destroy2 = PlayerPrefs.GetInt("Destroy2");
        randonDestroy.destroy3 = PlayerPrefs.GetInt("Destroy3");
        randonDestroy.destroy4 = PlayerPrefs.GetInt("Destroy4");
        randonDestroy.destroy5 = PlayerPrefs.GetInt("Destroy5");
        randonDestroy.destroy6 = PlayerPrefs.GetInt("Destroy6");
    }

    public void DeleteData()
    {
        SavePrefabs("Save");
        PlayerPrefs.DeleteAll();
        SavePrefabs("Load");
    }
    
    public void ResetData()
    {
        allPoints.technology = 0;
        allPoints.science = 0;
        allPoints.army = allPoints.maxValue / 10;
        allPoints.food = allPoints.maxValue / 10;
        allPoints.water = allPoints.maxValue;
        allPoints.population = allPoints.maxValue / 10;
        allPoints.power = allPoints.maxValue / 20;       
        allPoints.nature = allPoints.maxValue;
        allPoints.money = allPoints.maxValue / 10;

        allPoints.technologyLimit = 0;
        allPoints.scienceLimit = 0;
        allPoints.armyLimit = allPoints.maxValue / 10;
        allPoints.foodLimit = allPoints.maxValue / 10;
        allPoints.populationLimit = allPoints.maxValue / 10;
        allPoints.powerLimit = allPoints.maxValue / 20;

        timeController.SetDays(0);

        technology.CompanyValue = technology.SetCompanyValue;
        technology.NumberOfCompany = 0;
        science.CompanyValue = science.SetCompanyValue;
        science.NumberOfCompany = 0;
        army.CompanyValue = army.SetCompanyValue;
        army.NumberOfCompany = 0;
        food.CompanyValue = food.SetCompanyValue;
        food.NumberOfCompany = 0;
        water.CompanyValue = water.SetCompanyValue;
        water.NumberOfCompany = 0;
        population.CompanyValue = population.SetCompanyValue;
        population.NumberOfCompany = 0;
        nature.CompanyValue = nature.SetCompanyValue;
        nature.NumberOfCompany = 0;
        energy.CompanyValue = energy.SetCompanyValue;
        energy.NumberOfCompany = 0;

        removePoints.totalDays = timeController.totalDays + removePoints.eachDays;
        randonDestroy.LotteryNumbers();

        timeController.GameTime(false);
    }
}
