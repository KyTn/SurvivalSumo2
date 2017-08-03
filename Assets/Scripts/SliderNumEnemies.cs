using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderNumEnemies : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR
        if (Application.isPlaying) //if in the editor, need to check if we are playing, as start is also called just after exiting play
#endif
        {
            slider.value = PlayerPrefs.GetInt("numEnemies", 3);
        }
    }
	
    //// Update is called once per frame
    //void Update () {
	
    //}

    public Slider slider;


    public void ChangeNumEnemies(float n)
    {
        PlayerPrefs.SetInt("numEnemies", (int)n);
        //Debug.Log("Changed to " + (int)n);
    }
}
