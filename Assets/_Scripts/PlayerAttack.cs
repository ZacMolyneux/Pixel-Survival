using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    //need a ref to the collider, for on Enter?
    public Collider2D attackTrigger;
    public float damage = 1;

    public int MAX_XP = 6;
    public int currentXP;

    //attacking delay timer
    public float MAX_DELAY;
    public float currentDelay;
    public float ATTACK_DURATION;

    public Material playerMat;

    public GameManager GM;

    public bool feeding = false;

	void Start ()
    {
        currentDelay = 0;
	}
	


	void Update ()
    {
        checkLevelWeapon();

        if(feeding && GM.Currency > 0)
        {
            FeedWeapon();
        }

        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && currentDelay <= 0)
        {
            playerMat.color = Color.cyan;
            currentDelay = MAX_DELAY;
            attackTrigger.enabled = true;
        }
        else if (currentDelay > (MAX_DELAY - ATTACK_DURATION) && currentDelay != MAX_DELAY)
        {
            attackTrigger.enabled = true;
        }
        else
        {
            playerMat.color = Color.blue;
            attackTrigger.enabled = false;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyManager>().TakeDMG(damage);
        }
    }

    public void FEED_TRUE()
    {
        feeding = true;
    }

    public void FEED_FALSE()
    {
        feeding = false;
    }

    void FeedWeapon()
    {
        GM.Currency--;
        currentXP++;
    }

    void checkLevelWeapon()
    {
        if(currentXP >= MAX_XP)
        {
            damage++;
            currentXP = 0;
            MAX_XP *= 2;
        }
    }
}
