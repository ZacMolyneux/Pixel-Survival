using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public float MAX_HP = 5;
    public float currentHP;

    public GameObject Pixel;
    public EnemyRangedAttack rangedAttack;

    public GameObject player;
    Rigidbody2D rb;

    SlimeMovement slimeMove;
    EnemyMovement enemyMove;

	void Start ()
    {
        currentHP = MAX_HP;
        rangedAttack = GetComponent<EnemyRangedAttack>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        slimeMove = GetComponent<SlimeMovement>();
        enemyMove = GetComponent<EnemyMovement>();
	}
	

	void Update ()
    {
	    if(currentHP <= 0)
        {
            //destroy this and drop resources 
            for(int i = 0; i < MAX_HP; i++)
            {
                Pixel = Instantiate(Pixel, (new Vector3(this.transform.position.x + Random.insideUnitCircle.x, transform.position.y + 1 + Random.insideUnitCircle.x, -10)), Quaternion.identity) as GameObject;
            }
            Destroy(this.gameObject);
        }
	}

    public void TakeDMG(float DMG)
    {
        //rb.AddForce((player.transform.position - transform.position) * 10000);
        //Debug.Log((player.transform.position - transform.position) * 10000);
        if(slimeMove!= null)
        {
            slimeMove.KnockBack();
        }
        else if(enemyMove != null)
        {
            enemyMove.KnockBack();
        }
        currentHP -= DMG;
    }

    public void FEED(float feed)
    {
        if(feed > 0)
        {
            MAX_HP += (feed * 5);
            currentHP = MAX_HP;

            if(rangedAttack != null)
            {
                rangedAttack.MaxRange += (0.2f * feed);
            }

            transform.localScale += new Vector3((0.2f * feed), (0.2f * feed), 0);//this will be need to fixed when the enemies arnt at base 1 scale
        }
    }
}
