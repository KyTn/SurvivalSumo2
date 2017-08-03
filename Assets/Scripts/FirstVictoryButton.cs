using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class FirstVictoryButton : MonoBehaviour
{





    // Use this for initialization
    void Start()
    {
        int lastDay = PlayerPrefs.GetInt("LastDayPlayed", -1);

        if (DateTime.Now.DayOfYear == lastDay)
        {
            gameObject.SetActive(false);
        }

    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void WatchAd()
    {
        Analytics.CustomEvent("WatchAdForDoubleXP", new Dictionary<string, object>
			                      {
				{ "pressed", "1" }
			});
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Analytics.CustomEvent("AdForDoubleXPISReady", new Dictionary<string, object>
			                      {
				{ "AdReady", "yes" }
			});


            PlayerPrefs.SetInt("LastDayPlayed", DateTime.Now.DayOfYear);
            Advertisement.Show("rewardedVideo");
            gameObject.SetActive(false);
        }
        else
        {
            Analytics.CustomEvent("WatchingAdFree", new Dictionary<string, object>
			                      {
				{ "AdReady", "no" }
			});
        }
    }
}
