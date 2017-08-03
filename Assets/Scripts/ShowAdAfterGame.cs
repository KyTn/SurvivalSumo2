using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class ShowAdAfterGame : MonoBehaviour {

    private const string DateTimeOffsetFormatString = "yyyy-MM-ddTHH:mm:sszzz";
    private DateTime date;

    public float minutesBetweenAds = 5;
    public int maxDailyAds = 10;

    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
    public string eventTime
    {
        get { return date.ToString(DateTimeOffsetFormatString); }
        set { date = DateTime.Parse(value); }
    }

	// Use this for initialization
	void Start () {
        string d = PlayerPrefs.GetString("lastShownAd", "");
        if (d == "")
        {
            ShowAd();
        }
        else
        {
            eventTime = d;
            if (date.DayOfYear != DateTime.Now.DayOfYear)
            {
                PlayerPrefs.SetInt("adsSeenToday", 0);
            }
            if (date.AddMinutes(minutesBetweenAds) < DateTime.Now && PlayerPrefs.GetInt("adsSeenToday", 0) < maxDailyAds)
            {
                ShowAd();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Analytics.CustomEvent("WatchingAdPostGame", new Dictionary<string, object>
			                      {
				{ "AdReady", "yes" }
			});
            date = DateTime.Now;
            PlayerPrefs.SetString("lastShownAd", eventTime);
            PlayerPrefs.SetInt("maxDailyAds", PlayerPrefs.GetInt("maxDailyAds", 0));
            //TODO: reactivar los anuncios cuando sea apropiado
            Advertisement.Show();
        }
        else
        {
            Analytics.CustomEvent("WatchingAdPostGame", new Dictionary<string, object>
			                      {
				{ "AdReady", "no" }
			});
        }
    }
}
