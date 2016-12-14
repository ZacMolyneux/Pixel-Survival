using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject Player;

    public float offset = 4;

    void Update()
    {
        //transform.position
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + offset, -20);
    }

}