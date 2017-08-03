using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NumEnemiesController : MonoBehaviour {

    public List<Image> botones = new List<Image>();

    //// Use this for initialization
    //void Start () {
	
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}

    public void ResaltarBoton(Image boton)
    {
        botones.ForEach(b => b.color = Color.white);

        boton.color = Color.green;
    }

    public void ElegirNumEnemigos(int num)
    {

        PlayerPrefs.SetInt("numEnemies", num);
    }
}
