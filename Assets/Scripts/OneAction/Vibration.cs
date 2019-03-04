using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour {

    public bool vibrate;

    public void Vibrate()
    {
        if (vibrate)
        {
            Handheld.Vibrate();
            vibrate = !vibrate;
        }
    }
}
