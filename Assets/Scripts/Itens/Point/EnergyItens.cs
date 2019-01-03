﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyItens : MonoBehaviour {

    public int TotalMoney;
    public int TotalMoneyOfCompany;
    public int NumberOfCompany;
    public int NumberOfUpgrades;

    public int MoneyPerUpgrade;
    public int MoneyPerCompany;

    public int CompanyValue;
    public int UpgradeValue;

    public int afectPopulation;
    public int afectNature;
    public int afectEnergy;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    private EnergyRequirement requirement;
    private InstatiateErrorMessage errorMessage;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script energy dont fint the Game Object 'PointsController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script energy dont fint the Game Object 'PointsController'");
        }
        errorMessage = GameObject.Find("ErrorMessage").GetComponent<InstatiateErrorMessage>();
        if (errorMessage == null)
        {
            Debug.Log("The script energy dont find the Game Object 'ErrorMessage'");
        }
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<EnergyRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script energy dont find the Game Object 'ItensRequirementManager'");
        }
    }

    void Update()
    {
        TotalMoneyOfCompany = MoneyPerCompany + MoneyPerUpgrade * NumberOfUpgrades;
        TotalMoney = TotalMoneyOfCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(7, TotalMoney);
    }

    public void BuyCompany(int number)
    {
        if (requirement.requirement == "")
        {
            allPoints.money -= CompanyValue;
            NumberOfCompany += number;
            CompanyValue += CompanyValue / 2;
            allPoints.AddPopulation(afectPopulation);
            allPoints.AddNature(afectNature);
            allPoints.AddPower(afectEnergy);
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
            allPoints.AddPopulation(afectPopulation / 2);
            allPoints.AddNature(afectNature / 2);
            allPoints.AddPower(afectEnergy / 2);
        }
        else
        {
            errorMessage.Instantiate(requirement.requirement);
        }
    }
}