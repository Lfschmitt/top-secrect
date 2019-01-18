using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour {

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject destroyPanel;

    public Text daysText;
    public Text loseText;
    public Text winText;

    public void WinGame(int days, string name)
    {
        winPanel.SetActive(true);
        winText.text = name;
        daysText.text = days.ToString();
    }

    public void LoseGame(string name)
    {
        losePanel.SetActive(true);
        loseText.text = name;
    }

    public void ClosePanels()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        destroyPanel.SetActive(false);
    }
}
