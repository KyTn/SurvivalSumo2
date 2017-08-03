using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using System.Collections.Generic;
using UnityEngine.Analytics;
using System;

public class ShowOneAd : MonoBehaviour
{

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}

    public void ShowIt()
    {
        //throw new Exception("Solo estoy probando");
        //return;
        Debug.Log("Showing ad...");
        if (Advertisement.IsReady())
		{
			Analytics.CustomEvent("WatchingAdFree", new Dictionary<string, object>
			                      {
				{ "AdReady", "yes" }
			});
            Advertisement.Show();
        }
        else
		{
			Analytics.CustomEvent("WatchingAdFree", new Dictionary<string, object>
			                      {
				{ "AdReady", "no" }
			});
            Debug.Log("Pues no, no estaba listo");
        }

    }
}
