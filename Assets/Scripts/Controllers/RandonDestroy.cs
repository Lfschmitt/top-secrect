using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandonDestroy : MonoBehaviour {

    public int destroy1, destroy2, destroy3, destroy4, destroy5, destroy6;
    public GameObject panel;
    public int maxDays;
    public int minDays;
    public Text text;

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

        panel.SetActive(name);
    }

    private void Tsunami()
    {
        EnablePanel(true);
        vibration.Vibrate();
        text.text = "some cities were hit by a tsunami the planet's status suffered a little";
        allPoints.AddPopulation(-30);
        allPoints.AddNature(-30);

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
        allPoints.AddPopulation(-30);
        allPoints.AddNature(-30);
        allPoints.AddPower(-10);

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
        text.text = "some generators of ernergia were hit by a storm and were turned off";
        allPoints.AddPower(-50);

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
        allPoints.Addfood(-40);

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
        text.text = "a volcano erupted and deforested large areas with nature";
        allPoints.AddNature(-75);

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
        text.text = "a hurricane destroyed some house and left many people injured";
        allPoints.AddPopulation(-50);

        destroy1 += 10;
        destroy2 += 10;
        destroy3 += 10;
        destroy4 += 10;
        destroy5 += 10;
        destroy6 = 0;
    }
}
