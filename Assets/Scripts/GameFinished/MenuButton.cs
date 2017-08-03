using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

    //// Use this for initialization
    //void Start () {
	
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMenu();
        }
    }

    public void GoToMenu()
    {
        Application.LoadLevel("Menu 1");
    }
}
