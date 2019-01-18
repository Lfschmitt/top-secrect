using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject shop;
    public GameObject pointsMenu;
    public GameObject exitPanel;
    public void Shop(bool name)
    {
        shop.SetActive(name);
    }
    public void PointsMenu(bool name)
    {
        pointsMenu.SetActive(name);
    }
    public void ExitPanel(bool name)
    {
        exitPanel.SetActive(name);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("World");
    }
}
