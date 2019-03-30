using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorActivity : MonoBehaviour
{
    //Reference to button to access its components
    public Image[] theButton;

    //this get the Transitions of the Button as its pressed
    public Color theColor;

    // Use this for initialization
    public void RedButton(int number)
    {
        theColor.r = 1f;
        theColor.g = 0f;
        theColor.b = 0f;

        theButton[number].color = theColor;
    }

    public void NormalButton(int number)
    {

        theColor.r = .6f;
        theColor.g = .6f;
        theColor.b = .6f;

        theButton[number].color = theColor;
    }

    public void GrayButton()
    {
        theButton[0].color = theColor;
    }
}

