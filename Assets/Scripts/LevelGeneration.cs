using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelGeneration : MonoBehaviour {

    public GameObject[] islands;
    public GameObject[] ducks;
    public GameObject[] items;

    public int bathtubWidth = 50;
    public int bathtubLength = 100;

    private float spawnWithinWidth = 0;
    private float spawnWithinLength = 0;

    public float spawnDistance = 13;
    public float spawnAmountIsland = 9;

	// Use this for initialization
	void Start ()
    {
        spawnWithinWidth = (bathtubWidth / 1.3f) / 2;
        spawnWithinLength = (bathtubLength / 1.2f) / 2;
        SpawnIslands();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    
    //for me to test some sizes
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(spawnWithinLength * 2,1,spawnWithinWidth * 2));
    }

    void SpawnIslands()
    {
        List<GameObject> spawnedIslandList = new List<GameObject>();

        for (int i = 0; i < spawnAmountIsland; i++)
        {
            if (spawnedIslandList == null)
            {
                GameObject spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], new Vector3(Random.Range(-spawnWithinLength, spawnWithinLength), 1, Random.Range(-spawnWithinWidth, spawnWithinWidth)), Quaternion.identity) as GameObject;
                spawnedIslandList.Add(spawnedIsland);
            }
            else
            {
                GameObject spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], new Vector3(Random.Range(-spawnWithinLength, spawnWithinLength), 1, Random.Range(-spawnWithinWidth, spawnWithinWidth)), Quaternion.identity) as GameObject;
                spawnedIslandList.Add(spawnedIsland);
                for (int j = 0; j < spawnedIslandList.Count; j++)
                {
                    if (Vector3.Distance(spawnedIsland.transform.position, spawnedIslandList[j].transform.position) < spawnDistance && spawnedIsland.transform.position != spawnedIslandList[j].transform.position)
                    { 
                        spawnedIslandList.RemoveAt(j);
                        Destroy(spawnedIsland);
                        i--;
                        Debug.Log("deleted 1");
                    }
                }
            }
        }
    }
}
