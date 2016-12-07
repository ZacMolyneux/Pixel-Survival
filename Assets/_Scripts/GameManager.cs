using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Currency;

    public GameObject Player;

    public Text pixelsText;

    //ref to scripts
    public PickUp pickUP;

	void Start ()
    {
        //pickUP = Player.get<PickUp>();
	}
	

	void Update ()
    {
        pixelsText.text = "Pixels: " + Currency;
	}
}
