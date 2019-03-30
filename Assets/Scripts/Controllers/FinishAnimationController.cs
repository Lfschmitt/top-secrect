using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAnimationController : MonoBehaviour {

    public Animator populationWin;
    public Animator scienceWin;

    public void PopulationWinAnimation(bool name)
    {
        populationWin.SetBool("IsOpen", name);
    }

    public void ScienceTechnologyWinAnimation(bool name)
    {
        scienceWin.SetBool("IsActive", name);
    }
    public void StopAllAnimation()
    {
        PopulationWinAnimation(false);
        ScienceTechnologyWinAnimation(false);
    }
}
