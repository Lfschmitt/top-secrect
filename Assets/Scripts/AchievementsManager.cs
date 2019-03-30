using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour {

    public static AchievementsManager Instance { get; private set; }

	// Use this for initialization
	void Start () {
        Instance = this;	
	}

    public void UnlockAchievementWinPopulation()
    {
        PlayGamesScript.UnlockAchievement(GPGSIds.achievement_win_population);
    }

	public void ShowAchievements()
    {
        PlayGamesScript.ShowAchievementsUI();
    }
}
