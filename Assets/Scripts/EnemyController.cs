using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{


    public Character target;
    Transform targetTransform;

    Vector3 direction = new Vector3();

    public static List<Transform> fighters = new List<Transform>();
    List<Transform> oponents = new List<Transform>();

    public bool usePush = false;

    // Use this for initialization
    void Start()
    {
        targetTransform = target.transform;

        FightManager.instance.charactersAlive++;
        if (fighters.Count == 0)
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            foreach (GameObject g in balls)
            {
                fighters.Add(g.GetComponent<Transform>());
            }
        }
        oponents.AddRange(fighters);
        oponents.Remove(this.transform);

    }
    void OnEnable()
    {
        FightManager.instance.characterDies += SomeoneDied;
    }


    void OnDisable()
    {
        FightManager.instance.characterDies -= SomeoneDied;
    }

    void SomeoneDied(Transform t)
    {
        oponents.Remove(t);
    }
    public float distanceToBorder;
    // Update is called once per frame
    void Update()
    {
        if (oponents.Count == 0) { target.direction = Vector3.zero; target.speed = 0; return; }


        Transform closestEnemy = oponents.OrderBy(t => Vector3.Distance(t.position, this.transform.position)).First();
        /*float*/ distanceToBorder = 5 - Vector3.Distance(this.targetTransform.position, Vector3.zero);
        if (distanceToBorder < 0.5f)
        {
            direction = -targetTransform.position;
            if (usePush)
            {
                target.Push();
            }
        }
        else if (Vector3.Distance(closestEnemy.position, Vector3.zero) > Vector3.Distance(this.targetTransform.position, Vector3.zero))
        {

            direction = ((closestEnemy.position - transform.position).normalized * Random.Range(0.9f, 1.1f));
            if (usePush)
            {
                target.Push();
            }
        }
        else
        {
            direction.x = targetTransform.position.z;
            direction.z = -targetTransform.position.x;

            direction = Vector3.RotateTowards(direction, -targetTransform.position, .75f, 0);
        }

        target.direction = direction;
        target.speed = 1;
        
    }


}
