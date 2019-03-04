using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollect : MonoBehaviour {

    private EnergyItens energyItens;
    private FoodItens foodItens;
    private AllPoints allPoints;

    public int addEnergy;
    public int addFood;

	void Start () {
        allPoints = GetComponent<AllPoints>();
        energyItens = GameObject.Find("ItensBuyManager").GetComponent<EnergyItens>();
        foodItens = GameObject.Find("ItensBuyManager").GetComponent<FoodItens>();
    }
	
	void Update () {
        addEnergy = energyItens.NumberOfCompany / 2 + energyItens.NumberOfCompany / 4;
        addFood = foodItens.NumberOfCompany / 2 + foodItens.NumberOfCompany / 4;
	}

    public void SendPoints(int days)
    {
        allPoints.Addfood(addFood * days);
        allPoints.AddPower(addEnergy * days);
    }
}
