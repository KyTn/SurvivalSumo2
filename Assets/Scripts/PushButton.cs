using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PushButton : MonoBehaviour {

    public static Character target;
    public Color normalColor;
    public Color loadingColor;

    Image img;

    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.nextPushAvailable > DateTime.Now)
        {
            img.color = loadingColor;
            img.fillAmount = 1 - (float)((target.nextPushAvailable - DateTime.Now).TotalSeconds / target.pushCooldown);
        }
        else
        {
            img.color = normalColor;
            img.fillAmount = 1;
        }
    }
}
