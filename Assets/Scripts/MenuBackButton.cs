using UnityEngine;
using System.Collections;

public class MenuBackButton : MonoBehaviour {

    //// Use this for initialization
    //void Start () {
	
    //}

    bool ExitMenuShown = false;
    public GameObject ExitMenu;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ExitMenuShown)
            {
                GEAnimSystem.Instance.MoveOut(ExitMenu.transform, true);
                ExitMenuShown = false;
            }
            else
            {
                ExitMenu.SetActive(true);
                GEAnimSystem.Instance.MoveIn(ExitMenu.transform, true);
                ExitMenuShown = true;
            }
        }
	}


    public void Accept()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        GEAnimSystem.Instance.MoveOut(ExitMenu.transform, true);
        ExitMenuShown = false;
    }
}
