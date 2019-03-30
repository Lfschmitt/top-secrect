using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoShopPageController : MonoBehaviour {

    public GameObject page1, nextButton;
    public GameObject page2, backButton;
    public Text nextPageText;
    public Text description, addMoney, addPoint, companeis; 

    private ShopManager shop;

    private PointsCollect pointsCollect;
    private TechnologyItens technology;
    private ScienceItens science;
    private ArmyItens army;
    private FoodItens food;
    private WaterItens water;
    private PopulationsItens population;
    private NatureItens nature;
    private EnergyItens energy;

    private void Start()
    {
        shop = GetComponent<ShopManager>();

        pointsCollect = GameObject.Find("PointsController").GetComponent<PointsCollect>();

        technology = GameObject.Find("ItensBuyManager").GetComponent<TechnologyItens>();
        science = GameObject.Find("ItensBuyManager").GetComponent<ScienceItens>();
        army = GameObject.Find("ItensBuyManager").GetComponent<ArmyItens>();
        food = GameObject.Find("ItensBuyManager").GetComponent<FoodItens>();
        water = GameObject.Find("ItensBuyManager").GetComponent<WaterItens>();
        population = GameObject.Find("ItensBuyManager").GetComponent<PopulationsItens>();
        nature = GameObject.Find("ItensBuyManager").GetComponent<NatureItens>();
        energy = GameObject.Find("ItensBuyManager").GetComponent<EnergyItens>();
    }
    
    public void InfoPanel(int numberOfItem)
    {
        if (numberOfItem == 0)
        {
            description.text = shop.descriptions[numberOfItem];
            companeis.text = "Companies " + (technology.NumberOfCompany);
            addMoney.text = "Money Per Day " + (technology.TotalMoney);
            addPoint.text = "Eletronics Per Day " + (pointsCollect.addTechnology);
        }
        else if (numberOfItem == 1)
        {
            description.text = shop.descriptions[numberOfItem];
            companeis.text = "Labs " + (science.NumberOfCompany);
            addMoney.text = "Money Per Day " + (science.TotalMoney);
            addPoint.text = "Researchs Per Day " + (pointsCollect.addScience);
        }
        else if (numberOfItem == 2)
        {
            description.text = shop.descriptions[numberOfItem];
            companeis.text = "Houses " + (energy.NumberOfCompany);
            addMoney.text = "Money Per Day " + (population.TotalMoney);
            addPoint.text = "People Per Day " + (pointsCollect.addPopulation);
        }
        else if (numberOfItem == 3)
        {
            description.text = shop.descriptions[numberOfItem];
            companeis.text = "Barracks " + (army.NumberOfCompany);
            addMoney.text = "Money Per Day " + (army.TotalMoney);
            addPoint.text = "Soldiers Per Day " + (pointsCollect.addArmy);
        }
        else if (numberOfItem == 4)
        {
            description.text = shop.descriptions[numberOfItem];
            companeis.text = "Rivers " + (water.NumberOfCompany);
            addMoney.text = "Money Per Day " + (water.TotalMoney);
            addPoint.text = "Clean Water Per Day " + (pointsCollect.addWater);
        }
        else if (numberOfItem == 5)
        {
            description.text = shop.descriptions[numberOfItem];
            companeis.text = "Fast Food " + (food.NumberOfCompany);
            addMoney.text = "Money Per Day " + (food.TotalMoney);
            addPoint.text = "Farms Per Day " + (pointsCollect.addFood);
        }
        else if (numberOfItem == 6)
        {
            description.text = shop.descriptions[numberOfItem];
            companeis.text = "NGOs " + (nature.NumberOfCompany);
            addMoney.text = "Money Per Day " + (nature.TotalMoney);
            addPoint.text = "Green Areas Per Day " + (pointsCollect.addNature);
        }
        else if (numberOfItem == 7)
        {
            description.text = shop.descriptions[numberOfItem];
            companeis.text = "Companies " + (energy.NumberOfCompany);
            addMoney.text = "Money Per Day " + (energy.TotalMoney);
            addPoint.text = "Energy Per Day " + (pointsCollect.addEnergy);
        }
    }

    public void ChangeForPage1()
    {
        page1.SetActive(true);
        nextButton.SetActive(true);
        page2.SetActive(false);
        backButton.SetActive(false);
        nextPageText.text = "Page 1/2";
    }

    public void ChangeForPage2()
    {
        page1.SetActive(false);
        nextButton.SetActive(false);
        page2.SetActive(true);
        backButton.SetActive(true);
        nextPageText.text = "Page 2/2";
    }
}
