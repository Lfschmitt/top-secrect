using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public Text writePoint;
    public Text money;
    public Text upgradeCostText;
    public Text buyCostText;
    public Text numberUpgrades;
    public Text numberCompany;
    public Text pricePerCompany;
    public Text Button;
    public Text errorText;
    public GameObject error;

    public int count;
    private AllPoints allPoints;
    private int distance;
    private int steps;
    private TechnologyItens technology;
    private ScienceItens science;
    private ArmyItens army;
    private FoodItens food;
    private WaterItens water;
    private PopulationsItens population;
    private NatureItens nature;
    private EnergyItens energy;

    public ColorActivity companyButton;
    public ColorActivity upgradeButton;

    void Start () {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();      
        technology = GameObject.Find("ItensBuyManager").GetComponent<TechnologyItens>();
        science = GameObject.Find("ItensBuyManager").GetComponent<ScienceItens>();
        army = GameObject.Find("ItensBuyManager").GetComponent<ArmyItens>();
        food = GameObject.Find("ItensBuyManager").GetComponent<FoodItens>();
        water = GameObject.Find("ItensBuyManager").GetComponent<WaterItens>();
        population = GameObject.Find("ItensBuyManager").GetComponent<PopulationsItens>();
        nature = GameObject.Find("ItensBuyManager").GetComponent<NatureItens>();
        energy = GameObject.Find("ItensBuyManager").GetComponent<EnergyItens>();

        //companyButton = GameObject.Find("CompanyButton").GetComponent<ColorActivity>();
        //upgradeButton = GameObject.Find("UpgradeButton").GetComponent<ColorActivity>();
    }
	
	void Update () {
        money.text = "Money " + allPoints.money.ToString();
        if (count == 0)
            EnableTechnology();
        else if (count == 1)
            EnableScience();
        else if (count == 2)
            EnableArmy();
        else if (count == 3)
            EnableFood();
        else if (count == 4)
            EnableWater();
        else if (count == 5)
            EnablePopulation();
        else if (count == 6)
            EnableNature();
        else if (count == 7)
            EnablePower();
    }

    public void CountMore()
    {
        if (count == 7)
            count = 0;
        else if(count < 7)
            count++;        
    }    
    public void CountLess()
    {
        if (count == 0)
            count = 7;
        else if (count > 0)
            count--;
    }

    void EnableTechnology()
    {
        if (allPoints.money >= technology.CompanyValue)
            companyButton.NormalButton();
        else
            companyButton.RedButton();

        if (allPoints.money >= technology.UpgradeValue)
            upgradeButton.NormalButton();
        else
            upgradeButton.RedButton();


        writePoint.text = "Technology";
        Button.text = "Buy Company";
        upgradeCostText.text = "Cost " + technology.UpgradeValue;
        buyCostText.text = "Cost " + technology.CompanyValue;
        numberCompany.text = "Company " + technology.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + technology.NumberOfUpgrades;
        pricePerCompany.text = "Price of each company " + (technology.TotalMoneyOfCompany);
    }
    void EnableScience()
    {
        if (allPoints.money >= science.CompanyValue)
            companyButton.NormalButton();
        else
            companyButton.RedButton();

        if (allPoints.money >= science.UpgradeValue)
            upgradeButton.NormalButton();
        else
            upgradeButton.RedButton();

        writePoint.text = "Science";
        Button.text = "Buy Lab";
        upgradeCostText.text = "Cost " + science.UpgradeValue;
        buyCostText.text = "Cost " + science.CompanyValue;
        numberCompany.text = "Company " + science.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + science.NumberOfUpgrades;
        pricePerCompany.text = "Price of each company " + (science.TotalMoneyOfCompany);
    }
    void EnableArmy()
    {
        if (allPoints.money >= army.CompanyValue)
            companyButton.NormalButton();
        else
            companyButton.RedButton();

        if (allPoints.money >= army.UpgradeValue)
            upgradeButton.NormalButton();
        else
            upgradeButton.RedButton();

        Button.text = "Buy Soldiers";
        writePoint.text = "Army";
        upgradeCostText.text = "Cost " + army.UpgradeValue;
        buyCostText.text = "Cost " + army.CompanyValue;
        numberCompany.text = "Company " + army.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + army.NumberOfUpgrades;
        pricePerCompany.text = "Price of each company " + (army.TotalMoneyOfCompany);
    }
    void EnableFood()
    {
        if (allPoints.money >= food.CompanyValue)
            companyButton.NormalButton();
        else
            companyButton.RedButton();

        if (allPoints.money >= food.UpgradeValue)
            upgradeButton.NormalButton();
        else
            upgradeButton.RedButton();

        writePoint.text = "Food";
        Button.text = "Buy Fast-Food";
        upgradeCostText.text = "Cost " + food.UpgradeValue;
        buyCostText.text = "Cost " + food.CompanyValue;
        numberCompany.text = "Company " + food.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + food.NumberOfUpgrades;
        pricePerCompany.text = "Price of each company " + (food.TotalMoneyOfCompany);
    }
    void EnableWater()
    {
        if (allPoints.money >= water.CompanyValue)
            companyButton.NormalButton();
        else
            companyButton.RedButton();

        if (allPoints.money >= water.UpgradeValue)
            upgradeButton.NormalButton();
        else
            upgradeButton.RedButton();


        writePoint.text = "Water";
        Button.text = "Clear Rivers";
        upgradeCostText.text = "Cost " + water.UpgradeValue;
        buyCostText.text = "Cost " + water.CompanyValue;
        numberCompany.text = "Company " + water.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + water.NumberOfUpgrades;
        pricePerCompany.text = "Price of each company " + (water.TotalMoneyOfCompany);
    }
    void EnablePopulation()
    {
        if (allPoints.money >= population.CompanyValue)
            companyButton.NormalButton();
        else
            companyButton.RedButton();

        if (allPoints.money >= population.UpgradeValue)
            upgradeButton.NormalButton();
        else
            upgradeButton.RedButton();

        writePoint.text = "Population";
        Button.text = "Buy Homes";
        upgradeCostText.text = "Cost " + population.UpgradeValue;
        buyCostText.text = "Cost " + population.CompanyValue;
        numberCompany.text = "Company " + population.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + population.NumberOfUpgrades;
        pricePerCompany.text = "Price of each company " + (population.TotalMoneyOfCompany);
    }
    void EnableNature()
    {
        if (allPoints.money >= nature.CompanyValue)
            companyButton.NormalButton();
        else
            companyButton.RedButton();

        if (allPoints.money >= nature.UpgradeValue)
            upgradeButton.NormalButton();
        else
            upgradeButton.RedButton();

        writePoint.text = "Nature";
        Button.text = "Buy Nature";
        upgradeCostText.text = "Cost " + nature.UpgradeValue;
        buyCostText.text = "Cost " + nature.CompanyValue;
        numberCompany.text = "Company " + nature.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + nature.NumberOfUpgrades;
        pricePerCompany.text = "Price of each company " + (nature.TotalMoneyOfCompany);
    }
    void EnablePower()
    {
        if (allPoints.money >= energy.CompanyValue)
            companyButton.NormalButton();
        else
            companyButton.RedButton();

        if (allPoints.money >= energy.UpgradeValue)
            upgradeButton.NormalButton();
        else
            upgradeButton.RedButton();

        writePoint.text = "Energy";
        Button.text = "Buy Company";
        upgradeCostText.text = "Cost " + energy.UpgradeValue;
        buyCostText.text = "Cost " + energy.CompanyValue;
        numberCompany.text = "Company " + energy.NumberOfCompany;
        numberUpgrades.text = "Upgrades " + energy.NumberOfUpgrades;
        pricePerCompany.text = "Price of each company " + (energy.TotalMoneyOfCompany);
    }
    
    public void CompanyButton()
    {
        if (count == 0)
        {
            if (allPoints.money >= technology.CompanyValue)
            {
                technology.BuyCompany(1);
            }
        }
        else if (count == 1)
        {
            if (allPoints.money >= science.CompanyValue)
            {
                science.BuyCompany(1);
            }
        }
        else if (count == 2)
        {
            if (allPoints.money >= army.CompanyValue)
            {
                army.BuyCompany(1);
            }
        }
        else if (count == 3)
        {
            if (allPoints.money >= food.CompanyValue)
            {
                food.BuyCompany(1);
            }
        }
        else if (count == 4)
        {
            if (allPoints.money >= water.CompanyValue)
            {
                water.BuyCompany(1);
            }
        }
        else if (count == 5)
        {
            if (allPoints.money >= population.CompanyValue)
            {
                population.BuyCompany(1);              
            }
        }
        else if (count == 6)
        {
            if (allPoints.money >= nature.CompanyValue)
            {
                
                nature.BuyCompany(1);
            }
        }
        else if (count == 7)
        {
            if (allPoints.money >= energy.CompanyValue)
            {
                energy.BuyCompany(1);
            }
        }
    }
    public void UpgradeButton()
    {
        if (count == 0)
        {
            if (allPoints.money >= technology.UpgradeValue)
            {
                technology.BuyUpgrade(1);
            }
        }
        else if (count == 1)
        {
            if (allPoints.money >= science.UpgradeValue)
            {
                science.BuyUpgrade(1);
            }
        }
        else if (count == 2)
        {
            if (allPoints.money >= army.UpgradeValue)
            {
                army.BuyUpgrade(1);
            }
        }
        else if (count == 3)
        {
            if (allPoints.money >= food.UpgradeValue)
            {
                food.BuyUpgrade(1);
            }
        }
        else if (count == 4)
        {
            if (allPoints.money >= water.UpgradeValue)
            {
                water.BuyUpgrade(1);
            }
        }
        else if (count == 5)
        {
            if (allPoints.money >= population.UpgradeValue)
            {
                population.BuyUpgrade(1);
            }
        }
        else if (count == 6)
        {
            if (allPoints.money >= nature.UpgradeValue)
            {
                nature.BuyUpgrade(1);
            }
        }
        else if (count == 7)
        {
            if (allPoints.money >= energy.UpgradeValue)
            {
                energy.BuyUpgrade(1);
            }
        }
    }
}
