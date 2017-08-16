using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItemsOnPlayer : MonoBehaviour {

    public MeshRenderer[] skins_meshes;
    public SkinnedMeshRenderer[] skins_skinnedMeshes;

    public int index = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < skins_meshes.Length; i++)
        {
            skins_meshes[i].enabled = (i == index) ? true : false;
        }

        for (int i = 0; i < skins_skinnedMeshes.Length; i++)
        {
            skins_skinnedMeshes[i].enabled = (i == (index - skins_meshes.Length)) ? true : false;
        }
	}
}
