using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyItens : MonoBehaviour {

    public int TotalMoney;
    public int NumberOfCompany;

    public int MoneyPerCompany;

    public int SetCompanyValue;
    public int CompanyValue;

    public int afectFood;
    public int afectWater;
    public int afectPopulation;
    public int afectArmy;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private ArmyRequirement requirement;

    private MusicController musicController;
    public ColorActivity color;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script army dont find the Game Object 'PointsController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script army dont find the Game Object 'PointsController'");
        }
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<ArmyRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script army dont find the Game Object 'ItensRequirementManager'");
        }
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
        SetCompanyValue = CompanyValue;
    }

    void Update()
    {
        TotalMoney = MoneyPerCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(2, TotalMoney);

        if (requirement.requirement == "")
        {
            if (allPoints.money >= CompanyValue)
                color.NormalButton(3);
            else
                color.RedButton(3);
        }
        else
        {
            color.RedButton(3);
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
            allPoints.AddArmy(afectArmy);
            allPoints.Addfood(afectFood);
            allPoints.AddWater(afectWater);
            allPoints.AddPopulation(afectPopulation);
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement, 3);
        }
    }
}
