using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  GameManager : MonoBehaviour {

    public static GameManager instance;

    public int level;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Hay más de una instancia");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
