using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsMenuController : MonoBehaviour {

    public Image[] images;
    public Image[] pointsInfoImagens;

    public int[] points;
    public Sprite[] spritesPoints;
    public Sprite[] specialSprites;

    public float transitionTime;
    public bool[] oneTime;
    private AllPoints allPoints;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    void Update () {
        ReadValues();
        WriteInfoPointsValues();
        WriteValues();
        
	}

    void ReadValues(){
        /*********  TECHNOLOGY [0] ********/
        if (allPoints.technology > 900)
            points[0] = 31;
        else
            points[0] = allPoints.technology / 30;

        /*********  SCIENCE [1]  ********/
        if (allPoints.science > 900)
            points[1] = 31;
        else
            points[1] = allPoints.science / 30;

        /*********  POPULATION [2]  ********/
        if (allPoints.population > 900)
            points[2] = 31;
        else
            points[2] = allPoints.population / 30;

        /*********  ARMY [3]  ********/
        if (allPoints.army > 900)
            points[3] = 31;
        else
            points[3] = allPoints.army / 30;

        /*********  WATER [4] ********/
        if (allPoints.water > 900)
            points[4] = 31;
        else
            points[4] = allPoints.water / 30;

        /*********  FOOD [5] ********/
        if (allPoints.food > 900)
            points[5] = 31;
        else
            points[5] = allPoints.food / 31;

        /*********  NATURE [6] ********/
        if (allPoints.nature > 900)
            points[6] = 31;
        else
            points[6] = allPoints.nature / 30;

        /*********  ENERGY [7]  ********/
        if (allPoints.power >= 900)
            points[7] = 31;
        else
            points[7] = allPoints.power / 30;
    }

    void WriteValues()
    {

        /*********  TECHNOLOGY [0] ********/
        if (points[0] == 31)
        {
            if (oneTime[0])
                StartCoroutine(SpecialTec());
        }
        else
            images[0].sprite = spritesPoints[points[0]];

        /*********  SCIENCE [1]  ********/
        if (points[1] == 31)
        {
            if (oneTime[1])
                StartCoroutine(SpecialSci());
        }
        else
            images[1].sprite = spritesPoints[points[1]];

        /*********  POPULATION [2]  ********/
        if (points[2] == 31)
        {
            if (oneTime[2])
                StartCoroutine(SpecialPop());
        }
        else
            images[2].sprite = spritesPoints[points[2]];

        /*********  ARMY [3]  ********/
        if (points[3] == 31)
        {
            if (oneTime[3])
                StartCoroutine(SpecialArmy());
        }
        else
            images[3].sprite = spritesPoints[points[3]];

        /*********  WATER [4] ********/
        if (points[4] == 31)
        {
            if (oneTime[4])
                StartCoroutine(SpecialWater());
        }
        else
            images[4].sprite = spritesPoints[points[4]];

        /*********  FOOD [5] ********/
        if (points[5] == 31)
        {
            if (oneTime[5])
                StartCoroutine(SpecialFood());
        }
        else
            images[5].sprite = spritesPoints[points[5]];

        /*********  NATURE [6] ********/
        if (points[6] == 31)
        {
            if (oneTime[6])
                StartCoroutine(SpecialNature());
        }
        else
            images[6].sprite = spritesPoints[points[6]];

        /*********  ENERGY [7]  ********/
        if (points[7] == 31)
        {
            if (oneTime[7])
                StartCoroutine(SpecialEnergy());
        }
        else
            images[7].sprite = spritesPoints[points[7]];

    }

    void WriteInfoPointsValues()
    {

        /*********  TECHNOLOGY [0] ********/
        pointsInfoImagens[0].sprite = spritesPoints[points[0]];

        /*********  SCIENCE [1]  ********/
        pointsInfoImagens[1].sprite = spritesPoints[points[1]];

        /*********  POPULATION [2]  ********/
        pointsInfoImagens[2].sprite = spritesPoints[points[2]];

        /*********  ARMY [3]  ********/
        pointsInfoImagens[3].sprite = spritesPoints[points[3]];

        /*********  WATER [4] ********/
        pointsInfoImagens[4].sprite = spritesPoints[points[4]];

        /*********  FOOD [5] ********/
        pointsInfoImagens[5].sprite = spritesPoints[points[5]];

        /*********  NATURE [6] ********/
        pointsInfoImagens[6].sprite = spritesPoints[points[6]];

        /*********  ENERGY [7]  ********/
        pointsInfoImagens[7].sprite = spritesPoints[points[7]];

    }
    IEnumerator SpecialTec()
    {
        oneTime[0] = false; 
        for (int x = 0; x < 5; x++)
        {
            images[0].sprite = specialSprites[x];
            yield return new WaitForSeconds(transitionTime);
        }
        oneTime[0] = true;
    }
    IEnumerator SpecialSci()
    {
        oneTime[1] = false;
        for (int x = 0; x < 5; x++)
        {
            images[1].sprite = specialSprites[x];
            yield return new WaitForSeconds(transitionTime);
        }
        oneTime[1] = true;
    }
    IEnumerator SpecialPop()
    {
        oneTime[2] = false;
        for (int x = 0; x < 5; x++)
        {
            images[2].sprite = specialSprites[x];
            yield return new WaitForSeconds(transitionTime);
        }
        oneTime[2] = true;
    }
    IEnumerator SpecialArmy()
    {
        oneTime[3] = false;
        for (int x = 0; x < 5; x++)
        {
            images[3].sprite = specialSprites[x];
            yield return new WaitForSeconds(transitionTime);
        }
        oneTime[3] = true;
    }
    IEnumerator SpecialWater()
    {
        oneTime[4] = false;
        for (int x = 0; x < 5; x++)
        {
            images[4].sprite = specialSprites[x];
            yield return new WaitForSeconds(transitionTime);
        }
        oneTime[4] = true;
    }
    IEnumerator SpecialFood()
    {
        oneTime[5] = false;
        for (int x = 0; x < 5; x++)
        {
            images[5].sprite = specialSprites[x];
            yield return new WaitForSeconds(transitionTime);
        }
        oneTime[5] = true;
    }
    IEnumerator SpecialNature()
    {
        oneTime[6] = false;
        for (int x = 0; x < 5; x++)
        {
            images[6].sprite = specialSprites[x];
            yield return new WaitForSeconds(transitionTime);
        }
        oneTime[6] = true;
    }
    IEnumerator SpecialEnergy()
    {
        oneTime[7] = false;
        for (int x = 0; x < 5; x++)
        {
            images[7].sprite = specialSprites[x];
            yield return new WaitForSeconds(transitionTime);
        }
        oneTime[7] = true;
    }
}
