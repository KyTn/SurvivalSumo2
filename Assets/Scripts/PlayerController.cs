using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public Character target;

    Vector3 direction = new Vector3();

    public AudioSource[] hitSounds;

	// Use this for initialization
	void Start () {

        FightManager.instance.charactersAlive++;
	}
	
	// Update is called once per frame
	void Update () {
        direction = Vector3.zero;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    direction+=Vector3.forward;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    direction+=-Vector3.forward;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    direction+=Vector3.left;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    direction+=-Vector3.left;
        //}

        direction.z = Input.GetAxis("Vertical");
        direction.x = Input.GetAxis("Horizontal");

        direction.z += CrossPlatformInputManager.GetAxis("Vertical");
        direction.x += CrossPlatformInputManager.GetAxis("Horizontal");

        target.direction = direction;
        target.speed = direction.magnitude;

        if (Input.GetButton("Push") || CrossPlatformInputManager.GetButton("Push"))
        {
            target.Push();
        }
	}

    public void OnCollisionEnter(Collision c)
    {
        hitSounds[Random.Range(0, hitSounds.Length)].Play();
    }

}
