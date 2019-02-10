using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyRequirement : MonoBehaviour {

    private TechnologyItens technology;
    private AllPoints allPoints;
    public string requirement = "";

	void Start () {
        technology = GameObject.Find("ItensBuyManager").GetComponent<TechnologyItens>();
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

	public void Update () {
        if (allPoints.power + technology.afectEnergy < 0)
        {
            requirement = "You Need Buy Energy";
        }
        else if (allPoints.population + technology.afectPopulation < 0)
        {
            requirement = "You Need Buy Population";
        }
        else
        {
            requirement = "";
        }           
    }
}
