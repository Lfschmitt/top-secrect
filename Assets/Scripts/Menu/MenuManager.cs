using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Text confirmText;
    public GameObject confirmPanel;
    public GameObject menu;
    public GameObject panel1;
    public GameObject panel2;

    private SaveController saveController;

    private void Start()
    {
        saveController = GameObject.Find("PointsController").GetComponent<SaveController>();
    }

    public void StartGame() {
        if (PlayerPrefs.GetInt("SaveGame") == 1)
        {
            SetPanelConfirm(true);
            confirmText.text = PlayerPrefs.GetInt("Days").ToString() + " Days";
        }
        else
        {
            SetMenu(false);
        }
    }

    public void LoadGame()
    {
        if(PlayerPrefs.GetInt("SaveGame") == 1)
        {
            saveController.LoadData();
            SetMenu(false);
        }
    }

    public void NewGame()
    {
        saveController.DeleteData();
        saveController.ResetData();
        saveController.SaveData();
        PlayerPrefs.SetInt("SaveGame", 1);
        SetMenu(false);
    }

    public void SetPanelConfirm(bool Bool)
    {
        confirmPanel.SetActive(Bool);
    }
    public void SetMenu(bool Bool)
    {
        menu.SetActive(Bool);
    }
    public void DisableEndScreens()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
    }
}
