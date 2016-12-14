using UnityEngine;
using System.Collections;

public class SpriteController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckMousePos();
	}

    void CheckMousePos()
    {
        if (Input.mousePosition.x < Screen.width / 2)//mouse is on left side
        {
            Debug.Log("LEFT");
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            Debug.Log("Right");
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
