using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateErrorMessage : MonoBehaviour {

    public GameObject ErrorMessage;
    public string text;
    public bool set;

    private void Update()
    {
        if (set)
        {
            Instantiate(text);
            set = !set;
        }
    }

    public void Instantiate(string name)
    {
        text = name;
        var myNewSmoke = Instantiate(ErrorMessage, transform.position, transform.rotation);
        myNewSmoke.transform.parent = gameObject.transform;
    }
}
