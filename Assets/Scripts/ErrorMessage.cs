using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour {

    public int steps;
    public Color newColor;
    public Text errorText;
    public float change;
    public float number;

    private InstatiateErrorMessage instatiateError;

    public void Start()
    {
        instatiateError = GameObject.Find("ErrorMessage").GetComponent<InstatiateErrorMessage>();
        errorText.text = instatiateError.text; 
    }

    void Update () {
        StartCoroutine(ChangeColor());
        transform.Translate(Vector3.up * 70 * Time.deltaTime);
        Destroy(gameObject, 4f);       
    }

    IEnumerator ChangeColor()
    {
        if (Time.time > number)
        {
            errorText.color = Color.Lerp(errorText.color, newColor, steps * Time.deltaTime);
            number = Time.time + change;
        }
        yield return null;
    } 
}
