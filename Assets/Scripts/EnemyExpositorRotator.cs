using UnityEngine;
using System.Collections;

public class EnemyExpositorRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 45 * Time.deltaTime, 0);
	}
}
