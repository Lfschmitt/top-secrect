using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorActivity : MonoBehaviour
{
    //Reference to button to access its components
    public Button theButton;

    //this get the Transitions of the Button as its pressed
    public ColorBlock theColor;

    // Use this for initialization
    void Awake()
    {
       // theButton = GetComponent<Button>();
        theColor = GetComponent<Button>().colors;

    }

    public void RedButton()
    {

        theColor.highlightedColor = Color.red;
        theColor.normalColor = Color.red;

        theButton.colors = theColor;;
    }

    public void NormalButton()
    {

        theColor.highlightedColor = Color.white;
        theColor.normalColor = Color.white;

        theButton.colors = theColor;
    }
}

