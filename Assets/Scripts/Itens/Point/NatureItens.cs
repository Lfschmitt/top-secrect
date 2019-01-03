using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureItens : MonoBehaviour {

    public int TotalMoney;
    public int TotalMoneyOfCompany;
    public int NumberOfCompany;
    public int NumberOfUpgrades;

    public int MoneyPerUpgrade;
    public int MoneyPerCompany;

    public int CompanyValue;
    public int UpgradeValue;

    public int afectWater;
    public int afectPopulation;
    public int afectNature;

    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    private InstatiateErrorMessage errorMessage;
    private NatureRequirement requirement;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script nature dont find the Game Object 'PointsController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script nature dont find the Game Object 'PointsController'");
        }
        errorMessage = GameObject.Find("ErrorMessage").GetComponent<InstatiateErrorMessage>();
        if (errorMessage == null)
        {
            Debug.Log("The script nature dont find the Game Object 'ErrorMessage'");
        }
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<NatureRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script nature dont find the Game Object 'ItensRequirementManager'");
        }
    }

    void Update()
    {
        TotalMoneyOfCompany = MoneyPerCompany + MoneyPerUpgrade * NumberOfUpgrades;
        TotalMoney = TotalMoneyOfCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(6, TotalMoney);
    }

    public void BuyCompany(int number)
    {
        if (requirement.requirement == "")
        {
            allPoints.money -= CompanyValue;
            NumberOfCompany += number;
            CompanyValue += CompanyValue / 2;
            allPoints.AddPopulation(afectPopulation);
            allPoints.AddWater(afectWater);
            allPoints.AddNature(afectNature);
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
            UpgradeValue += UpgradeValue / 2;
            allPoints.AddWater(afectWater / 2);
            allPoints.AddPopulation(afectPopulation / 2);
            allPoints.AddNature(afectNature / 2);
        }
        else
        {
            errorMessage.Instantiate(requirement.requirement);
        }
    }
}
