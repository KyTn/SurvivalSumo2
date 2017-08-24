using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public static GameState instance;

    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);


        _itemPartsCollected = new Dictionary<string, int>();
        foreach (string id in itemNames)
        {
            if (!_itemPartsCollected.ContainsKey(id))
            {
                _itemPartsCollected.Add(id, PlayerPrefs.GetInt(id + "_Parts", 0));
            }
        }


        _itemPartsTotal = new Dictionary<string, int>();
        foreach (string id in itemNames)
        {
            if (!_itemPartsTotal.ContainsKey(id))
            {
                _itemPartsTotal.Add(id, PlayerPrefs.GetInt(id + "_Total", 0));
            }
        }


        _ItemsObtained = new Dictionary<string, bool>();
        foreach (string id in itemNames)
        {
            if (!ItemsObtained.ContainsKey(id))
            {
                _ItemsObtained.Add(id, PlayerPrefs.GetInt(id + "_Obtained", 0) == 1);
            }
        }


        _PlayerEquip = new Dictionary<Item.ItemTypePart, string>(); PlayerEquip.ContainsKey(Item.ItemTypePart.Back);
        string backid = PlayerPrefs.GetString(Item.ItemTypePart.Back + "", "");
        string bodyid = PlayerPrefs.GetString(Item.ItemTypePart.Body + "", "");
        string feetid = PlayerPrefs.GetString(Item.ItemTypePart.Feet + "", "");
        string handsid = PlayerPrefs.GetString(Item.ItemTypePart.Hands + "", "");
        string headid = PlayerPrefs.GetString(Item.ItemTypePart.Head + "", "");

        if (backid != "" && !_PlayerEquip.ContainsKey(Item.ItemTypePart.Back)) { _PlayerEquip.Add(Item.ItemTypePart.Back, backid); }
        if (bodyid != "" && !_PlayerEquip.ContainsKey(Item.ItemTypePart.Body)) { _PlayerEquip.Add(Item.ItemTypePart.Body, bodyid); }
        if (feetid != "" && !_PlayerEquip.ContainsKey(Item.ItemTypePart.Feet)) { _PlayerEquip.Add(Item.ItemTypePart.Feet, feetid); }
        if (handsid != "" && !_PlayerEquip.ContainsKey(Item.ItemTypePart.Hands)) { _PlayerEquip.Add(Item.ItemTypePart.Hands, handsid); }
        if (headid != "" && !_PlayerEquip.ContainsKey(Item.ItemTypePart.Head)) { _PlayerEquip.Add(Item.ItemTypePart.Head, headid); }

    }


    #region XP & PlayerLevel

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


    // XP que ha ganado en la partida que acaba de terminar. 
    public float XPEarnedLastGame
    {
        get { return PlayerPrefs.GetFloat("newXP", 0); }
        set { PlayerPrefs.SetFloat("newXP", value); }
    }

    #endregion


    #region Times played, etc

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


    // Nº de juegos que se han jugado en esta sesion
    public float GamesThisSession
    {
        get { return PlayerPrefs.GetFloat("GamesThisSession", 0); }
        set { PlayerPrefs.SetFloat("GamesThisSession", value); }
    }


    #endregion 


    #region ITEMS

    public string[] itemNames = {
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
            return _itemPartsCollected;
        }
    }

    public Dictionary<string, int> _itemPartsTotal;
    public Dictionary<string, int> itemPartsTotal
    {
        get
        {
            return _itemPartsTotal;
        }
    }

    public Dictionary<string, bool> _ItemsObtained;
    public Dictionary<string, bool> ItemsObtained
    {
        get
        {
            return _ItemsObtained;
        }
    }


    private Dictionary<Item.ItemTypePart, string> _PlayerEquip;
    public Dictionary<Item.ItemTypePart, string> PlayerEquip
    {
        get
        {
            return _PlayerEquip;
        }
    }
    #endregion




    public void Save()
    {
        foreach (string id in _itemPartsCollected.Keys)
        {
            PlayerPrefs.SetInt(id + "_Parts", _itemPartsCollected[id]);
        }

        foreach (string id in _ItemsObtained.Keys)
        {
            PlayerPrefs.SetInt(id + "_Obtained", _ItemsObtained[id] ? 1 : 0);
        }

        foreach (Item.ItemTypePart id in _PlayerEquip.Keys)
        {
            PlayerPrefs.SetString(id + "", _PlayerEquip[id]);
        }
        

    }



}
