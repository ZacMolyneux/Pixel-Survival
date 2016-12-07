using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public bool PICKUP = false;

    public GameManager GM;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(PICKUP && other.tag == "Pixel")
        {
            Destroy(other.gameObject);
            GM.Currency++;
            //increase resources
        }
        if(other.tag == "Pixel")
        {
            other.GetComponent<EnemyMovement>().enabled = true;
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
