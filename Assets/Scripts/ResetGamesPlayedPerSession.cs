using UnityEngine;
using System.Collections;

public class ResetGamesPlayedPerSession : MonoBehaviour {

	// Use this for initialization
	void Awake () {

        PlayerPrefs.SetInt("GamesThisSession", 0);
	}
}
