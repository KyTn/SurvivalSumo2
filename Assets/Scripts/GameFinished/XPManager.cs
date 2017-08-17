using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class XPManager : MonoBehaviour {

    int[] xpForNextLevel = { 50, 100, 250, 500, 1000, 2000, 5000, 10000, 50000 };

    public Slider xpSlider;
    float finalXP = 0;
    bool LevelUp = false;

    public GameObject LevelUpAdvertising;

    //public Text currentLevelText;
    //public Text nextLevelText;
    public Text levelText;

	// Use this for initialization
	void Start () {
        levelText.text = GameState.instance.PlayerLevel.ToString();
        //currentLevelText.text = "Level " + PlayerPrefs.GetInt("PlayerLevel", 1);
        //nextLevelText.text = "Level " + (PlayerPrefs.GetInt("PlayerLevel", 1)+1);

        xpSlider.maxValue = GameState.instance.nextLevelXP;
        xpSlider.value = GameState.instance.XP;

        float multiplier = 1;
        if (GameState.instance.LastDayOfYearPlayed == DateTime.Now.DayOfYear && GameState.instance.LastDayOfYearMultiplied != DateTime.Now.DayOfYear)
        {
            multiplier = 2;
            GameState.instance.LastDayOfYearMultiplied = DateTime.Now.DayOfYear;
        }
        if (GameState.instance.LastGameWon == 1)
        {
            GameState.instance.XP += GameState.instance.XPEarnedLastGame * multiplier;
        }
        else
        {
            GameState.instance.XP += 5;
        }
        finalXP = GameState.instance.XP;
        if (GameState.instance.XP >= GameState.instance.nextLevelXP)
        {
            //PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel", 1) + 1);
            GameState.instance.PlayerLevel++;
            LevelUp = true;
            //nextLevelText.color = Color.yellow;
            levelText.color = Color.red;
            //PlayerPrefs.SetFloat("XP", 0);
        }

        PlayerPrefs.SetFloat("newXP", 0);

        LevelUpAdvertising.SetActive(LevelUp);
        if (LevelUp)
        {
            Analytics.CustomEvent("LevelUp", new Dictionary<string, object>
			                      {
				{ "Level", PlayerPrefs.GetInt("PlayerLevel", 1)+"lvl" }
			});
        }
	}
	
	// Update is called once per frame
	void Update () {
        xpSlider.value = Mathf.Lerp(xpSlider.value, finalXP, 0.01f);
	}
}
