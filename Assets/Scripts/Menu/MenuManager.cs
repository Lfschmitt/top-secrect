using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Text confirmText;
    public GameObject confirmPanel;

    private SaveController saveController;

    private void Start()
    {
        saveController = GameObject.Find("LevelManager").GetComponent<SaveController>();
    }

    public void StartGame() {
        if (PlayerPrefs.GetInt("SaveGame") == 1)
        {
            SetPanelConfirm(true);
            confirmText.text = PlayerPrefs.GetInt("Days").ToString() + " Days";
        }
        else
        {
            ChangeScene(true); ;
        }
    }

    public void LoadGame()
    {
        if(PlayerPrefs.GetInt("SaveGame") == 1)
        {
            ChangeScene(false);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("SaveGame", 1);
        ChangeScene(true);
    }

    public void SetPanelConfirm(bool Bool)
    {
        confirmPanel.SetActive(Bool);
    }

    public void ChangeScene(bool newGame )
    {
        if(newGame == true)
        {
            PlayerPrefs.SetInt("NewGame", 1);
        }
        else
        {
            PlayerPrefs.SetInt("NewGame", 0);
        }
        SceneManager.LoadScene("World");
        SceneManager.UnloadSceneAsync("Menu");
    }
}
