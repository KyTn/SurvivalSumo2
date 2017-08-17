using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class FightManager : MonoBehaviour {

    public int charactersAlive = 0;
    public bool playerIsAlive = true;

    public static FightManager instance;

    public GameObject Player;
    public GameObject[] Enemies;

    public Transform SpawnPoint;

    public Transform SpawnSystem;

    public delegate void CharacterEvent(Transform t);
    public event CharacterEvent characterDies;

    int initialEnemies = 0;

    void Awake()
    {
        instance = this;
        EnemyController.fighters.Clear();
    }

	// Use this for initialization
	void Start () {
        InitializeBattle();

       // Everyplay.StartRecording();
        //Everyplay.SetThumbnailTargetTexture(EndGameThumbnail.thumbnail);
	}


    public void InitializeBattle()
    {
        Instantiate(Player, SpawnPoint.position, SpawnPoint.rotation);
        int enemies = PlayerPrefs.GetInt("numEnemies", 3);
        initialEnemies = enemies;
        int maxEnemyLevel = GameState.instance.PlayerLevel;
        for (int i = 0; i < enemies; i++)
        {
            SpawnSystem.Rotate(new Vector3(0, 360 / (enemies+1), 0));
            Instantiate(Enemies[Random.Range(0,maxEnemyLevel)], SpawnPoint.position, SpawnPoint.rotation);
        }

        GameState.instance.GamesThisSession += 1;
        //PlayerPrefs.SetInt("GamesThisSession", PlayerPrefs.GetInt("GamesThisSession", 0) + 1);

        Analytics.CustomEvent("StartBattle", new Dictionary<string, object>
			                      {
				{ "NumEnemies", enemies+"n" },
                {"PlayerLevel", GameState.instance.PlayerLevel+"L"},
                {"TimesPlayedThisSession",GameState.instance.GamesThisSession}
			});
    }


    public void SomeoneDied(Transform character, bool thePlayerDied = false)
    {
        charactersAlive--;
        if (characterDies != null)
        {
            characterDies(character);
        }

        if (thePlayerDied)
        {
            playerIsAlive = false;
            GameState.instance.LastGameWon = 0;
            //PlayerPrefs.SetInt("LastGameWon", 0);
            EndGame();
        }else if (charactersAlive == 1)
        {
            GameState.instance.XPEarnedLastGame = 5 * initialEnemies;
            //PlayerPrefs.SetFloat("newXP", 5*initialEnemies);
            GameState.instance.LastGameWon = 1;
            //PlayerPrefs.SetInt("LastGameWon", 1);
            EndGame();
        }
    }


    public void EndGame()
    {
        //Everyplay.TakeThumbnail();
       // Everyplay.StopRecording();
        Analytics.CustomEvent("GameFinished", new Dictionary<string, object>
			                      {
				{ "Won", playerIsAlive },
				{ "NumEnemies", PlayerPrefs.GetInt("numEnemies", 3)+"n" },
                {"PlayerLevel", PlayerPrefs.GetInt("PlayerLevel", 1)+"L"},
                {"TimesPlayedThisSession",PlayerPrefs.GetInt("GamesThisSession", 1)}
			});
        Application.LoadLevel("GameFinished");
    }
}
