using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateErrorMessage : MonoBehaviour {

    public GameObject ErrorMessage;
    public Transform[] spawnsPosition;
    public string text;

    public void Instantiate(string name, int whatPoosition)
    {
        text = name;
        var myNewSmoke = Instantiate(ErrorMessage, spawnsPosition[whatPoosition].position, spawnsPosition[whatPoosition].rotation);
        myNewSmoke.transform.parent = gameObject.transform;
    }
}
