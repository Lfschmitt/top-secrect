using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

    public int totalDays;
    public bool avanceDay;   
    public int limitiDays;
    public Text days;
    public float waitTime;
    public int dayChange;

    private float storageTime, storageTimeDay;
    private bool send;
    private bool altere;

    private PointsCollect pointsCollect;
    private MoneyCollect moneyCollect;
    private AllPoints allpoints;
    private NightController nightController;

    void Start()
    {
        allpoints = GameObject.Find("PointsController").GetComponent<AllPoints>();    
        if(allpoints == null)
        {
            Debug.Log("The game object -PointsController- not find in scene");
        }

        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The game object -PointsController- not find in scene");
        }

        pointsCollect = GameObject.Find("PointsController").GetComponent<PointsCollect>();
        if (pointsCollect == null)
        {
            Debug.Log("The game object -PointsController- not find in scene");
        }

        nightController = GetComponent<NightController>();

        storageTime = Time.time + waitTime;
        storageTimeDay = Time.time + dayChange;
    }

    void Update () {

        if (avanceDay && totalDays < limitiDays)
        {
            WhenAvanceDay(1);
            avanceDay = !avanceDay;
            storageTime = Time.time + waitTime;
        }
        else
        {
            avanceDay = false;
        }

        if(storageTime < Time.time)
        {
            WhenAvanceDay(1);
            storageTime = Time.time + waitTime;
        }

        if(storageTimeDay < Time.time)
        {
            ChangePlanetTime();
            storageTimeDay += dayChange;
        }
        days.text = "Day " + totalDays.ToString();
    }

    public void GameTime(bool pause)
    {
        if (pause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void ChangePlanetTime()
    {
        if (altere)
        {
            nightController.StartCoroutine("StayDay");
            altere = false;
        }
        else
        {
            nightController.StartCoroutine("StayNight");
            altere = true;
        }
    }
    public void AvanceDayClick()
    {
        avanceDay = true;
        storageTimeDay = Time.time + dayChange;
        altere = true;
        ChangePlanetTime();
    }

    public void WhenAvanceDay(int number)
    {
        pointsCollect.SendPoints(number);
        moneyCollect.SendMoney(number);
        totalDays += number;
        storageTimeDay = Time.time + dayChange;
        altere = true;
        ChangePlanetTime();
    }

    public void SetDays(int number)
    {
        totalDays = number;
    }
}
