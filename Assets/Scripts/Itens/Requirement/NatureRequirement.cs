using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureRequirement : MonoBehaviour {

    private NatureItens nature;
    private AllPoints allPoints;
    public string requirement = "";

    void Start()
    {
        nature = GameObject.Find("ItensBuyManager").GetComponent<NatureItens>();
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    public void Update()
    {
        if (allPoints.power + nature.afectWater < 0)
        {
            requirement = "Need Water";
        }
        else if (allPoints.population + nature.afectPopulation < 0)
        {
            requirement = "Need Population";
        }
        else
        {
            requirement = "";
        }
    }
}
