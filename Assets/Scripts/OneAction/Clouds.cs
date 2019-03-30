using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clouds : MonoBehaviour {

    [Range(0, 100)]
    public float speed;
    private Image image;

    private Color color;
    private NightController nightController;
    private Transform destroyPoint;
    private void Start()
    {
        destroyPoint = GameObject.Find("DestroyPoint").GetComponent<Transform>();
        nightController = GameObject.Find("TimeController").GetComponent<NightController>();
        image = GetComponent<Image>();
        color.a = 1f;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (destroyPoint.position.x > transform.position.x)
            Destroy(gameObject);

        if (nightController.day)
        {
            color.r = 1f;
            color.g = 1f;
            color.b = 1f;
            image.color = color;
        }
        else
        {
            color.r = 0.2f;
            color.g = 0.2f;
            color.b = 0.2f;
            image.color = color;
        }
	}
}
