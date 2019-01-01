using System.Collections;
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

    public bool company;
    public bool upgrade;

    public int afectPopulation;
    public int afectNature;
    public int afectEnergy;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script technology dont fint the Game Object 'TimeController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script technology dont fint the Game Object 'TimeController'");
        }
    }

    void Update()
    {
        TotalMoneyOfCompany = MoneyPerCompany + MoneyPerUpgrade * NumberOfUpgrades;
        TotalMoney = TotalMoneyOfCompany * NumberOfCompany;

        if (NumberOfCompany != 0)
            CompanyValue = MoneyPerCompany * NumberOfCompany;
        if (NumberOfUpgrades != 0)
            UpgradeValue = MoneyPerCompany * NumberOfUpgrades;

        if (company)
        {
            BuyCompany(1);
            company = !company;
        }
        if (upgrade)
        {
            if (NumberOfCompany > 0)
                BuyUpgrade(1);
            upgrade = !upgrade;
        }

        moneyCollect.ReciveMoney(0, TotalMoney);
    }

    public void BuyCompany(int number)
    {
        NumberOfCompany += number;
        CompanyValue += MoneyPerCompany;
        allPoints.AddPopulation(afectPopulation);
        allPoints.AddNature(afectNature);
        allPoints.AddPower(afectEnergy);
    }

    public void BuyUpgrade(int number)
    {
        NumberOfUpgrades += number;
        UpgradeValue += MoneyPerCompany;
        allPoints.AddPopulation(afectPopulation / 2);
        allPoints.AddNature(afectNature / 2);
        allPoints.AddPower(afectEnergy / 2);
    }
}
