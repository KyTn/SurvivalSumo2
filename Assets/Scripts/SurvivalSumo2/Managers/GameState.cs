using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public static GameState instance;

    void Start() { instance = this; }


    public float XP
    {
        get { return PlayerPrefs.GetFloat("XP", 0); }
        set { PlayerPrefs.SetFloat("XP", value); }
    }

    public float nextLevelXP
    {
        get { return GetNextLevelXP(); }
    }

    private float GetNextLevelXP()
    {
        return PlayerLevel * 50;
    }

    public int PlayerLevel
    {
        get { return PlayerPrefs.GetInt("PlayerLevel", 0); }
        set { PlayerPrefs.SetInt("PlayerLevel", value); }
    }

    // Cálculo del nivel en funcion de la XP siguiendo la progresión 50, 100, 150, 200 ... 
    private int GetLevelOfXP(float XP)
    {
        float _XP = XP;
        int level = 1;
        while (_XP > 0)
        {
            if (_XP > (level - 1) * 50 + 50)
            {
                _XP -= (level - 1) * 50 + 5;
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


    #region ITEMS

    private string[] itemNames = {
        "Cowboy hat","Cowboy jacket","Cowboy boots", 
        "Fighting Mask","Boxing gloves","Boxing boots",
        "Knight helmet","Knight sword","Knight footwear",
        "Pirate hat","Parrot","Pirate jacket", "Pirate boots",
        "Chef hat","Chef jacket","Frying pan",
        "Ballet ring","Ballet skirt","Ballet shoes",
        "Ears of cat","Paw cat", "Cat tail", 
        "Hair Super Saiyan", "Kimono Super Saiyan", "Kame Ame Wave",  
        "Angel Halo","Angel wings","Mercury boots" 
    };

    public Dictionary<string, int> _itemPartsCollected;
    public Dictionary<string, int> itemPartsCollected
    {
        get
        {
            foreach(string id in itemNames){
                if (!_itemPartsCollected.ContainsKey(id))
                {
                    _itemPartsCollected.Add(id, PlayerPrefs.GetInt(id+"_Parts", 0));
                }
            }
            return _itemPartsCollected;
        }
    }


    public Dictionary<string, bool> _ItemsObtained;
    public Dictionary<string, bool> ItemsObtained
    {
        get
        {
            foreach (string id in itemNames)
            {
                if (!ItemsObtained.ContainsKey(id))
                {
                    _ItemsObtained.Add(id, PlayerPrefs.GetInt(id + "_Obtained", 0) == 1);
                }
            }
            return _ItemsObtained;
        }
    }

    #endregion

}
