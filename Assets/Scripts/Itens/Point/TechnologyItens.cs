using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyItens : MonoBehaviour {

    public int TotalMoney;
    public int TotalMoneyOfCompany;
    public int NumberOfCompany;
    public int NumberOfUpgrades;

    public int MoneyPerUpgrade;
    public int MoneyPerCompany;

    public int SetCompanyValue;
    public int SetUpgradeValue;
    public int CompanyValue;
    public int UpgradeValue;

    public int afectTechnology;
    public int afectPopulation;
    public int afectNature;
    public int afectEnergy;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private TechnologyRequirement requirement;

    private MusicController musicController;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script technology dont find the Game Object 'PointsController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script technology dont find the Game Object 'PointsController'");
        }
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<TechnologyRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script technology dont find the Game Object 'ItensRequirementManager'");
        }
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
        SetCompanyValue = CompanyValue;
        SetUpgradeValue = UpgradeValue;
    }

    void Update() {
        TotalMoneyOfCompany = MoneyPerCompany + MoneyPerUpgrade * NumberOfUpgrades;
        TotalMoney = TotalMoneyOfCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(0, TotalMoney);
    }

    public void BuyCompany(int number)
    {
        if (requirement.requirement == "")
        {
            musicController.CoinSound();
            allPoints.money -= CompanyValue;
            NumberOfCompany += number;
            CompanyValue += SetCompanyValue;
            allPoints.AddTechnology(afectTechnology);
            allPoints.AddPopulation(afectPopulation);
            allPoints.AddNature(afectNature);
            allPoints.AddPower(afectEnergy);
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement);
        }
    }
    
    public void BuyUpgrade(int number)
    {
        if (requirement.requirement == "")
        {
            musicController.CoinSound();
            allPoints.money -= UpgradeValue;
            NumberOfUpgrades += number;
            UpgradeValue += SetUpgradeValue;
            allPoints.AddTechnology(afectTechnology / 2);
            allPoints.AddPopulation(afectPopulation / 2);
            allPoints.AddNature(afectNature / 2);
            allPoints.AddPower(afectEnergy / 2);
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement);
        }
    }
}
