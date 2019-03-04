using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBuy : MonoBehaviour {

    private Population population;
    private Energy energy;

    private void Start()
    {
        population = GetComponent<Population>();
        energy = GetComponent<Energy>();
    }

    public void First(int count)
    {
        if (count == 2)
            population.FirstBuy();
        else if(count == 7)
            energy.FirstBuy();

    }
}
