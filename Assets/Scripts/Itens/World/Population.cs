using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    public UpdateWorld world;
    public int[] minPointsForUpdate;

    private int image1, image2, image3;
    private bool boolean = true;
    private AllPoints allPoints;
    private NightController nightController;

    void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        nightController = GameObject.Find("TimeController").GetComponent<NightController>();    
    }

    void Update()
    {
        ReadLevel();
        ActiveBuilds();
        ActiveLights(!nightController.day);
    }

    void ReadLevel()
    {
        if (allPoints.population > minPointsForUpdate[0])
        {
            image2 = 1;
            if (allPoints.population > minPointsForUpdate[1])
            {
                image3 = 1;
                if (allPoints.population > minPointsForUpdate[2])
                {
                    image1 = 2;
                    if (allPoints.population > minPointsForUpdate[3])
                    {
                        image2 = 2;
                        if (allPoints.population > minPointsForUpdate[4])
                        {
                            image3 = 2;
                            if (allPoints.population > minPointsForUpdate[5])
                            {
                                image1 = 3;
                                if (allPoints.population > minPointsForUpdate[6])
                                {
                                    image2 = 3;
                                    if (allPoints.population > minPointsForUpdate[7])
                                    {
                                        image3 = 3;
                                        if (allPoints.population > minPointsForUpdate[8])
                                        {
                                            image1 = 4;
                                            if (allPoints.population > minPointsForUpdate[9])
                                            {
                                                image2 = 4;
                                                if (allPoints.population > minPointsForUpdate[10])
                                                {
                                                    image3 = 4;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("PopulationFirstBuy") == 0)
                image1 = 0;
            image2 = 0;
            image3 = 0;
        }
    }

    void ActiveBuilds()
    {
        if (image1 > 0 && boolean)
            world.dayGameobjects[0].SetActive(true);
        else
            world.dayGameobjects[0].SetActive(false);

        if (image2 > 0 && boolean)
            world.dayGameobjects[1].SetActive(true);
        else
            world.dayGameobjects[1].SetActive(false);

        if (image3 > 0 && !boolean)
            world.dayGameobjects[2].SetActive(true);
        else
            world.dayGameobjects[2].SetActive(false);

        world.dayImages[0].sprite = world.levelDaySprites[image1];
        world.dayImages[1].sprite = world.levelDaySprites[image2];
        world.dayImages[2].sprite = world.levelDaySprites[image3];
    }

    void ActiveLights(bool active)
    {
        if (image1 > 0 && boolean && active)
            world.nightGameobject[0].SetActive(true);
        else
            world.nightGameobject[0].SetActive(false);

        if (image2 > 0 && boolean && active)
            world.nightGameobject[1].SetActive(true);
        else
            world.nightGameobject[1].SetActive(false);

        if (image3 > 0 && !boolean && active)
            world.nightGameobject[2].SetActive(true);
        else
            world.nightGameobject[2].SetActive(false);

        world.nightImages[0].sprite = world.levelNightSprites[image1];
        world.nightImages[1].sprite = world.levelNightSprites[image2];
        world.nightImages[2].sprite = world.levelNightSprites[image3];
    }

    public void ChangeWorld(bool active)
    {
        boolean = active;
    }

    public void FirstBuy()
    {
        if (PlayerPrefs.GetInt("PopulationFirstBuy") == 0)
        {
            image1 = 1;
            PlayerPrefs.SetInt("PopulationFirstBuy", 1);
        }
    }
}

