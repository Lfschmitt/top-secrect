using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

    public int totalDays;
    public bool avanceDay;   
    public int limitiDays;
    public Text days;
    public float waitTime;

    private float storageTime;
    private bool send;
    private MoneyCollect moneyCollect;

    private AllPoints allpoints;

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

        storageTime = Time.time + waitTime;
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

        days.text = "Day " + totalDays.ToString();
    }

    public void AvanceDayClick()
    {
        avanceDay = true;
    }

    public void WhenAvanceDay(int number)
    {
        moneyCollect.SendMoney(number);
        totalDays += number;
    }

    public void SetDays(int number)
    {
        totalDays = number;
    }
}
