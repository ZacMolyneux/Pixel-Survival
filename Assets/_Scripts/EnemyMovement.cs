using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2d))]
public class EnemyMovement : MonoBehaviour {

    public GameObject player;
    public float ignorethis;
    public float moveSpeed = 4.5f;

    Vector3 target;

    float gravity = -20;
    //float jumpVelocity;
    public Vector3 velocity;

    float velocityXSmoothing;
    float velocityYSmoothing;

    Controller2d controller;

    public bool pickup = false;

    void Start()
    {
        controller = GetComponent<Controller2d>();
        ignorethis = moveSpeed;

        //gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        target = player.transform.position;
        float targetVelocityX = 0;
        float targetVelocityY = 0;

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
        if(target.x > transform.position.x)
        {
            targetVelocityX = moveSpeed;
        }
        else if (target.x < transform.position.x)
        {
            targetVelocityX = -moveSpeed;
        }

        

       if(pickup)
        {
            if (target.y > transform.position.y)
            {
                targetVelocityY = moveSpeed;
            }
            else
            {
                targetVelocityY = -moveSpeed;
            }
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, .3f);
            velocity.y = Mathf.SmoothDamp(velocity.y, targetVelocityY, ref velocityYSmoothing, .3f);
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, .3f);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        
    }
}
