using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject shop;
    public GameObject pointsMenu;
    public GameObject pointsMenu1;
    public GameObject pointsMenu2;
    public GameObject exitPanel;

    public Text buttonPointsText;
    public string nameTheme;

    private bool changeLock = true;
    private MusicController musicController;

    private void Start()
    {
        musicController = GetComponent<MusicController>();
        StartCoroutine(Music());
    }

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

    public void ChangePointsPanel()
    {
        if (changeLock)
        {
            pointsMenu1.SetActive(false);
            pointsMenu2.SetActive(true);
            buttonPointsText.text = "Back";
            changeLock = !changeLock;
        }
        else
        {
            pointsMenu2.SetActive(false);
            pointsMenu1.SetActive(true);
            buttonPointsText.text = "Next";
            changeLock = !changeLock;
        }
    }

    IEnumerator Music()
    {
        yield return new WaitForSeconds(1f);
        musicController.SoundTheme(nameTheme);
    }
}
