using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    private AllPoints allPoints;
    public SpriteController[] images;

    private bool changed;

    void Start()
    {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
    }

    void Update()
    {

    }

    public void ChangeWorld()
    {
        if (changed)
            images[0].image.sprite = images[0].sprites[0];
        else
            images[0].image.sprite = images[0].sprites[1];

        changed = !changed;
    }
}

[System.Serializable]
public class SpriteController
{
    public string name;
    public Image image;
    public Sprite[] sprites;
}