using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureItens : MonoBehaviour {

    public int TotalMoney;
    public int NumberOfCompany;

    public int MoneyPerCompany;

    public int SetCompanyValue;
    public int CompanyValue;

    public int afectWater;
    public int afectPopulation;
    public int afectNature;

    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private NatureRequirement requirement;

    private MusicController musicController;
    public ColorActivity color;

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
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<NatureRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script nature dont find the Game Object 'ItensRequirementManager'");
        }
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
        SetCompanyValue = CompanyValue;
    }

    void Update()
    {
        TotalMoney =  MoneyPerCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(6, TotalMoney);

        if (requirement.requirement == "")
        {
            if (allPoints.money >= CompanyValue)
                color.NormalButton(6);
            else
                color.RedButton(6);
        }
        else
        {
            color.RedButton(6);
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
            PlayerPrefs.SetInt("NatureCompanieValue", CompanyValue);
            allPoints.AddPopulation((int)(afectPopulation * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddWater((int)(afectWater * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddNature(afectNature);
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement, 6);
        }
    }
}
