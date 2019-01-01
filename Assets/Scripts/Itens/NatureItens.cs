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

    public bool company;
    public bool upgrade;

    public int afectWater;
    public int afectPopulation;
    public int afectNature;

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
        allPoints.AddPopulation(afectWater);
        allPoints.AddWater(afectPopulation);
        allPoints.AddNature(afectNature);
    }

    public void BuyUpgrade(int number)
    {
        NumberOfUpgrades += number;
        UpgradeValue += MoneyPerCompany;
        allPoints.AddWater(afectWater / 2);
        allPoints.AddPopulation(afectPopulation / 2);
        allPoints.AddNature(afectNature / 2);
    }
}
