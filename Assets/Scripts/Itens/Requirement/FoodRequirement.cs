using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRequirement : MonoBehaviour {

    private FoodItens food;
    private AllPoints allPoints;
    public string requirement = "";

    void Start()
    {
        food = GameObject.Find("ItensBuyManager").GetComponent<FoodItens>();
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    public void Update()
    {
        if (allPoints.power + food.afectEnergy < 0)
        {
            requirement = "You Need Buy Energy";
        }
        else if (allPoints.population + food.afectPopulation < 0)
        {
            requirement = "You Need Buy Population";
        }
        else
        {
            requirement = "";
        }
    }
}
