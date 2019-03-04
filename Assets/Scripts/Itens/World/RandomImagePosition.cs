using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImagePosition : MonoBehaviour {

    public FrontItens frontItens;
    public BackItens backItens;
    public ImagesOfPlanet images;

    private Population pop;
    private Energy energy;

    private void Start()
    {
        pop = GetComponent<Population>();
        energy = GetComponent<Energy>();

        //if was randomized the numbers just load their 
        if (PlayerPrefs.GetInt("FrontGroundSpawnPosition0") > 0 || PlayerPrefs.GetInt("FrontGroundSpawnPosition1") > 0)
            LoadNumbers();
        //else wasn't randomize new numbers
        else
        {
            RandomizeGroundNumbers();
            RandomizeWaterNumbers();
            SavaNumbers();
        }
        //Put the random itens on te scripts
        RandomizePositions();
    }

    //Use This For Save all random numbers
    void SavaNumbers()
    {
        //Save Number of front of the ground of the planet 
        for (int x = 0; x < frontItens.frontGroundNumbers.Length; x++)
        {
            PlayerPrefs.SetInt("FrontGroundSpawnPosition" + x, frontItens.frontGroundNumbers[x]);
        }

        //Save Number of back of the ground of the planet 
        for (int x = 0; x < backItens.backGroundNumbers.Length; x++)
        {
            PlayerPrefs.SetInt("BackGroundSpawnPosition" + x, backItens.backGroundNumbers[x]);
        }

        //Save Number of front of the water of the planet 
        for (int x = 0; x < frontItens.frontWaterNumbers.Length; x++)
        {
            PlayerPrefs.SetInt("FrontWaterSpawnPosition" + x, frontItens.frontWaterNumbers[x]);
        }

        //Save Number of back of the water of the planet
        for (int x = 0; x < backItens.backWaterNumbers.Length; x++)
        {
            PlayerPrefs.SetInt("BackWaterSpawnPosition" + x, backItens.backWaterNumbers[x]);
        }
    }
    //Use This For Load all random numbers
    void LoadNumbers()
    {
        //Load Number of front of the ground of the planet 
        for (int x = 0; x < frontItens.frontGroundNumbers.Length; x++)
        {
            frontItens.frontGroundNumbers[x] = PlayerPrefs.GetInt("FrontGroundSpawnPosition" + x);
        }

        //Load Number of back of the ground of the planet 
        for (int x = 0; x < backItens.backGroundNumbers.Length; x++)
        {
            backItens.backGroundNumbers[x] = PlayerPrefs.GetInt("BackGroundSpawnPosition" + x);
        }

        //Load Number of front of the water of the planet 
        for (int x = 0; x < frontItens.frontWaterNumbers.Length; x++)
        {
            frontItens.frontWaterNumbers[x] = PlayerPrefs.GetInt("FrontWaterSpawnPosition" + x);
        }

        //Load Number of back of the water of the planet
        for (int x = 0; x < backItens.backWaterNumbers.Length; x++)
        {
            backItens.backWaterNumbers[x] = PlayerPrefs.GetInt("BackWaterSpawnPosition" + x);
        }
    }

    //Use This for randomize ground numbers
    void RandomizeGroundNumbers()
    {
        int lastNumber;

        //Randomize FrontGroundNumber
        for (int y = 0; y < frontItens.frontGroundNumbers.Length; y++)
        {
            lastNumber = Random.Range(0, frontItens.frontGroundNumbers.Length + 1);

            for(int x = 0; x < frontItens.frontGroundNumbers.Length; x++)
            {
                if(frontItens.frontGroundNumbers[x] == lastNumber)
                {
                    while(frontItens.frontGroundNumbers[x] == lastNumber)
                    {
                        lastNumber = Random.Range(0, frontItens.frontGroundNumbers.Length + 1);
                    }
                    x = -1;
                }else if (x == frontItens.frontGroundNumbers.Length - 1)
                    frontItens.frontGroundNumbers[y] = lastNumber;
            }
        }

        //Randomize BackGroundNumber
        for (int y = 0; y < backItens.backGroundNumbers.Length; y++)
        {
            lastNumber = Random.Range(0, backItens.backGroundNumbers.Length + 1);

            for (int x = 0; x < backItens.backGroundNumbers.Length; x++)
            {
                if (backItens.backGroundNumbers[x] == lastNumber)
                {
                    while (backItens.backGroundNumbers[x] == lastNumber)
                    {
                        lastNumber = Random.Range(0, backItens.backGroundNumbers.Length + 1);
                    }
                    x = -1;
                }
                else if (x == backItens.backGroundNumbers.Length - 1)
                    backItens.backGroundNumbers[y] = lastNumber;
            }
        }
    }

    //Use This for randomize water numbers
    void RandomizeWaterNumbers()
    {
        int lastNumber;

        //Randomize FrontWaterNumber
        for (int y = 0; y < frontItens.frontWaterNumbers.Length; y++)
        {
            lastNumber = Random.Range(0, frontItens.frontWaterNumbers.Length + 1);

            for (int x = 0; x < frontItens.frontWaterNumbers.Length; x++)
            {
                if (frontItens.frontWaterNumbers[x] == lastNumber)
                {
                    while (frontItens.frontWaterNumbers[x] == lastNumber)
                    {
                        lastNumber = Random.Range(0, frontItens.frontWaterNumbers.Length + 1);
                    }
                    x = -1;
                }
                else if (x == frontItens.frontWaterNumbers.Length - 1)
                    frontItens.frontWaterNumbers[y] = lastNumber;
            }
        }

        //Randomize BackWaterNumber
        for (int y = 0; y < backItens.backWaterNumbers.Length; y++)
        {
            lastNumber = Random.Range(0, backItens.backWaterNumbers.Length + 1);

            for (int x = 0; x < backItens.backWaterNumbers.Length; x++)
            {
                if (backItens.backWaterNumbers[x] == lastNumber)
                {
                    while (backItens.backWaterNumbers[x] == lastNumber)
                    {
                        lastNumber = Random.Range(0, backItens.backWaterNumbers.Length + 1);
                    }
                    x = -1;
                }
                else if (x == backItens.backWaterNumbers.Length - 1)
                    backItens.backWaterNumbers[y] = lastNumber;
            }
        }
    }

    public void RandomizePositions()
    {
        /*__-__-__-__-__-__-__-__-__-__-__-__-  POPULATION  -__-__-__-__-__-__-__-__-__-__-__-__-*/

        //Load day gameobjects of POPULATION 
        pop.world.dayGameobjects[0] = frontItens.FrontGroundDayGameObjects[frontItens.frontGroundNumbers[0] - 1];
        pop.world.dayGameobjects[1] = frontItens.FrontGroundDayGameObjects[frontItens.frontGroundNumbers[1] - 1];
        pop.world.dayGameobjects[2] = backItens.BackGroundDayGameObjects[backItens.backGroundNumbers[0] - 1];
        //Load night gameobjects of POPULATION 
        pop.world.nightGameobject[0] = frontItens.FrontGroundNightGameObjects[frontItens.frontGroundNumbers[0] - 1];
        pop.world.nightGameobject[1] = frontItens.FrontGroundNightGameObjects[frontItens.frontGroundNumbers[1] - 1];
        pop.world.nightGameobject[2] = backItens.BackGroundNightGameObjects[backItens.backGroundNumbers[0] - 1];
         
        //Load day images of POPULATION
        pop.world.dayImages[0] = images.GroundDayImage[frontItens.frontGroundNumbers[0] - 1];
        pop.world.dayImages[1] = images.GroundDayImage[frontItens.frontGroundNumbers[1] - 1];
        pop.world.dayImages[2] = images.GroundDayImage[(backItens.backGroundNumbers[0] + frontItens.frontGroundNumbers.Length) - 1];
        //Load Night images of POPULATION
        pop.world.nightImages[0] = images.GroundNightImage[frontItens.frontGroundNumbers[0] - 1];
        pop.world.nightImages[1] = images.GroundNightImage[frontItens.frontGroundNumbers[1] - 1];
        pop.world.nightImages[2] = images.GroundNightImage[(backItens.backGroundNumbers[0] + frontItens.frontGroundNumbers.Length) - 1];

        /*__-__-__-__-__-__-__-__-__-__-__-__-  ENERGY  -__-__-__-__-__-__-__-__-__-__-__-__-*/

        //Load day gameobjects of ENERGY 
        energy.world.dayGameobjects[0] = frontItens.FrontGroundDayGameObjects[frontItens.frontGroundNumbers[2] - 1];
        energy.world.dayGameobjects[1] = backItens.BackGroundDayGameObjects[backItens.backGroundNumbers[1] - 1];
        energy.world.dayGameobjects[2] = backItens.BackGroundDayGameObjects[backItens.backGroundNumbers[2] - 1];
        //Load day gameobject of water of ENERGY
        energy.world.dayGameobjects[3] = frontItens.FrontWaterDayGameObjects[frontItens.frontWaterNumbers[0] - 1];

        //Load night gameobjects of ENERGY 
        energy.world.nightGameobject[0] = frontItens.FrontGroundNightGameObjects[frontItens.frontGroundNumbers[2] - 1];
        energy.world.nightGameobject[1] = backItens.BackGroundNightGameObjects[backItens.backGroundNumbers[1] - 1];
        energy.world.nightGameobject[2] = backItens.BackGroundNightGameObjects[backItens.backGroundNumbers[2] - 1];
        //Load night gameobject of water of ENERGY
        energy.world.nightGameobject[3] = frontItens.FrontWaterNightGameObjects[frontItens.frontWaterNumbers[0] - 1];

        //Load day images of ENERGY
        energy.world.dayImages[0] = images.GroundDayImage[frontItens.frontGroundNumbers[2] - 1];
        energy.world.dayImages[1] = images.GroundDayImage[(backItens.backGroundNumbers[1] + frontItens.frontGroundNumbers.Length) - 1];
        energy.world.dayImages[2] = images.GroundDayImage[(backItens.backGroundNumbers[2] + frontItens.frontGroundNumbers.Length) - 1];
        energy.world.dayImages[3] = images.WaterDayImage[frontItens.frontWaterNumbers[0] - 1];

        //Load Night images of ENERGY
        energy.world.nightImages[0] = images.GroundNightImage[frontItens.frontGroundNumbers[2] - 1];
        energy.world.nightImages[1] = images.GroundNightImage[(backItens.backGroundNumbers[1] + frontItens.frontGroundNumbers.Length) - 1];
        energy.world.nightImages[2] = images.GroundNightImage[(backItens.backGroundNumbers[2] + frontItens.frontGroundNumbers.Length) - 1];
        energy.world.nightImages[3] = images.WaterNightImage[frontItens.frontWaterNumbers[0] - 1];
    }
}

[System.Serializable]
public class FrontItens {
    public GameObject[] FrontGroundDayGameObjects;
    public GameObject[] FrontGroundNightGameObjects;
    public GameObject[] FrontWaterDayGameObjects;
    public GameObject[] FrontWaterNightGameObjects;
    public int[] frontGroundNumbers;
    public int[] frontWaterNumbers;
}

[System.Serializable]
public class BackItens {
    public GameObject[] BackGroundDayGameObjects;
    public GameObject[] BackGroundNightGameObjects;
    public GameObject[] BackWaterDayGameObjects;
    public GameObject[] BackWaterNightGameObjects;
    public int[] backGroundNumbers;
    public int[] backWaterNumbers;
}

[System.Serializable]
public class ImagesOfPlanet
{
    public Image[] GroundDayImage;
    public Image[] GroundNightImage;
    public Image[] WaterDayImage;
    public Image[] WaterNightImage;
}