using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyItens : MonoBehaviour {

    public int TotalMoney;
    public int NumberOfCompany;

    public int MoneyPerCompany;

    public int SetCompanyValue;
    public int CompanyValue;
    //A cada alguns pontos de limit aumenta 1 de produçao
    public int itenLimit;

    public int afectPopulation;
    public int afectNature;
    public int afectEnergy;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private EnergyRequirement requirement;

    private MusicController musicController;
    public ColorActivity color;

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
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<EnergyRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script energy dont find the Game Object 'ItensRequirementManager'");
        }
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
        SetCompanyValue = CompanyValue;
    }

    void Update()
    {
        TotalMoney = MoneyPerCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(7, TotalMoney);

        if (requirement.requirement == "")
        {
            if (allPoints.money >= CompanyValue)
                color.NormalButton(7);
            else
                color.RedButton(7);
        }
        else
        {
            color.RedButton(7);
        }
    }

    public void BuyCompany(int number)
    {
        if (requirement.requirement == "")
        {
            musicController.CoinSound();
            allPoints.money -= CompanyValue;
            allPoints.AddPowerLimit(itenLimit);
            NumberOfCompany += number;
            CompanyValue += SetCompanyValue;
            PlayerPrefs.SetInt("EnergyCompanieValue", CompanyValue);
            allPoints.AddPopulation((int)(afectPopulation * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddNature((int)(afectNature * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddPower(afectEnergy);
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement, 7);
        }
    }
}
