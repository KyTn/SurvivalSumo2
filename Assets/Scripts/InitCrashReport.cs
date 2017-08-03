using UnityEngine;
using System.Collections;
using UnityEngine.CrashLog;

public class InitCrashReport : MonoBehaviour {
    static bool init = false;

    void Awake()
    {
        if (!init)
        {
            CrashReporting.Init("b3a6e0d2-3b4f-47f0-be7c-330969321a53", "0.0.0", "Antonio");
            init = true;
        }
    }

    // Use this for initialization
    void Start()
    {

        PlayerPrefs.SetFloat("newXP", 0);
    }
	
    //// Update is called once per frame
    //void Update () {
	
    //}
}
