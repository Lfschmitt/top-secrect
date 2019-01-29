using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePointsController : MonoBehaviour {

    private AllPoints allPoints;
    private TimeController timeController;

    public int technology;
    public int science;
    public int army;
    public int food;
    public int water;
    public int population;
    public int nature;
    public int energy;

    public int eachDays;
    public int totalDays;

	void Start () {
        allPoints = GetComponent<AllPoints>();
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        totalDays = timeController.totalDays + eachDays;
	}
	
	// Update is called once per frame
	void Update () {
		if(totalDays <= timeController.totalDays)
        {
            RemovePoints();
            totalDays += eachDays;
        }
	}

    void RemovePoints()
    {
        allPoints.technology -= technology;
        allPoints.science -= science;
        allPoints.army -= army;
        allPoints.food -= food;
        allPoints.water -= water;
        allPoints.population -= population;
        allPoints.nature -= nature;
        allPoints.power -= energy;
    }
}
