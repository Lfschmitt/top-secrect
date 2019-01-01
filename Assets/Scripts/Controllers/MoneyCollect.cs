using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour {

    public int[] money;
    public int totalMoney;
    public int moneySend;
    public bool freezeEconomy;
    private int freezeDays;
    private int limitDay = 5;
    private AllPoints allPoints;

    private void Start()
    {
        allPoints = GetComponent<AllPoints>();
    }

    public void ReciveMoney(int position, int value)
    {
        totalMoney -= money[position];
        money[position] = value;
        totalMoney += money[position];
    }

    public void SendMoney(int days)
    {
        if (!freezeEconomy)
        {
            moneySend = totalMoney * days;
            allPoints.AddMoney(moneySend);
            moneySend = 0;
        }
        else
        {
            freezeDays += days;
            if(freezeDays >= limitDay)
            {
                moneySend = totalMoney * days;
                allPoints.AddMoney(moneySend);
                moneySend = 0;
                limitDay *= 3;
                freezeDays = 0;
            }
        }
    }
    
    public void FreezeEconomy(bool ft)
    {
        freezeEconomy = ft;
    }
}
