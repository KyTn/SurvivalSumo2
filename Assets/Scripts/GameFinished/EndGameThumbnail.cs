using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameThumbnail : MonoBehaviour {

    //public static Texture2D thumbnail;

    public GameObject victoryObject;
    public GameObject defeatObject;
    public GEAnim winAnimation;


	// Use this for initialization
	void Start () {
        //GetComponent<RawImage>().texture = thumbnail;
        if (PlayerPrefs.GetInt("LastGameWon", 0) == 1)
        {
            victoryObject.SetActive(true);

            GEAnimSystem.Instance.MoveIn(winAnimation.transform, true);
        }
        else
        {
            defeatObject.SetActive(true);
            GEAnimSystem.Instance.MoveIn(defeatObject.transform, true);
        }

	}
	
    //// Update is called once per frame
    //void Update () {
	
    //}
}
