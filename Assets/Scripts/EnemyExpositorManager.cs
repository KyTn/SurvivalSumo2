using UnityEngine;
using System.Collections;

public class EnemyExpositorManager : MonoBehaviour {

    public GameObject[] enemies; 

	// Use this for initialization
	void Start () {
        int pjlevel = PlayerPrefs.GetInt("PlayerLevel",1);
	    for(int i = 0; i < enemies.Length;i++)
        {
            enemies[i].SetActive(i < pjlevel);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
