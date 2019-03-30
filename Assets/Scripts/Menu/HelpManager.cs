using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour {

    public Animator pages;
    public Animator helpPanel;
    public GameObject nextButton, backButton;
    public Text pageText;
    public int actualPage = 1;

    public void HelpPanelOpen(bool name)
    {
        helpPanel.SetBool("IsOpen", name);
    }

    public void NextPage()
    {
        backButton.SetActive(true);
        if (actualPage < 6)
        {
            pages.SetBool("Page" + (actualPage), false);
            actualPage ++;
            pageText.text = "Page " + actualPage + "/6";
            if(actualPage == 6)
                nextButton.SetActive(false);
        }
    }

    public void BackPage()
    {
        nextButton.SetActive(true);
        if (actualPage > 1)
        {
            actualPage--;
            pages.SetBool("Page" + (actualPage), true);
            pageText.text = "Page " + actualPage + "/6";
            if (actualPage == 1)
                backButton.SetActive(false);
        }
    }
}
