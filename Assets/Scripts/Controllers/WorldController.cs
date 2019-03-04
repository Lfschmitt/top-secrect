using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{ 
    public SpriteController[] days;

    private ChangeSpritesWhenClckOnWorld changeSprites;
    private bool changed;

    private void Start()
    {
        changeSprites = GameObject.Find("UpdateWorld").GetComponent<ChangeSpritesWhenClckOnWorld>();
    }

    public void ChangeWorld()
    {
        if (changed)
            days[0].image.sprite = days[0].sprites[0];
        else
            days[0].image.sprite = days[0].sprites[1];

        changeSprites.Trade(changed);
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