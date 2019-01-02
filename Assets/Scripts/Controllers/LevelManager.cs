using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject shop;
    public GameObject pointsMenu;
    public GameObject destructionPanel;
    public GameObject finishPanel;
    public Text daysText;
    public Text endText;
    public Text finishText;

    private TimeController timeController;
    private AllPoints allpoints;
    private EndGame endgame;

    void Start()
    {
        allpoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        if (allpoints == null)
        {
            Debug.Log("The game object -PointsController- not find in scene");
        }

        endgame = GameObject.Find("PointsController").GetComponent<EndGame>();
        if (endgame == null)
        {
            Debug.Log("The game object -PointsController- not find in scene");
        }

        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        if (timeController == null)
        {
            Debug.Log("The game object -TimeController- not find in scene");
        }
    }

    public void Shop(bool name)
    {
        shop.SetActive(name);
    }

    public void PointsMenu(bool name)
    {
        pointsMenu.SetActive(name);
    }

    public void Panel(string name, bool ft, int panel, int days)
    {
        if (panel == 0)
        {
            destructionPanel.SetActive(ft);
            endText.text = name;
        }
        else if(panel == 1)
        {
            finishPanel.SetActive(ft);
            finishText.text = name;
            daysText.text = "In " + days.ToString() + " Days";
        }
    }

    public void ResetGame()
    {
        Panel(null, false, 0, 0);
        Panel(null, false, 1, 0);
        allpoints.ResetGame();
        timeController.SetDays(0);
        endgame.TimeGame(1);
    }
}
