using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollect : MonoBehaviour {

    private TechnologyItens technologyItens;
    private ScienceItens scienceItens;
    private ArmyItens armyItens;
    private PopulationsItens populationsItens;
    private WaterItens waterItens;
    private EnergyItens energyItens;
    private NatureItens natureItens;
    private FoodItens foodItens;

    private AllPoints allPoints;

    //Variavel que define a cada quantos pontos de limit a produçao aumenta em 1
    public int pointsLimitForProduction;

    public int addTechnology;
    public int addScience;
    public int addArmy;
    public int addPopulation;
    public int addWater;
    public int addFood;
    public int addEnergy;
    public int addNature;
    public float difficult;
    void Start () {
        allPoints = GetComponent<AllPoints>();

        technologyItens = GameObject.Find("ItensBuyManager").GetComponent<TechnologyItens>();
        scienceItens = GameObject.Find("ItensBuyManager").GetComponent<ScienceItens>();
        armyItens = GameObject.Find("ItensBuyManager").GetComponent<ArmyItens>();
        populationsItens = GameObject.Find("ItensBuyManager").GetComponent<PopulationsItens>();
        energyItens = GameObject.Find("ItensBuyManager").GetComponent<EnergyItens>();
        foodItens = GameObject.Find("ItensBuyManager").GetComponent<FoodItens>();
        natureItens = GameObject.Find("ItensBuyManager").GetComponent<NatureItens>();
        waterItens = GameObject.Find("ItensBuyManager").GetComponent<WaterItens>();
    }
	
	void Update () {
        difficult = PlayerPrefs.GetFloat("Difficult");
        addTechnology = (int)((technologyItens.NumberOfCompany / pointsLimitForProduction)/ PlayerPrefs.GetFloat("Difficult"));
        addScience = (int)((scienceItens.NumberOfCompany / pointsLimitForProduction)/ PlayerPrefs.GetFloat("Difficult"));
        addArmy = (int)((armyItens.NumberOfCompany / pointsLimitForProduction)/ PlayerPrefs.GetFloat("Difficult"));
        addPopulation = (int)((populationsItens.NumberOfCompany / pointsLimitForProduction)/ PlayerPrefs.GetFloat("Difficult"));
        addWater = (int)((waterItens.NumberOfCompany / pointsLimitForProduction)/ PlayerPrefs.GetFloat("Difficult"));
        addFood = (int)((foodItens.NumberOfCompany / pointsLimitForProduction)/ PlayerPrefs.GetFloat("Difficult"));
        addEnergy = (int)((energyItens.NumberOfCompany / pointsLimitForProduction)/ PlayerPrefs.GetFloat("Difficult"));
        addNature = (int)((natureItens.NumberOfCompany / pointsLimitForProduction)/ PlayerPrefs.GetFloat("Difficult"));
    }
    
    
    public void SendPoints(int days)
    {
      
        allPoints.AddTechnology(addTechnology * days);
        allPoints.AddScience(addScience * days);
        allPoints.AddArmy(addArmy * days);
        allPoints.AddPopulation(addPopulation * days);
        allPoints.AddNature(addNature * days);
        allPoints.AddPower(addEnergy * days);
        allPoints.Addfood(addFood * days);
        allPoints.AddWater(addWater * days);
      
    }
}
