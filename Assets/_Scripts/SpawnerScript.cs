using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
    //enemy types
    public GameObject Slime;
    public int slimeCost;

    public GameObject Elemental;
    public int elementalCost;

    public GameObject Bull;
    public int bullCost;

    public int MAX_POOL = 5;
    public int wavePool;
    public int randSplit;

    GameObject spawn;

    public int maxWaveSpawn = 2;
    //public int currentSpawned;

    public float MAX_SPAWN_DELAY = 1;
    public float currentSpawnDelay = 0;

    GameObject checkEnemy;


	void Start ()
    {
        wavePool = MAX_POOL;
	}
	

	void Update ()
    {
	    if(currentSpawnDelay >= 0)
        {
            currentSpawnDelay -= Time.deltaTime;
        }

        if(currentSpawnDelay <= 0 && wavePool > 0)//currentSpawned < maxWaveSpawn)
        {
            randSplit = Random.Range(1, wavePool);
            wavePool -= randSplit;

            //Debug.Log(randSplit);

            SpawnSelection(randSplit);
            //currentSpawned++;
            currentSpawnDelay = MAX_SPAWN_DELAY;
        }

        if(wavePool <= 0)
        {
            checkEnemy = GameObject.FindGameObjectWithTag("Enemy");
            if(checkEnemy == null)
            {
                MAX_POOL += 5;
                wavePool = MAX_POOL;
            }
        }
	}

    void SpawnSelection(int randSplit)
    {
        int choice = 0;
        if(randSplit >= bullCost)//choose any
        {
            //Debug.Log("bull");
            choice = Random.Range(1, 4);
        }
        else if(randSplit >= elementalCost)
        {
            choice = Random.Range(1, 2);
        }
        else//choose and feed slime
        {
            choice = 1;
        }
        SpawnEnemy(choice, randSplit);
    }

    void SpawnEnemy(int choice, int randSplit)
    {
        switch (choice)
        {
            case 0:
                Debug.Log("failed to select enemy");
                break;
            case 1://spawn slime
                spawn = Instantiate(Slime, this.transform.position, Quaternion.identity) as GameObject;
                spawn.transform.position += new Vector3(0,0,-3);
                spawn.GetComponent<EnemyManager>().FEED(randSplit - slimeCost);
                break;
            case 2://spawn elemental
                spawn = Instantiate(Elemental, this.transform.position, Quaternion.identity) as GameObject;
                spawn.transform.position += new Vector3(0, 0, -2);
                spawn.GetComponent<EnemyManager>().FEED(randSplit - elementalCost);
                break;
            case 3://spawn bull
                spawn = Instantiate(Bull, this.transform.position, Quaternion.identity) as GameObject;
                spawn.transform.position += new Vector3(0, 0, -1);
                spawn.GetComponent<EnemyManager>().FEED(randSplit - bullCost);
                break;
        }

    }

}
