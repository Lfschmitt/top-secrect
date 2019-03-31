using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterItens : MonoBehaviour {

    public int TotalMoney;
    public int NumberOfCompany;

    public int MoneyPerCompany;

    public int SetCompanyValue;
    public int CompanyValue;

    public int afectPopulation;
    public int afectWater;
    public int afectNature;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private WaterRequirement requirement;

    private MusicController musicController;
    public ColorActivity color;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script water dont find the Game Object 'PointsController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script water dont find the Game Object 'PointsController'");
        }
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<WaterRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script water dont find the Game Object 'ItensRequirementManager'");
        }
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
        SetCompanyValue = CompanyValue;
    }

    void Update()
    {
        TotalMoney = MoneyPerCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(4, TotalMoney);

        if (requirement.requirement == "")
        {
            if (allPoints.money >= CompanyValue)
                color.NormalButton(4);
            else
                color.RedButton(4);
        }
        else
        {
            color.RedButton(4);
        }
    }

    public void BuyCompany(int number)
    {
        if (requirement.requirement == "")
        {
            musicController.CoinSound();
            allPoints.money -= CompanyValue;
            NumberOfCompany += number;
            CompanyValue += SetCompanyValue;
            PlayerPrefs.SetInt("WaterCompanieValue", CompanyValue);
            allPoints.AddNature((int)(afectNature * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddWater(afectWater);
            allPoints.AddPopulation((int)(afectPopulation * PlayerPrefs.GetFloat("Difficult")));
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement, 4);
        }
    }
}
