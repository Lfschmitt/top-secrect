using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightController : MonoBehaviour {

    public Image panel;
    public GameObject panelNight;
    public Image[] stars;
    public Sprite[] spritesStars;
    public bool day = true;

    private float x = 1;
    private float y = 0.2f;
    private int count = 0;
    private float changeDay = 0.8f;
    private float changeNight = 0f;
    private Color color;

    private void Start()
    {
        x = Time.time + y;
    }
    void Update()
    { 
        if(Time.time > x)
        {
            stars[0].sprite = spritesStars[count];
            stars[1].sprite = spritesStars[count];
            stars[2].sprite = spritesStars[count];
            stars[3].sprite = spritesStars[count];
            stars[4].sprite = spritesStars[count];
            stars[5].sprite = spritesStars[count];

            count++;
            if (count >= spritesStars.Length)
                count = 0;
            x += y;
        }      
    }

    public IEnumerator StayDay()
    {
        day = true;
        for (int x = 0; x < 17; x++)
        {
            color.a = changeDay;
            changeDay -= 0.05f;
            panel.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        EnableStars(false);
        changeDay = 0.8f;
    }

    public IEnumerator StayNight()
    {
        day = false;
        EnableStars(true);
        for (int x = 0; x < 17; x++)
        {
            color.a = changeNight;
            changeNight += 0.05f;
            panel.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        changeNight = 0f;
    }

    void EnableStars (bool enable)
    {
        panelNight.SetActive(enable);
    }
}
