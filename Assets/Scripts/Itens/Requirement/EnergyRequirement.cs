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

        if (allPoints.population + energy.afectPopulation < 0)
        {
            requirement = "You Need Buy Population";
        }
        else
        {
            requirement = "";
        }
    }
}
