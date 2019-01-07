using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItens : MonoBehaviour {

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

    public int afectFood;
    public int afectPopulation;
    public int afectEnergy;
    public int afectNature;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private FoodRequirement requirement;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script food dont find the Game Object 'PointsController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script food dont find the Game Object 'PointsController'");
        }
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<FoodRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script food dont find the Game Object 'ItensRequirementManager'");
        }
        SetCompanyValue = CompanyValue;
        SetUpgradeValue = UpgradeValue;
    }

    void Update()
    {
        TotalMoneyOfCompany = MoneyPerCompany + MoneyPerUpgrade * NumberOfUpgrades;
        TotalMoney = TotalMoneyOfCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(3, TotalMoney);
    }

    public void BuyCompany(int number)
    {
        if (requirement.requirement == "")
        {
            allPoints.money -= CompanyValue;
            NumberOfCompany += number;
            CompanyValue = CompanyValue * NumberOfCompany * (3 / 2);
            allPoints.AddNature(afectNature);
            allPoints.Addfood(afectFood);
            allPoints.AddPower(afectEnergy);
            allPoints.AddPopulation(afectPopulation);
        }
        else
        {
            errorMessage.Instantiate(requirement.requirement);
        }
    }

    public void BuyUpgrade(int number)
    {
        if (requirement.requirement == "")
        {
            allPoints.money -= UpgradeValue;
            NumberOfUpgrades += number;
            UpgradeValue = UpgradeValue * NumberOfUpgrades * (3 / 2);
            allPoints.AddNature(afectNature / 2);
            allPoints.Addfood(afectFood / 2);
            allPoints.AddPower(afectEnergy / 2);
            allPoints.AddPopulation(afectPopulation / 2);
        }
        else
        {
            errorMessage.Instantiate(requirement.requirement);
        }
    }
}
