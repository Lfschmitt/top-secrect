using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceRequirement : MonoBehaviour {

    private ScienceItens science;
    private AllPoints allPoints;
    public string requirement = "";

    void Start()
    {
        science = GameObject.Find("ItensBuyManager").GetComponent<ScienceItens>();
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    public void Update()
    {
        if (allPoints.power + science.afectEnergy < 0)
        {
            requirement = "You Need Buy Energy";
        }
        else if (allPoints.population + science.afectPopulation < 0)
        {
            requirement = "You Need Buy Population";
        }
        else
        {
            requirement = "";
        }
    }
}
