using UnityEngine;
using System.Collections;

public class EnemyRangedAttack : MonoBehaviour
{
    public EnemyMovement movement;

    public GameObject target;

    public float MaxRange = 8f;

	void Start ()
    {
	    
	}
	

	void Update ()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        Debug.Log(Vector3.Distance(target.transform.position, transform.position));

        //stop moving closer to target
        if (Vector3.Distance( target.transform.position, transform.position) <= MaxRange)
        {
            //movement.enabled = false;
            //movement.velocity = Vector3.zero;
            movement.moveSpeed = 0;
        }
        else
        {
            movement.moveSpeed = movement.ignorethis;
            //movement.enabled = true;
        }
	}
}
