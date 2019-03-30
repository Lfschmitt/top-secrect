using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsGeneration : MonoBehaviour {

    public GameObject[] clouds;
    public Transform[] spawners;
    public float timeForGenerate;
    public bool generate;

    private GameObject _go;
    private float storageTime;

    private int numberOfCloud;
    private int nextCloud;

    private int numberOfPosition;
    private int nextPosition;

    private void Start()
    {
        numberOfPosition = Random.Range(0, spawners.Length);
        numberOfCloud = Random.Range(0, clouds.Length);
        storageTime = Time.time + 2f;
    }

    void Update () {
        if (generate)
        {
            if(Time.time > storageTime){
                DontRepeatCloudOrPosition();
                GenerateRandomCloud();
                storageTime += timeForGenerate;
            }
        }
        
	}
    void DontRepeatCloudOrPosition()
    {
        nextCloud = Random.Range(0, clouds.Length);
        while (numberOfCloud == nextCloud)
            nextCloud = Random.Range(0, clouds.Length);

        nextPosition = Random.Range(0, spawners.Length);
        while (numberOfPosition == nextPosition)
            nextPosition = Random.Range(0, spawners.Length);
    }
    void GenerateRandomCloud()
    {
        _go = Instantiate(clouds[numberOfCloud], spawners[numberOfPosition]);
        _go.transform.SetParent(this.transform);

        numberOfCloud = nextCloud;
        numberOfPosition = nextPosition;
    }
}
