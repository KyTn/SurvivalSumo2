using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public static GameState instance;

    void Start(){instance = this;}


    public float XP
    {
        get { return PlayerPrefs.GetFloat("XP", 0); }
        set { PlayerPrefs.SetFloat("XP", value); }
    }


    public int PlayerLevel
    {
        get { return GetLevelOfXP(XP); }
    }

    // Cálculo del nivel en funcion de la XP siguiendo la progresión 50, 100, 150, 200 ... 
    private int GetLevelOfXP(float XP)
    {
        float _XP = XP;
        int level = 1;
        while (_XP > 0)
        {
            if (_XP > (level-1) * 50 + 50)
            {
                _XP -= (level-1) * 50 + 5;
                level++;
            }
        }

        return level;
    }

    public int LastDayOfYearPlayed
    {
        get { return PlayerPrefs.GetInt("LastDayPlayed", -1); }
        set { PlayerPrefs.SetInt("LastDayPlayed", value); }
    }

    public int LastDayOfYearMultiplied
    {
        get { return PlayerPrefs.GetInt("LastDayMultiplied", -1); }
        set { PlayerPrefs.SetInt("LastDayMultiplied", value); }
    }

    public int LastGameWon
    {
        get { return PlayerPrefs.GetInt("LastGameWon", 0); }
        set { PlayerPrefs.SetInt("LastGameWon", value); }
    }

    // XP que ha ganado en la partida que acaba de terminar. 
    public float XPEarnedLastGame
    {
        get { return PlayerPrefs.GetFloat("newXP", 0); }
        set { PlayerPrefs.SetFloat("newXP", value); }
    }

    // Nº de juegos que se han jugado en esta sesion
    public float GamesThisSession
    {
        get { return PlayerPrefs.GetFloat("GamesThisSession", 0); }
        set { PlayerPrefs.SetFloat("GamesThisSession", value); }
    }

}
