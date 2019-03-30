using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsLimitController : MonoBehaviour {

    private AllPoints allPoints;

	void Start () {
        allPoints = GetComponent<AllPoints>();	
	}
	
	// Update is called once per frame
	void Update () {
        //Caso os pontos de tecnologia forem mairoes que o limite ele na ficara maior
        if (allPoints.technology > allPoints.technologyLimit)
            allPoints.technology = allPoints.technologyLimit;
        //Caso os pontos de ciencia forem mairoes que o limite ele na ficara maior
        if (allPoints.science > allPoints.scienceLimit)
            allPoints.science = allPoints.scienceLimit;
        //Caso os pontos de exercito forem mairoes que o limite ele na ficara maior
        if (allPoints.army > allPoints.armyLimit)
            allPoints.army = allPoints.armyLimit;
        //Caso os pontos de populaçao forem mairoes que o limite ele na ficara maior
        if (allPoints.population > allPoints.populationLimit)
            allPoints.population = allPoints.populationLimit;
        //Caso os pontos de energia forem mairoes que o limite ele na ficara maior
        if (allPoints.power > allPoints.powerLimit)
            allPoints.power = allPoints.powerLimit;
        //Caso os pontos de comida forem mairoes que o limite ele na ficara maior
        if (allPoints.food > allPoints.foodLimit)
            allPoints.food = allPoints.foodLimit;
    }
}
