using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBuy : MonoBehaviour {

    private Population population;
    private Energy energy;
    private Food food;
    private Technology technology;
    private Army army;
    private Science science;

    private void Start()
    {
        population = GetComponent<Population>();
        energy = GetComponent<Energy>();
        food = GetComponent<Food>();
        technology = GetComponent<Technology>();
        army = GetComponent<Army>();
        science = GetComponent<Science>();
    }

    public void First(int count)
    {
        if (count == 0)
            technology.FirstBuy();
        else if (count == 1)
            science.FirstBuy();
        else if (count == 2)
            population.FirstBuy();
        else if (count == 3)
            army.FirstBuy();
        else if (count == 7)
            energy.FirstBuy();
        else if (count == 5)
            food.FirstBuy();
    }
}
