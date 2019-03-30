using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePointsController : MonoBehaviour {

    private AllPoints allPoints;
    private TimeController timeController;

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
        allPoints.army -= allPoints.population / army;
        allPoints.food -= allPoints.population / food;
        allPoints.water -= allPoints.population / water;
        allPoints.population -= allPoints.population / population;
        allPoints.nature -= allPoints.population / nature;
        allPoints.power -= allPoints.population / energy;
    }
}
