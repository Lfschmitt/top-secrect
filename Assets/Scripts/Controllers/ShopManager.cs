using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public Text money;
    public Text errorText;
    public GameObject error;
    public Text[] price;
    private AllPoints allPoints;
    private FirstBuy firstBuy;

    private TechnologyItens technology;
    private ScienceItens science;
    private ArmyItens army;
    private FoodItens food;
    private WaterItens water;
    private PopulationsItens population;
    private NatureItens nature;
    private EnergyItens energy;

    public InstatiateErrorMessage errorMessage;

    void Start () {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();        
        firstBuy = GameObject.Find("UpdateWorld").GetComponent<FirstBuy>();

        technology = GameObject.Find("ItensBuyManager").GetComponent<TechnologyItens>();
        science = GameObject.Find("ItensBuyManager").GetComponent<ScienceItens>();
        army = GameObject.Find("ItensBuyManager").GetComponent<ArmyItens>();
        food = GameObject.Find("ItensBuyManager").GetComponent<FoodItens>();
        water = GameObject.Find("ItensBuyManager").GetComponent<WaterItens>();
        population = GameObject.Find("ItensBuyManager").GetComponent<PopulationsItens>();
        nature = GameObject.Find("ItensBuyManager").GetComponent<NatureItens>();
        energy = GameObject.Find("ItensBuyManager").GetComponent<EnergyItens>();
    }
	
	void Update () {
        money.text = "Money " + allPoints.money.ToString();

        price[0].text = technology.CompanyValue.ToString();
        price[1].text = science.CompanyValue.ToString();
        price[2].text = population.CompanyValue.ToString();
        price[3].text = army.CompanyValue.ToString();
        price[4].text = water.CompanyValue.ToString();
        price[5].text = food.CompanyValue.ToString();
        price[6].text = nature.CompanyValue.ToString();
        price[7].text = energy.CompanyValue.ToString();
    }

    public void BuyTechnology()
    {
        if (allPoints.money >= technology.CompanyValue)
        {
            technology.BuyCompany(1);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 0);
        }
        /*icons.sprite = spriteIcons[count];
        writePoint.text = "Technology";
        Button.text = "Buy Company";
        upgradeCostText.text = "Cost " + technology.UpgradeValue;
        buyCostText.text = "Cost " + technology.CompanyValue;
        numberCompany.text = "Company " + technology.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + technology.NumberOfUpgrades;
        pricePerCompany.text = "Money per Day " + (technology.TotalMoney);*/
    }
    public void BuyScience()
    {
        if (allPoints.money >= science.CompanyValue)
        {
            science.BuyCompany(1);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 1);
        }
        /*icons.sprite = spriteIcons[count];
        writePoint.text = "Science";
        Button.text = "Buy Lab";
        upgradeCostText.text = "Cost " + science.UpgradeValue;
        buyCostText.text = "Cost " + science.CompanyValue;
        numberCompany.text = "Company " + science.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + science.NumberOfUpgrades;
        pricePerCompany.text = "Money per Day  " + (science.TotalMoney);*/
    }
    public void BuyPopulation()
    {
        if (allPoints.money >= population.CompanyValue)
        {
            population.BuyCompany(1);
            firstBuy.First(2);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 2);
        }
        /*icons.sprite = spriteIcons[count];
        writePoint.text = "Population";
        Button.text = "Buy Homes";
        upgradeCostText.text = "Cost " + population.UpgradeValue;
        buyCostText.text = "Cost " + population.CompanyValue;
        numberCompany.text = "Company " + population.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + population.NumberOfUpgrades;
        pricePerCompany.text = "Money per Day  " + (population.TotalMoney);*/
    }
    public void BuyArmy()
    {
        if (allPoints.money >= army.CompanyValue)
        {
            army.BuyCompany(1);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 3);
        }
        /*icons.sprite = spriteIcons[count];
        Button.text = "Buy Soldiers";
        writePoint.text = "Army";
        upgradeCostText.text = "Cost " + army.UpgradeValue;
        buyCostText.text = "Cost " + army.CompanyValue;
        numberCompany.text = "Company " + army.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + army.NumberOfUpgrades;
        pricePerCompany.text = "Money per Day  " + (army.TotalMoney);*/
    }
    public void BuyWater()
    {
        if (allPoints.money >= water.CompanyValue)
        {
            water.BuyCompany(1);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 4);
        }
        /*icons.sprite = spriteIcons[count];
        writePoint.text = "Water";
        Button.text = "Clear Rivers";
        upgradeCostText.text = "Cost " + water.UpgradeValue;
        buyCostText.text = "Cost " + water.CompanyValue;
        numberCompany.text = "Company " + water.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + water.NumberOfUpgrades;
        pricePerCompany.text = "Money per Day " + (water.TotalMoney);*/
    }
    public void BuyFood()
    {
        if (allPoints.money >= food.CompanyValue)
        {
            food.BuyCompany(1);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 5);
        }
        /*icons.sprite = spriteIcons[count];
        writePoint.text = "Food";
        Button.text = "Buy Fast-Food";
        upgradeCostText.text = "Cost " + food.UpgradeValue;
        buyCostText.text = "Cost " + food.CompanyValue;
        numberCompany.text = "Company " + food.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + food.NumberOfUpgrades;
        pricePerCompany.text = "Food per Day " + (pointsCollect.addFood);*/
    }
    public void BuyNature()
    {
        if (allPoints.money >= nature.CompanyValue)
        {

            nature.BuyCompany(1);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 6);
        }
        /*icons.sprite = spriteIcons[count];
        writePoint.text = "Nature";
        Button.text = "Buy Nature";
        upgradeCostText.text = "Cost " + nature.UpgradeValue;
        buyCostText.text = "Cost " + nature.CompanyValue;
        numberCompany.text = "Company " + nature.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + nature.NumberOfUpgrades;
        pricePerCompany.text = "Money per Day  " + (nature.TotalMoney);*/
    }
    public void BuyEnergy()
    {
        if (allPoints.money >= energy.CompanyValue)
        {
            energy.BuyCompany(1);
            firstBuy.First(7);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 7);
        }
        /*icons.sprite = spriteIcons[count];
        writePoint.text = "Energy";
        Button.text = "Buy Company";
        upgradeCostText.text = "Cost " + energy.UpgradeValue;
        buyCostText.text = "Cost " + energy.CompanyValue;
        numberCompany.text = "Company " + energy.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + energy.NumberOfUpgrades;
        pricePerCompany.text = "Energy per Day " + (pointsCollect.addEnergy);*/
    }
}
