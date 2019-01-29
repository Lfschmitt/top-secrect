using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{

    private int technologyLevel;
    private int scienceLevel;
    private int natureLevel;
    private int waterLevel;
    private int populationLevel;
    private int energyLevel;

    private AllPoints allPoints;

    public GameObject[] technology;
    public GameObject[] science;
    public GameObject[] population;
    public GameObject[] energy;
    public Sprite[] natureSprites;
    public Sprite[] waterSprites;

    public Image nature;
    public Image water;

    void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    void Update()
    {
        ReadValues();
        CallChanges();
    }

    void ReadValues()
    {
        technologyLevel = allPoints.technology / 100;
        scienceLevel = allPoints.science / 100;
        natureLevel = allPoints.nature / 100;
        waterLevel = allPoints.water / 100;
        populationLevel = allPoints.population / 100;
        energyLevel = allPoints.power / 100;
    }

    void CallChanges()
    {
        ChangeTechnology();
        ChangeScience();
        ChangeWater();
        ChangeNature();
        ChangePopulation();
        ChangeEnergy();
    }

    void ChangeTechnology()
    {
        if(technologyLevel >= 2)
        {
            technology[0].SetActive(true);
            if(technologyLevel >= 5)
            {
                technology[1].SetActive(true);
                if(technologyLevel >= 8)
                {
                    technology[2].SetActive(true);
                }
            }
        }
    }
    void ChangeScience()
    {
        if (scienceLevel >= 1)
        {
            science[0].SetActive(true);
            if (scienceLevel >= 2)
            {
                science[1].SetActive(true);
                if (scienceLevel >= 3)
                {
                    science[2].SetActive(true);
                    if (scienceLevel >= 4)
                    {
                        science[3].SetActive(true);
                        if (scienceLevel >= 6)
                        {
                            science[4].SetActive(true);
                            if (scienceLevel >= 8)
                            {
                                science[5].SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }
    void ChangeWater()
    {
        if(waterLevel >= 0)
        {
            water.sprite = waterSprites[0];
            if(waterLevel >= 1)
            {
                water.sprite = waterSprites[1];
                if(waterLevel >= 4)
                {
                    water.sprite = waterSprites[2];
                    if(waterLevel >= 7)
                    {
                        water.sprite = waterSprites[3];
                    }
                }
            }
        }
    }
    void ChangeNature()
    {
        if (natureLevel >= 0)
        {
            nature.sprite = natureSprites[0];
            if (natureLevel >= 1)
            {
                nature.sprite = natureSprites[1];
                if (natureLevel >= 4)
                {
                    nature.sprite = natureSprites[2];
                    if (natureLevel >= 7)
                    {
                        nature.sprite = natureSprites[3];
                    }
                }
            }
        }
    }
    void ChangePopulation()
    {
        if (populationLevel > 1)
        {
            population[0].SetActive(true);
            if (populationLevel >= 2)
            {
                population[1].SetActive(true);
                if (populationLevel >= 3)
                {
                    population[2].SetActive(true);
                    if (populationLevel >= 4)
                    {
                        population[3].SetActive(true);
                        if (populationLevel >= 6)
                        {
                            population[4].SetActive(true);
                            if (populationLevel >= 8)
                            {
                                population[5].SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }
    void ChangeEnergy()
    {
        if (energyLevel >= 2)
        {
            energy[0].SetActive(true);
            if (energyLevel >= 4)
            {
                energy[1].SetActive(true);
                if (energyLevel >= 6)
                {
                    energy[2].SetActive(true);
                    if(energyLevel >= 8)
                    {
                        energy[3].SetActive(true);
                    }

                }
            }
        }
    }

    public void ResetWorld()
    {
        for (int x = 0; x < energy.Length; x++)
        {
            energy[x].SetActive(false);
        }

        {
            for (int x = 0; x < population.Length; x++)
            {
                population[x].SetActive(false);
            }
        }
        {
            for (int x = 0; x < science.Length; x++)
            {
                science[x].SetActive(false);
            }
        }
        {
            for (int x = 0; x < technology.Length; x++)
            {
                technology[x].SetActive(false);
            }
        }
    }
}