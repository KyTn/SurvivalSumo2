using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour {

    public int charactersAlive = 0;
    public bool playerIsAlive = true;


    public static LevelController instance;

    public int[] numberEnemiesPerLevel;
    public int[] maxEnemiesLevel;

    public Transform SpawnSystem;

    public GameObject Player;
    public GameObject[] Enemies;

    public delegate void CharacterEvent(Transform t);
    public event CharacterEvent characterDies;

    public int initialEnemies;

    public Transform SpawnPoint;
    // Use this for initialization
    void Start() {
        numberEnemiesPerLevel = new int[14] {1, 2, 2, 3, 2, 3, 4, 5, 4, 5, 5, 3, 3, 4};
        maxEnemiesLevel = new int[14] { 1, 1, 2, 1, 2, 2, 2, 3, 3, 4, 5, 5, 6, 7 };
        loadLevel();
	}

    void Awake()
    {
        instance = this;
        
        EnemyController.fighters.Clear();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadLevel()
    {
        int i = GameManager.instance.level;
        initialEnemies = numberEnemiesPerLevel[i];
        Instantiate(Player, SpawnPoint.position, SpawnPoint.rotation);
        switch (i)
        {
            case 0:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 1:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 2:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 3:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 4:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 5:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 6:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 7:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 8:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 9:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 10:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 11:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 12:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 13:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
            case 14:
                spawnEnemies(initialEnemies, maxEnemiesLevel[i]);
                break;
        }
            
    }

    public void spawnEnemies(int j,int d)
    {
        int enemies= j;
        int maxEnemyLevel=d;
        for (int i = 0; i < enemies; i++)
        {
            SpawnSystem.Rotate(new Vector3(0, 360 / (enemies + 1), 0));
            Instantiate(Enemies[Random.Range(0, maxEnemyLevel)], SpawnPoint.position, SpawnPoint.rotation);
        }
    }

    public void EndGame()
    {
        //Everyplay.TakeThumbnail();
        // Everyplay.StopRecording();
        //Analytics.CustomEvent("GameFinished", new Dictionary<string, object>
        //                          {
        //        { "Won", playerIsAlive },
        //        { "NumEnemies", PlayerPrefs.GetInt("numEnemies", 3)+"n" },
        //        {"PlayerLevel", PlayerPrefs.GetInt("PlayerLevel", 1)+"L"},
        //        {"TimesPlayedThisSession",PlayerPrefs.GetInt("GamesThisSession", 1)}
        //    });
        Application.LoadLevel("GameFinished");

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
        }
        else if (charactersAlive == 1)
        {
            GameState.instance.XPEarnedLastGame = 5 * initialEnemies;
            //PlayerPrefs.SetFloat("newXP", 5*initialEnemies);
            GameState.instance.LastGameWon = 1;
            //PlayerPrefs.SetInt("LastGameWon", 1);
            EndGame();
        }
    }

}
