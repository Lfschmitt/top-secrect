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
            requirement = "Need Food";
        }
        else if (allPoints.water + army.afectWater< 0)
        {
            requirement = "Need Water";
        }
        else if (allPoints.population + army.afectPopulation < 0)
        {
            requirement = "Need Population";
        }
        else
        {
            requirement = "";
        }
    }
}
