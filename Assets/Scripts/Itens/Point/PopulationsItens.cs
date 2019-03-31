using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationsItens : MonoBehaviour {

    public int TotalMoney;
    public int NumberOfCompany;

    public int MoneyPerCompany;

    public int SetCompanyValue;
    public int CompanyValue;
    //A cada alguns pontos de limit aumenta 1 de produçao
    public int itenLimit;

    public int afectArmy;
    public int afectWater;
    public int afectFood;
    public int afectPopulation;
    public int afectEnergy;
    public int afectNature;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private PopulationRequirement requirement;

    private MusicController musicController;
    public ColorActivity color;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script population dont find the Game Object 'PointsController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script population dont find the Game Object 'PointsController'");
        }
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<PopulationRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script population dont find the Game Object 'ItensRequirementManager'");
        }
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
        SetCompanyValue = CompanyValue;
    }

    void Update()
    {
        TotalMoney = MoneyPerCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(5, TotalMoney);

        if (requirement.requirement == "")
        {
            if (allPoints.money >= CompanyValue)
                color.NormalButton(2);
            else
                color.RedButton(2);
        }
        else
        {
            color.RedButton(2);
        }
    }

    public void BuyCompany(int number)
    {
        if (requirement.requirement == "")
        {
            musicController.CoinSound();
            allPoints.AddPopulationLimit(itenLimit);
            allPoints.money -= CompanyValue;
            NumberOfCompany += number;
            CompanyValue += SetCompanyValue;
            PlayerPrefs.SetInt("PopulationCompanieValue", CompanyValue);
            allPoints.AddArmy((int)(afectArmy * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddWater((int)(afectWater * PlayerPrefs.GetFloat("Difficult")));
            allPoints.Addfood((int)(afectFood * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddPopulation(afectPopulation);
            allPoints.AddPower((int)(afectEnergy * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddNature((int)(afectNature * PlayerPrefs.GetFloat("Difficult")));
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement, 2);
        }
    }
}
