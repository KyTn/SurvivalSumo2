using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncAnimPlayer : MonoBehaviour {

    //Animators de todos los objetos de skin
    public Animator[] animators;

    // Vars de estado de los animators
    public int Piernas; 
    public int Brazos;

    public void Start()
    {

    }

    public void Update()
    {
        foreach (Animator a in animators)
        {
            a.SetInteger("Piernas", Piernas);
            a.SetInteger("Brazos", Brazos);
        }

    }

}
