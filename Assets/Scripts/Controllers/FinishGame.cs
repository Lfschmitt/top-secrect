using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour {

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject destroyPanel;
    public GameObject StopClickGames;
    public Text daysText;
    public Text loseText;
    public Text winText;

    private TimeController timeController;
    private Vibration vibration;
    private MusicController musicController;
    private EndGame endGame;

    private void Start()
    {
        endGame = GetComponent<EndGame>();
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        vibration = GetComponent<Vibration>();
        musicController = GameObject.Find("LevelManager").GetComponent<MusicController>();
    }

    public IEnumerator WinGame(int days, string name)
    {
        StopClickGames.SetActive(true);
        yield return new WaitForSeconds(3f);
        StopClickGames.SetActive(false);
        timeController.GameTime(true);
        winPanel.SetActive(true);
        musicController.Win();
        winText.text = name;
        daysText.text = days.ToString();
    }

    public IEnumerator LoseGame(string name)
    {
        StopClickGames.SetActive(true);
        yield return new WaitForSeconds(3f);
        StopClickGames.SetActive(false);
        timeController.GameTime(true);
        losePanel.SetActive(true);
        musicController.Lose();
        loseText.text = name;
    }

    public void ClosePanels()
    {
        endGame.ChangeOneTimeValue(true);
        timeController.GameTime(false);
        vibration.vibrate = true;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        destroyPanel.SetActive(false);
    }
}
