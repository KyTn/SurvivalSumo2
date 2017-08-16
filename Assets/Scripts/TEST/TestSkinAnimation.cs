using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSkinAnimation : MonoBehaviour {

    public Text infoText;


    public ChangeItemsOnPlayer changeItemsOnPlayer;
    public SyncAnimPlayer sync;

    float nextChangeTime = 0;
    public float secondsBetweenChange = 2;

    int index = 0;


	// Use this for initialization
	void Start () {
        nextChangeTime = Time.time + secondsBetweenChange;
	}
	
	// Update is called once per frame
	void Update () {

        if (nextChangeTime <= Time.time)
        {
            sync.Piernas++;
            sync.Brazos++;

            if (sync.Piernas > 4)
            {
                sync.Piernas = 0;
                sync.Brazos = 0;

                index++;
                index = changeItemsOnPlayer.skins_meshes.Length + changeItemsOnPlayer.skins_skinnedMeshes.Length <= index ? 0 : index;
                changeItemsOnPlayer.index = index;
            }


            
            nextChangeTime = Time.time + secondsBetweenChange;
        }


        infoText.text = "Actual animator value: (Piernas:" + sync.Piernas + ", Brazos:" + sync.Brazos + ")\nIndex of Skin Testing: " + index+"\nNext testing in "+(int)(nextChangeTime-Time.time);

	}
}
