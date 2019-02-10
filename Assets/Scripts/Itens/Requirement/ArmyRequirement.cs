using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyRequirement : MonoBehaviour {

    private ArmyItens army;
    private AllPoints allPoints;
    public string requirement = "";

    void Start()
    {
        army = GameObject.Find("ItensBuyManager").GetComponent<ArmyItens>();
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    public void Update()
    {
        if (allPoints.food + army.afectFood < 0)
        {
            requirement = "You Need Buy Food";
        }
        else if (allPoints.water + army.afectWater< 0)
        {
            requirement = "You Need Buy Water";
        }
        else if (allPoints.population + army.afectPopulation < 0)
        {
            requirement = "You Need Buy Population";
        }
        else
        {
            requirement = "";
        }
    }
}
