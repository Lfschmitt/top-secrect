using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpritesWhenClckOnWorld : MonoBehaviour {

    private Population population;
    private Energy energy;

    private void Start()
    {
        population = GetComponent<Population>();
        energy = GetComponent<Energy>();
    }

    public void Trade(bool active)
    {
        population.ChangeWorld(active);
        energy.ChangeWorld(active);
    }
}
