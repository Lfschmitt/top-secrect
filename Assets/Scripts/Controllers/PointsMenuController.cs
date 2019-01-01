using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsMenuController : MonoBehaviour {

    private int tec;
    private int sci;
    private int army;
    private int food;
    private int water;
    private int pop;
    private int power;
    private int nat;

    public Text Tec;
    public Text Sci;
    public Text Army;
    public Text Food;
    public Text Water;
    public Text Pop;
    public Text Power;
    public Text Nat;

    public AllPoints allPoints;

    void Update () {
        ReadValues();
        WriteValues();
	}

    void ReadValues(){
        tec = allPoints.technology;
        sci = allPoints.science;
        army = allPoints.army;
        food = allPoints.food;
        water = allPoints.water;
        pop = allPoints.population;
        power = allPoints.power;
        nat = allPoints.nature;
    }

    void WriteValues()
    {
        Tec.text = tec.ToString();
        Sci.text = sci.ToString();
        Army.text = army.ToString();
        Food.text = food.ToString();
        Water.text = water.ToString();
        Pop.text = pop.ToString();
        Power.text = power.ToString();
        Nat.text = nat.ToString();
    }
}
