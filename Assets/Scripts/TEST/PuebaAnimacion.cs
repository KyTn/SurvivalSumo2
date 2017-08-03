using UnityEngine;
using System.Collections;

public class PuebaAnimacion : MonoBehaviour
{

    public Animator[] animators;

    public int Piernas;
    public int Brazos;

    public void Update()
    {
        foreach (Animator a in animators)
        {
            a.SetInteger("Piernas", Piernas);
            a.SetInteger("Brazos", Brazos);
        }

    }


}
