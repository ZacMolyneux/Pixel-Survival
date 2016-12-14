using UnityEngine;
using System.Collections;

public class SlimeMovement : MonoBehaviour
{
    public GameObject player;
    Vector3 target;
    
    //float jumpVelocity;
    public Vector3 velocity;
    
    Controller2d controller;

    public float MAX_JUMP_DELAY;
    public float MIN_JUMP_DELAY;
    public float currentJumpDelay;

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;

    public float moveSpeed;

    float accelerationTimeAirbourne = .2f;
    float accelerationTimeGrounded = .2f;

    float gravity;
    float jumpVelocity;

    float targetVelocityX;
    float velocityXSmoothing;

    public GameObject Sprite;
    public Animator anim;

    void Start()
    {
        controller = GetComponent<Controller2d>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        target = player.transform.position;

        if (controller.collisions.below)
        {
            velocity.y = 0;
            velocity.x = 0;
            moveSpeed = 0;
            targetVelocityX = 0;
            velocityXSmoothing = 0;
            currentJumpDelay -= Time.deltaTime;
            //anim.speed = 1.5f;
            //anim.SetTrigger("LANDED");
            anim.SetBool("LANDED", true);
        }
        else
        {
            //anim.speed = 0.2f;
            anim.SetBool("LANDED", false);
        }

        //currentJumpDelay -= Time.deltaTime;

        if(currentJumpDelay <= 0)
        {
            moveSpeed = 250;
            if (target.x > transform.position.x)
            {
                //target is on right
                velocity.y = jumpVelocity;
                targetVelocityX = 1 * moveSpeed;
                Sprite.transform.localRotation = new Quaternion(0, 180, 0, 0);
            }
            else if (target.x < transform.position.x)
            {
                //target is on left
                velocity.y = jumpVelocity;
                targetVelocityX = -1 * moveSpeed;
                Sprite.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
            float jumpDelay = Random.Range(MIN_JUMP_DELAY, MAX_JUMP_DELAY);
            currentJumpDelay = jumpDelay;
            //Debug.Log(jumpDelay);
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirbourne);
            
        }

        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }

    public void KnockBack()
    {
        //rb.AddForce((player.transform.position - transform.position) * 10000);
        velocity = new Vector3((transform.position.x - player.transform.position.x) * 10, Mathf.Abs(transform.position.y - player.transform.position.y) * 15, 0) / transform.localScale.x;
        controller.Move(velocity * Time.deltaTime);
    }
}
