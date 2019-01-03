using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRequirement : MonoBehaviour {

    private WaterItens water;
    private AllPoints allPoints;
    public string requirement = "";

    void Start()
    {
        water = GameObject.Find("ItensBuyManager").GetComponent<WaterItens>();
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    public void Update()
    {
        if (allPoints.population + water.afectPopulation < 0)
        {
            requirement = "Need Population";
        }
        else
        {
            requirement = "";
        }
    }
}
