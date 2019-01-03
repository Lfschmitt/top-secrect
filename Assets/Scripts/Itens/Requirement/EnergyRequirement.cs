using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRequirement : MonoBehaviour {

    private EnergyItens energy;
    private AllPoints allPoints;
    public string requirement = "";

    void Start()
    {
        energy = GameObject.Find("ItensBuyManager").GetComponent<EnergyItens>();
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    public void Update()
    {
        if (allPoints.nature + energy.afectNature < 0)
        {
            requirement = "Need Nature";
        }
        else if (allPoints.population + energy.afectPopulation < 0)
        {
            requirement = "Need Population";
        }
        else
        {
            requirement = "";
        }
    }
}
