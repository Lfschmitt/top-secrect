﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Science : MonoBehaviour
{
    public UpdateWorld world;
    public int[] minPointsForUpdate;

    private int image1, image2, image3, image4;
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
        if (allPoints.science > minPointsForUpdate[0])
        {
            image2 = 2;
            if (allPoints.science > minPointsForUpdate[1])
            {
                image3 = 1;
                if (allPoints.science > minPointsForUpdate[2])
                {
                    image1 = 3;
                    if (allPoints.science > minPointsForUpdate[3])
                    {
                        image4 = 1;
                        if (allPoints.science > minPointsForUpdate[4])
                        {
                            image2 = 3;
                        }
                    }
                }
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("ScienceFirstBuy") == 0)
                image1 = 0;
            image2 = 0;
            image3 = 0;
            image4 = 0;
        }
    }

    void ActiveBuilds()
    {
        if (image1 > 0 && boolean)
            world.dayGameobjects[0].SetActive(true);
        else
            world.dayGameobjects[0].SetActive(false);

        if (image2 > 0 && !boolean)
            world.dayGameobjects[1].SetActive(true);
        else
            world.dayGameobjects[1].SetActive(false);

        if (image3 > 0 && !boolean)
            world.dayGameobjects[2].SetActive(true);
        else
            world.dayGameobjects[2].SetActive(false);

        if (image4 > 0 && boolean)
            world.dayGameobjects[3].SetActive(true);
        else
            world.dayGameobjects[3].SetActive(false);

        world.dayImages[0].sprite = world.levelDaySprites[image1];
        world.dayImages[1].sprite = world.levelDaySprites[image2];
        world.dayImages[2].sprite = world.levelDaySprites[image3];
        world.dayImages[3].sprite = world.levelDaySprites[image4];
    }

    void ActiveLights(bool active)
    {
        if (image1 > 0 && boolean && active)
            world.nightGameobject[0].SetActive(true);
        else
            world.nightGameobject[0].SetActive(false);

        if (image2 > 0 && !boolean && active)
            world.nightGameobject[1].SetActive(true);
        else
            world.nightGameobject[1].SetActive(false);

        if (image3 > 0 && !boolean && active)
            world.nightGameobject[2].SetActive(true);
        else
            world.nightGameobject[2].SetActive(false);

        if (image4 > 0 && boolean && active)
            world.nightGameobject[3].SetActive(true);
        else
            world.nightGameobject[3].SetActive(false);

        world.nightImages[0].sprite = world.levelNightSprites[image1];
        world.nightImages[1].sprite = world.levelNightSprites[image2];
        world.nightImages[2].sprite = world.levelNightSprites[image3];
        world.nightImages[3].sprite = world.levelNightSprites[image4];
    }

    public void ChangeWorld(bool active)
    {
        boolean = active;
    }

    public void FirstBuy()
    {
        if (PlayerPrefs.GetInt("ScienceFirstBuy") == 0)
        {
            image1 = 2;
            PlayerPrefs.SetInt("ScienceFirstBuy", 1);
        }
    }
}
