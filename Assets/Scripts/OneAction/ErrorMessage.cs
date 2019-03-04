using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour {

    public int steps;
    public Color newColor;
    public Text errorText1;
    public Text errorText2;
    public Text errorText3;
    public float change;
    public float number;

    private InstatiateErrorMessage instatiateError;

    public void Start()
    {
        instatiateError = GameObject.Find("ShopMenu").GetComponent<InstatiateErrorMessage>();
        errorText1.text = instatiateError.text;
        errorText2.text = instatiateError.text;
        errorText3.text = instatiateError.text;
    }

    void Update () {
        StartCoroutine(ChangeColor());
        transform.Translate(Vector3.up * 70 * Time.deltaTime);
        Destroy(gameObject, 2f);       
    }

    IEnumerator ChangeColor()
    {
        if (Time.time > number)
        {
            errorText1.color = Color.Lerp(errorText1.color, newColor, steps * Time.deltaTime);
            errorText2.color = Color.Lerp(errorText2.color, newColor, steps * Time.deltaTime);
            errorText3.color = Color.Lerp(errorText3.color, newColor, steps * Time.deltaTime);
            number = Time.time + change;
        }
        yield return null;
    } 
}
