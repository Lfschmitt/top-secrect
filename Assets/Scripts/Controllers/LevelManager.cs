using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject pointsMenu1;
    public GameObject pointsMenu2;

    public Text buttonPointsText;
    public string nameTheme;
    public Animator shopAnimator;
    public Animator exitAnimator;
    public Animator pointsAnimator;

    private bool changeLock = true;
    private MusicController musicController;

    private void Start()
    {
        musicController = GetComponent<MusicController>();
        StartCoroutine(Music());
    }

    public void Shop(bool name)
    {
        shopAnimator.SetBool("IsOpen", name);
    }
    public void PointsMenu(bool name)
    {
        pointsAnimator.SetBool("IsOpen", name);
    }
    public void ExitPanel(bool name)
    {
        exitAnimator.SetBool("IsOpen",name);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("World");
    }

    public void CloseAllPanels()
    {
        Shop(false);
        PointsMenu(false);
        ExitPanel(false);
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
