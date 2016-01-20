using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelGeneration : MonoBehaviour {

    public GameObject[] islands;
    public GameObject[] ducks;
    public GameObject[] items;
    public GameObject[] pathMethods;

    public int bathtubWidth = 50;
    public int bathtubLength = 100;

    private float spawnWidth = 0;
    private float spawnLength = 0;

	// Use this for initialization
	void Start ()
    {
        spawnWidth = (bathtubWidth / 1.1f) /2;
        spawnLength = (bathtubLength / 1.1f) /2;
        SpawnIslands();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    
    //for me to test some sizes
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(spawnLength,1,spawnWidth));
    }*/

    void SpawnIslands()
    {
        List<GameObject> spawnedIslandList = new List<GameObject>();

        for (int i = 0; i < 9; i++)
        {
            if (spawnedIslandList == null)
            {
                GameObject spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], new Vector3(Random.Range(-spawnLength, spawnLength), 1, Random.Range(-spawnWidth, spawnWidth)), Quaternion.identity) as GameObject;
                spawnedIslandList.Add(spawnedIsland);
            }
            else
            {
                GameObject spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], new Vector3(Random.Range(-spawnLength, spawnLength), 1, Random.Range(-spawnWidth, spawnWidth)), Quaternion.identity) as GameObject;
                spawnedIslandList.Add(spawnedIsland);
                for (int j = 0; j < spawnedIslandList.Count; j++)
                {
                    if (Vector3.Distance(spawnedIsland.transform.position, spawnedIslandList[j].transform.position) < 10 && spawnedIsland.transform.position != spawnedIslandList[j].transform.position)
                    { 
                        spawnedIslandList.RemoveAt(j);
                        Destroy(spawnedIsland);
                        Debug.Log("deleted 1");
                    }
                }
            }
        }
    }
}
