using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandonDestroy : MonoBehaviour {

    public int destroy1, destroy2, destroy3, destroy4, destroy5, destroy6;
    public GameObject panel;
    public GameObject payPanel;
    public GameObject confirmPanel;
    public int maxDays;
    public int minDays;
    public int moneyRequired;
    public Text text;
    public ColorActivity button;

    private int pop;
    private int food;
    private int power;
    private int nat;
    private bool confirmColor;
    private TimeController timeController;
    private AllPoints allPoints;

    private Vibration vibration;

    void Start () {
        allPoints = GetComponent<AllPoints>();
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        vibration = GetComponent<Vibration>();
    }
	
	void Update () {
        if (destroy1 == timeController.totalDays)
            Tsunami();
        else if (destroy2 == timeController.totalDays)
            Earthquake();
        else if (destroy3 == timeController.totalDays)
            Storm();
        else if (destroy4 == timeController.totalDays)
            SeaQuake();
        else if (destroy5 == timeController.totalDays)
            Eruption();
        else if (destroy6 == timeController.totalDays)
            Hurricane();

        if (confirmColor)
        {
            if (allPoints.money < moneyRequired)
                button.RedButton(8);
            else
                button.NormalButton(8);
        }

    }

    public void LotteryNumbers ()
    {
        destroy1 = Random.Range(minDays, maxDays);
        destroy2 = Random.Range(minDays, maxDays);
        destroy3 = Random.Range(minDays, maxDays);
        destroy4 = Random.Range(minDays, maxDays);
        destroy5 = Random.Range(minDays, maxDays);
        destroy6 = Random.Range(minDays, maxDays);
    }

    public void EnablePanel(bool name)
    {
        if (!name)
            vibration.vibrate = true;
        else
            vibration.Vibrate();

        if (name)
        {
            panel.SetActive(true);
            timeController.GameTime(true);
        }
        else
        {
            panel.SetActive(false);
            confirmPanel.SetActive(false);
            payPanel.SetActive(false);
            timeController.GameTime(false);
        }
    }

    private void Tsunami()
    {
        EnablePanel(true);
        vibration.Vibrate();
        text.text = "some cities were hit by a tsunami, the planet lose population, nature and energy";
        Points(-30, -30, 0, 0);

        destroy1 = 0;
        destroy2 += 10;
        destroy3 += 10;
        destroy4 += 10;
        destroy5 += 10;
        destroy6 += 10;
    }
    private void Earthquake()
    {
        EnablePanel(true);
        vibration.Vibrate();
        text.text = "an earthquake hit your population and caused many deaths";
        Points(-30, -30, -30, 0);

        destroy1 += 10;
        destroy2 = 0;
        destroy3 += 10;
        destroy4 += 10;
        destroy5 += 10;
        destroy6 += 10;
    }
    private void Storm()
    {
        EnablePanel(true);
        vibration.Vibrate();
        text.text = "some energy generators were breaked by the storm";
        Points(0, 0, -50, 0);

        destroy1 += 10;
        destroy2 += 10;
        destroy3 = 0;
        destroy4 += 10;
        destroy5 += 10;
        destroy6 += 10;
    }
    private void SeaQuake()
    {
        EnablePanel(true);
        vibration.Vibrate();
        text.text = "a seaquake invaded some food stocks and ended up spoiling them";
        Points(0, 0, 0, -40);

        destroy1 += 10;
        destroy2 += 10;
        destroy3 += 10;
        destroy4 = 0;
        destroy5 += 10;
        destroy6 += 10;
    }
    private void Eruption()
    {
        EnablePanel(true);
        vibration.Vibrate();
        text.text = "a volcano erupted and destroyed large natural areas";
        Points(0, -75, 0, 0);

        destroy1 += 10;
        destroy2 += 10;
        destroy3 += 10;
        destroy4 += 10;
        destroy5 = 0;
        destroy6 += 10;
    }  
    private void Hurricane()
    {
        EnablePanel(true);
        vibration.Vibrate();
        text.text = "a hurricane destroyed many house and left many people injured";
        Points(-50, 0, 0, 0);
        
        destroy1 += 10;
        destroy2 += 10;
        destroy3 += 10;
        destroy4 += 10;
        destroy5 += 10;
        destroy6 = 0;
    }

    public void Points(int Pop, int Nat, int Power, int Food)
    {
        pop = Pop;
        nat = Nat;
        power = Power;
        food = Food;
    }

    public void RemovePoints(bool Continue)
    {
        if (!Continue)
        {
            if (allPoints.money >= moneyRequired)
            {
                allPoints.AddPopulation(pop);
                allPoints.AddNature(nat);
                allPoints.AddPower(power);
                allPoints.Addfood(food);
                allPoints.AddMoney(-moneyRequired);
                EnablePanel(false);
            }
        }
        else
        {
            allPoints.AddPopulation(pop);
            allPoints.AddNature(nat);
            allPoints.AddPower(power);
            allPoints.Addfood(food);
        }
    }

    public void OpenConfirmPanel(bool Confirm)
    {
        if (Confirm)
        {
            confirmPanel.SetActive(true);
        }
        else
        {
            confirmPanel.SetActive(false);
        }
    }

    public void OpenPayPanel(bool Pay)
    {
        confirmColor = Pay;
        if (Pay)
        {
            payPanel.SetActive(true);
        }
        else
        {
            payPanel.SetActive(false);
        }
    }

}
