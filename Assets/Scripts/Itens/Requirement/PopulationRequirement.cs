using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationRequirement : MonoBehaviour {

    private PopulationsItens population;
    private AllPoints allPoints;
    public string requirement = "";

    void Start()
    {
        population = GameObject.Find("ItensBuyManager").GetComponent<PopulationsItens>();
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    public void Update()
    {
        if (allPoints.power + population.afectEnergy < 0)
        {
            requirement = "You Need Buy Energy";
        }
        else if (allPoints.food + population.afectFood < 0)
        {
            requirement = "You Need Buy Food";
        }
        else if (allPoints.water + population.afectWater < 0)
        {
            requirement = "You Need Buy Water";
        }
        else if (allPoints.army + population.afectArmy < 0)
        {
            requirement = "You Need Buy Army";
        }
        else
        {
            requirement = "";
        }
    }
}
