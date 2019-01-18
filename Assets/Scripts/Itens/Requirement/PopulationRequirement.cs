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
            requirement = "Need Energy";
        }
        else if (allPoints.nature + population.afectNature < 0)
        {
            requirement = "Need Nature";
        }
        else if (allPoints.food + population.afectFood < 0)
        {
            requirement = "Need Food";
        }
        else if (allPoints.water + population.afectWater < 0)
        {
            requirement = "Need water";
        }
        else if (allPoints.army + population.afectArmy < 0)
        {
            requirement = "Need Army";
        }
        else
        {
            requirement = "";
        }
    }
}
