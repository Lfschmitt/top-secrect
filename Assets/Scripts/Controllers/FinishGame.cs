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

    private Vibration vibration;
    private MusicController musicController;

    private void Start()
    {
        vibration = GetComponent<Vibration>();
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
    }
    public void WinGame(int days, string name)
    {
        winPanel.SetActive(true);
        musicController.Win();
        winText.text = name;
        daysText.text = days.ToString();
    }

    public void LoseGame(string name)
    {
        losePanel.SetActive(true);
        musicController.Lose();
        loseText.text = name;
    }

    public void ClosePanels()
    {
        vibration.vibrate = true;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        destroyPanel.SetActive(false);
    }
}
