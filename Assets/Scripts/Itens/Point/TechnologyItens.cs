using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyItens : MonoBehaviour {

    public int TotalMoney;
    public int NumberOfCompany;

    public int MoneyPerCompany;

    public int SetCompanyValue;
    public int CompanyValue;

    public int afectTechnology;
    public int afectPopulation;
    public int afectNature;
    public int afectEnergy;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private TechnologyRequirement requirement;

    private MusicController musicController;
    public ColorActivity color;

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
    }

    void Update() {
        TotalMoney = MoneyPerCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(0, TotalMoney);

        if (requirement.requirement == "")
        {
            if (allPoints.money >= CompanyValue)
                color.NormalButton(0);
            else
                color.RedButton(0);
        }
        else
        {
            color.RedButton(0);
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
            allPoints.AddTechnology(afectTechnology);
            allPoints.AddPopulation(afectPopulation);
            allPoints.AddNature(afectNature);
            allPoints.AddPower(afectEnergy);
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement, 0);
        }
    }
}
