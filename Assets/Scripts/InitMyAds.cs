using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class InitMyAds : MonoBehaviour {

    public bool debug;

	// Use this for initialization
    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("71704",debug);
        }
        else
        {
            Debug.Log("Platform not supported");
        }
        Advertisement.debugLevel = Advertisement.DebugLevel.Debug;

        //Advertisement.UnityDeveloperInternalTestMode = debug;

        Debug.Log("Advertisement listo y preparado =D");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
