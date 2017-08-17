using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIController_MainMenu : MonoBehaviour {

    public GameObject MainCam;
    public Transform Cam_To_Inventario, Cam_To_Main, Cam_To_Play, Cam_To_Botin;

    public RectTransform DownButtons, Inventario, FirstVictoryAds, MusicBy, ReallyExit, Levels, TopInfo, Back_button, Botin;








	// Use this for initialization
    void Start()
    {
        GOTO_Main();
	}
	


#region GOTO Functions

    public void GOTO_Play()
    {
        MainCam.transform.DOMove(Cam_To_Play.position, 1f);
        MainCam.transform.DORotate(Cam_To_Play.rotation.eulerAngles, 1f);


        // sacando fuera los paneles que no va a usasr en el start
        DownButtons.DOAnchorPos(Vector2.down * 200, 0.4f);
        Inventario.DOAnchorPos(Vector2.left * 600, 0.4f);
        FirstVictoryAds.DOAnchorPos(Vector2.up * 600, 0.4f);
        MusicBy.DOAnchorPos(Vector2.down * 200, 0.4f);
        ReallyExit.DOAnchorPos(Vector2.left * 1000, 0.4f);
        Levels.DOAnchorPos(Vector2.zero, 0.4f); // <----------------
        Back_button.DOAnchorPos(Vector2.zero, 0.4f);//<----------

        // Desactivando los paneles que no van a usarse en el start
        DownButtons.gameObject.SetActive(false);
        Inventario.gameObject.SetActive(false);
        FirstVictoryAds.gameObject.SetActive(false);
        MusicBy.gameObject.SetActive(false);
        ReallyExit.gameObject.SetActive(false);
       // Botin.gameObject.SetActive(false);
        Levels.gameObject.SetActive(true); // <-----------
        Back_button.gameObject.SetActive(true); //<----------
    }

    public void GOTO_Botin() 
    {
        MainCam.transform.DOMove(Cam_To_Botin.position, 1f);
        MainCam.transform.DORotate(Cam_To_Botin.rotation.eulerAngles, 1f);


        // sacando fuera los paneles que no va a usasr en el start
        DownButtons.DOAnchorPos(Vector2.down * 200, 0.4f);
        Inventario.DOAnchorPos(Vector2.left * 600, 0.4f);
        FirstVictoryAds.DOAnchorPos(Vector2.up * 600, 0.4f);
        MusicBy.DOAnchorPos(Vector2.down * 200, 0.4f);
        ReallyExit.DOAnchorPos(Vector2.left * 1000, 0.4f);
        Levels.DOAnchorPos(Vector2.down * 600, 0.4f);
        Back_button.DOAnchorPos(Vector2.zero, 0.4f);
        Botin.DOAnchorPos(Vector2.zero, 0.4f);//<----------

        // Desactivando los paneles que no van a usarse en el start
        DownButtons.gameObject.SetActive(false);
        Inventario.gameObject.SetActive(false);
        FirstVictoryAds.gameObject.SetActive(false);
        MusicBy.gameObject.SetActive(false);
        ReallyExit.gameObject.SetActive(false);
        Levels.gameObject.SetActive(false);
        Back_button.gameObject.SetActive(true);
        //Botin.gameObject.SetActive(true);//<----------
    }

    public void GOTO_Inventario()
    {
        MainCam.transform.DOMove(Cam_To_Inventario.position, 1f);
        MainCam.transform.DORotate(Cam_To_Inventario.rotation.eulerAngles, 1f);

        // sacando fuera los paneles que no va a usasr en el start
        DownButtons.DOAnchorPos(Vector2.down * 200, 0.4f);
        Inventario.DOAnchorPos(Vector2.zero, 0.4f);//<----------
        FirstVictoryAds.DOAnchorPos(Vector2.up * 600, 0.4f);
        MusicBy.DOAnchorPos(Vector2.down * 200, 0.4f);
        ReallyExit.DOAnchorPos(Vector2.left * 1000, 0.4f);
        Levels.DOAnchorPos(Vector2.down * 600, 0.4f);
        Back_button.DOAnchorPos(Vector2.zero, 0.4f);//<----------

        // Desactivando los paneles que no van a usarse en el start
        DownButtons.gameObject.SetActive(false);
        Inventario.gameObject.SetActive(true); //<----------
        FirstVictoryAds.gameObject.SetActive(false);
        MusicBy.gameObject.SetActive(false);
        ReallyExit.gameObject.SetActive(false);
        Levels.gameObject.SetActive(false);
       // Botin.gameObject.SetActive(false);
        Back_button.gameObject.SetActive(true); //<----------
    }

    public void GOTO_Options()
    {

    }

    public void GOTO_Shop()
    {

    }

    public void GOTO_Main()
    {
        MainCam.transform.DOMove(Cam_To_Main.position, 1f);
        MainCam.transform.DORotate(Cam_To_Main.rotation.eulerAngles, 1f);

        // sacando fuera los paneles que no va a usasr en el start
        DownButtons.DOAnchorPos(Vector2.zero, 0.4f); //<---------------
        Inventario.DOAnchorPos(Vector2.left * 600, 0.4f);
        FirstVictoryAds.DOAnchorPos(Vector2.up * 600, 0.4f);
        MusicBy.DOAnchorPos(Vector2.zero, 0.4f); //<---------------
        ReallyExit.DOAnchorPos(Vector2.left * 1000, 0.4f);
        Levels.DOAnchorPos(Vector2.down * 600, 0.4f);
        Back_button.DOAnchorPos(Vector2.down * 600, 0.4f);

        // Desactivando los paneles que no van a usarse en el start
        DownButtons.gameObject.SetActive(true); //<---------------
        Inventario.gameObject.SetActive(false);
        FirstVictoryAds.gameObject.SetActive(false);
        MusicBy.gameObject.SetActive(true); //<---------------
        ReallyExit.gameObject.SetActive(false);
        Levels.gameObject.SetActive(false);
        Back_button.gameObject.SetActive(false);
       // Botin.gameObject.SetActive(false);
    }


#endregion 

    public void UpdateTopInfo(int playerLevel, float actualLevelPercent, int gold )
    {

    }




}
