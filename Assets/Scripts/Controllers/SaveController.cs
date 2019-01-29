using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
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
        }
        else if (name == "Load")
        {
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

        PlayerPrefs.SetInt("Days", timeController.totalDays);

        PlayerPrefs.SetInt("TechnologyNumberOfCompany", technology.NumberOfCompany);
        PlayerPrefs.SetInt("TechnologyNumberOfUpgrade", technology.NumberOfUpgrades);
        PlayerPrefs.SetInt("ScienceNumberOfCompany", science.NumberOfCompany);
        PlayerPrefs.SetInt("ScienceNumberOfUpgrade", science.NumberOfUpgrades);
        PlayerPrefs.SetInt("ArmyNumberOfCompany", army.NumberOfCompany);
        PlayerPrefs.SetInt("ArmyNumberOfUpgrade", army.NumberOfUpgrades);
        PlayerPrefs.SetInt("FoodNumberOfCompany", food.NumberOfCompany);
        PlayerPrefs.SetInt("FoodNumberOfUpgrade", food.NumberOfUpgrades);
        PlayerPrefs.SetInt("WaterNumberOfCompany", water.NumberOfCompany);
        PlayerPrefs.SetInt("WaterNumberOfUpgrade", water.NumberOfUpgrades);
        PlayerPrefs.SetInt("PopulationNumberOfCompany", population.NumberOfCompany);
        PlayerPrefs.SetInt("PopulationNumberOfUpgrade", population.NumberOfUpgrades);
        PlayerPrefs.SetInt("NatureNumberOfCompany", nature.NumberOfCompany);
        PlayerPrefs.SetInt("NatureNumberOfUpgrade", nature.NumberOfUpgrades);
        PlayerPrefs.SetInt("EnergyNumberOfCompany", energy.NumberOfCompany);
        PlayerPrefs.SetInt("EnregyNumberOfUpgrade", energy.NumberOfUpgrades);

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

        timeController.totalDays = PlayerPrefs.GetInt("Days");

        technology.NumberOfCompany = PlayerPrefs.GetInt("TechnologyNumberOfCompany");
        technology.NumberOfUpgrades =  PlayerPrefs.GetInt("TechnologyNumberOfUpgrade");
        science.NumberOfCompany = PlayerPrefs.GetInt("ScienceNumberOfCompany");
        science.NumberOfUpgrades = PlayerPrefs.GetInt("ScienceNumberOfUpgrade");
        army.NumberOfCompany = PlayerPrefs.GetInt("ArmyNumberOfCompany");
        army.NumberOfUpgrades = PlayerPrefs.GetInt("ArmyNumberOfUpgrade");
        food.NumberOfCompany = PlayerPrefs.GetInt("FoodNumberOfCompany");
        food.NumberOfUpgrades = PlayerPrefs.GetInt("FoodNumberOfUpgrade");
        water.NumberOfCompany = PlayerPrefs.GetInt("WaterNumberOfCompany");
        water.NumberOfUpgrades = PlayerPrefs.GetInt("WaterNumberOfUpgrade");
        population.NumberOfCompany = PlayerPrefs.GetInt("PopulationNumberOfCompany");
        population.NumberOfUpgrades = PlayerPrefs.GetInt("PopulationNumberOfUpgrade");
        nature.NumberOfCompany = PlayerPrefs.GetInt("NatureNumberOfCompany");
        nature.NumberOfUpgrades = PlayerPrefs.GetInt("NatureNumberOfUpgrade");
        energy.NumberOfCompany = PlayerPrefs.GetInt("EnergyNumberOfCompany");
        energy.NumberOfUpgrades = PlayerPrefs.GetInt("EnregyNumberOfUpgrade");

        randonDestroy.destroy1 = PlayerPrefs.GetInt("Destroy1");
        randonDestroy.destroy2 = PlayerPrefs.GetInt("Destroy2");
        randonDestroy.destroy3 = PlayerPrefs.GetInt("Destroy3");
        randonDestroy.destroy4 = PlayerPrefs.GetInt("Destroy4");
        randonDestroy.destroy5 = PlayerPrefs.GetInt("Destroy5");
        randonDestroy.destroy6 = PlayerPrefs.GetInt("Destroy6");
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public void ResetData()
    {
        allPoints.technology = 0;
        allPoints.science = 0;
        allPoints.army = 0;
        allPoints.food = allPoints.maxValue / 10;
        allPoints.water = allPoints.maxValue;
        allPoints.population = allPoints.maxValue / 10;
        allPoints.power = 0;       
        allPoints.nature = allPoints.maxValue;
        allPoints.money = allPoints.maxValue / 10;

        timeController.SetDays(0);

        technology.CompanyValue = technology.SetCompanyValue;
        technology.UpgradeValue = technology.SetUpgradeValue;
        technology.NumberOfCompany = 0;
        technology.NumberOfUpgrades = 0;
        science.CompanyValue = science.SetCompanyValue;
        science.UpgradeValue = science.SetUpgradeValue;
        science.NumberOfCompany = 0;
        science.NumberOfUpgrades = 0;
        army.CompanyValue = army.SetCompanyValue;
        army.UpgradeValue = army.SetUpgradeValue;
        army.NumberOfCompany = 0;
        army.NumberOfUpgrades = 0;
        food.CompanyValue = food.SetCompanyValue;
        food.UpgradeValue = food.SetUpgradeValue;
        food.NumberOfCompany = 0;
        food.NumberOfUpgrades = 0;
        water.CompanyValue = water.SetCompanyValue;
        water.UpgradeValue = water.SetUpgradeValue;
        water.NumberOfCompany = 0;
        water.NumberOfUpgrades = 0;
        population.CompanyValue = population.SetCompanyValue;
        population.UpgradeValue = population.SetUpgradeValue;
        population.NumberOfCompany = 0;
        population.NumberOfUpgrades = 0;
        nature.CompanyValue = nature.SetCompanyValue;
        nature.UpgradeValue = nature.SetUpgradeValue;
        nature.NumberOfCompany = 0;
        nature.NumberOfUpgrades = 0;
        energy.CompanyValue = energy.SetCompanyValue;
        energy.UpgradeValue = energy.SetUpgradeValue;
        energy.NumberOfCompany = 0;
        energy.NumberOfUpgrades = 0;

        worldController.ResetWorld();

        removePoints.totalDays = timeController.totalDays + removePoints.eachDays;
        randonDestroy.LotteryNumbers();
    }
}
