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
        levelText.text = PlayerPrefs.GetInt("PlayerLevel", 1).ToString();
        //currentLevelText.text = "Level " + PlayerPrefs.GetInt("PlayerLevel", 1);
        //nextLevelText.text = "Level " + (PlayerPrefs.GetInt("PlayerLevel", 1)+1);

	    xpSlider.maxValue = xpForNextLevel[PlayerPrefs.GetInt("PlayerLevel", 1)-1];
        xpSlider.value = PlayerPrefs.GetFloat("XP", 0);

        float multiplier = 1;
        if (PlayerPrefs.GetInt("LastDayPlayed", -1) == DateTime.Now.DayOfYear && PlayerPrefs.GetInt("LastDayMultiplied", -1)!= DateTime.Now.DayOfYear)
        {
            multiplier = 2;
            PlayerPrefs.SetInt("LastDayMultiplied", DateTime.Now.DayOfYear);
        }
        if (PlayerPrefs.GetInt("LastGameWon", 0) == 1)
        {
            PlayerPrefs.SetFloat("XP", PlayerPrefs.GetFloat("XP", 0) + (PlayerPrefs.GetFloat("newXP", 0) * multiplier));
        }
        else
        {
            PlayerPrefs.SetFloat("XP", PlayerPrefs.GetFloat("XP", 0) + 5);
        }
        finalXP = PlayerPrefs.GetFloat("XP", 0);
        if (PlayerPrefs.GetFloat("XP", 0) >= xpSlider.maxValue)
        {
            PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel", 1) + 1);
            LevelUp = true;
            //nextLevelText.color = Color.yellow;
            levelText.color = Color.red;
            PlayerPrefs.SetFloat("XP", 0);
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
