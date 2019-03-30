using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public Text money;
    public Text errorText;
    public GameObject error;
    public Text[] price;

    [TextArea(3, 10)]
    public string[] descriptions;

    public Animator infoPanelAnimator;
    private AllPoints allPoints;
    private FirstBuy firstBuy;

    private InfoShopPageController infoShop;
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
        infoShop = GetComponent<InfoShopPageController>();

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
            firstBuy.First(0);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 0);
        }
    }
    public void BuyScience()
    {
        if (allPoints.money >= science.CompanyValue)
        {
            science.BuyCompany(1);
            firstBuy.First(1);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 1);
        }
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
    }
    public void BuyArmy()
    {
        if (allPoints.money >= army.CompanyValue)
        {
            army.BuyCompany(1);
            firstBuy.First(3);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 3);
        }
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
    }
    public void BuyFood()
    {
        if (allPoints.money >= food.CompanyValue)
        {
            food.BuyCompany(1);
            firstBuy.First(5);
        }
        else
        {
            errorMessage.Instantiate("You Need Money For Buy", 5);
        }
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
    }

    public void InfoPanel(int numberOfItem)
    {
        infoShop.InfoPanel(numberOfItem);
        OpenInfoPanel(true);
    }

    public void OpenInfoPanel(bool open)
    {
        infoPanelAnimator.SetBool("IsOpen", open);
    }
}
