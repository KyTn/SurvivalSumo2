using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class Character : MonoBehaviour {

    public Vector3 direction = new Vector3();
    public float speed = 0;
    public float pushForce = 4;

    public float myStrength = 10;

    public bool playerControlled = false;

    Rigidbody rigid;

    public Animator animator;


    public float pushCooldown= 5;

    public DateTime nextPushAvailable = DateTime.MinValue;

    bool doPush = false;

	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody>();

        if (playerControlled)
        {
            PushButton.target = this;
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        direction.y = 0;
        if (speed < 0)
        {
            speed = 0;
        }
        else if (speed > 1)
        {
            speed = 1;
        }
        if (direction == Vector3.zero)
        {
            speed = 0;
        }
        else
        {

            Quaternion rot = transform.rotation;
            Quaternion rot2 = transform.rotation;

            rot.SetLookRotation(direction);

            rot2 = Quaternion.Lerp(rot2, rot, 0.1f);
            transform.rotation = rot2;
        }


        Debug.DrawLine(transform.position, transform.position + direction.normalized, Color.red);
        rigid.AddForce(direction.normalized * speed * myStrength);
        if (doPush)
        {
            animator.SetTrigger("PUSH");
            rigid.AddForce(direction.normalized * pushForce, ForceMode.VelocityChange);
            doPush = false;
        }
    }

    public void Push()
    {
        if (DateTime.Now < nextPushAvailable)
        {
            return;
        }

        nextPushAvailable = DateTime.Now.AddSeconds(pushCooldown);
        doPush = true;

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "death")
        {
            Die();
        }
    }

    public void Die()
    {

        FightManager.instance.SomeoneDied(this.transform, playerControlled);

        Destroy(transform.parent.gameObject, 1);
    }
}
