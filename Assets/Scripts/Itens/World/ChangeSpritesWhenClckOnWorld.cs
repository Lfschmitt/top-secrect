using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpritesWhenClckOnWorld : MonoBehaviour {

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

    public void Trade(bool active)
    {
        population.ChangeWorld(active);
        energy.ChangeWorld(active);
        food.ChangeWorld(active);
        technology.ChangeWorld(active);
        army.ChangeWorld(active);
        science.ChangeWorld(active);
    }
}
