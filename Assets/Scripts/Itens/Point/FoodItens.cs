using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItens : MonoBehaviour {

    public int TotalMoney;
    public int NumberOfCompany;

    public int MoneyPerCompany;

    public int SetCompanyValue;
    public int CompanyValue;
    //A cada alguns pontos de limit aumenta 1 de produçao
    public int itenLimit;

    public int afectFood;
    public int afectPopulation;
    public int afectEnergy;
    public int afectNature;
    private MoneyCollect moneyCollect;
    private AllPoints allPoints;
    public InstatiateErrorMessage errorMessage;
    private FoodRequirement requirement;

    private MusicController musicController;
    public ColorActivity color;

    private void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allPoints == null)
        {
            Debug.Log("The script food dont find the Game Object 'PointsController'");
        }
        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The script food dont find the Game Object 'PointsController'");
        }
        requirement = GameObject.Find("ItensRequirementManager").GetComponent<FoodRequirement>();
        if (requirement == null)
        {
            Debug.Log("The script food dont find the Game Object 'ItensRequirementManager'");
        }
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
        SetCompanyValue = CompanyValue;
    }

    void Update()
    {
        TotalMoney = MoneyPerCompany * NumberOfCompany;

        moneyCollect.ReciveMoney(3, TotalMoney);

        if (requirement.requirement == "")
        {
            if (allPoints.money >= CompanyValue)
                color.NormalButton(5);
            else
                color.RedButton(5);
        }
        else
        {
            color.RedButton(5);
        }
    }

    public void BuyCompany(int number)
    {
        if (requirement.requirement == "")
        {
            musicController.CoinSound();
            allPoints.AddFoodLimit(itenLimit);
            allPoints.money -= CompanyValue;
            NumberOfCompany += number;
            CompanyValue += SetCompanyValue;
            PlayerPrefs.SetInt("FoodCompanieValue", CompanyValue);
            allPoints.AddNature((int)(afectNature * PlayerPrefs.GetFloat("Difficult")));
            allPoints.Addfood(afectFood);
            allPoints.AddPower((int)(afectEnergy * PlayerPrefs.GetFloat("Difficult")));
            allPoints.AddPopulation((int)(afectPopulation * PlayerPrefs.GetFloat("Difficult")));
        }
        else
        {
            musicController.ClickSound();
            errorMessage.Instantiate(requirement.requirement, 5);
        }
    }
}
