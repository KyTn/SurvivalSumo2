using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    public void PlayPressed()
    {
        SceneManager.LoadScene("Game");
    }
}
