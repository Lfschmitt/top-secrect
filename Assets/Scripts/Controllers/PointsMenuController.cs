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

    public Image Tec;
    public Image Sci;
    public Image Army;
    public Image Food;
    public Image Water;
    public Image Pop;
    public Image Power;
    public Image Nat;

    public Sprite[] spritesPoints;

    public AllPoints allPoints;

    void Update () {
        ReadValues();
        WriteValues();
	}

    void ReadValues(){
        /*********  TECHNOLOGY  ********/
        if (allPoints.technology >= 950)
            tec = 10;
        else
            tec = allPoints.technology / 100;
        /*********  SCIENCE  ********/
        if (allPoints.science >= 950)
            sci = 10;
        else
            sci = allPoints.science / 100;
        /*********  ARMY  ********/
        if (allPoints.army >= 950)
            army = 10;
        else
            army = allPoints.army / 100;
        /*********  FOOD  ********/
        if (allPoints.food >= 950)
            food = 10;
        else
            food = allPoints.food / 100;
        /*********  WATER  ********/
        if (allPoints.water >= 950)
            water = 10;
        else
            water = allPoints.water / 100;
        /*********  POPULATION  ********/
        if (allPoints.population >= 950)
            pop = 10;
        else
            pop = allPoints.population / 100;
        /*********  POWER  ********/
        if (allPoints.power >= 950)
            power = 10;
        else
            power = allPoints.power / 100;
        /*********  NATURE  ********/
        if (allPoints.nature >= 950)
            nat = 10;
        else
            nat = allPoints.nature / 100;
    }

    void WriteValues()
    {
        Tec.sprite = spritesPoints[tec];
        Sci.sprite = spritesPoints[sci];
        Army.sprite = spritesPoints[army];
        Food.sprite = spritesPoints[food];
        Water.sprite = spritesPoints[water];
        Pop.sprite = spritesPoints[pop];
        Power.sprite = spritesPoints[power];
        Nat.sprite = spritesPoints[nat];
    }
}
