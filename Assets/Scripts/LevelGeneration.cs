using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelGeneration : MonoBehaviour {

    public GameObject[] Walls;

    public GameObject[] islands;
    public GameObject[] ducks;
    public GameObject[] items;

    public float bathtubWidth = 100;
    public float bathtubLength = 50;

    public float spawnDistance = 13;
    public float spawnAmountIsland = 9;

    public bool drawGizmos;
    public List<GameObject> spawnedIslandList;

    // Use this for initialization
    void Start ()
    {
        List<GameObject> spawnedIslandList = new List<GameObject>();
        SpawnIslands();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(spawnedIslandList.Count);
            for (int i = 0; i < spawnedIslandList.Count; i++)
            {
                Destroy(spawnedIslandList[i].gameObject);
                spawnedIslandList.Remove(spawnedIslandList[i].gameObject);
                Debug.Log("removed Item");
            }
            SpawnIslands();
        }
	}
    
    //for me to test some sizes
    void OnDrawGizmos()
    {
        if (Application.isPlaying && drawGizmos)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, new Vector3(bathtubWidth, 1, bathtubLength));
        }
    }

    void SpawnIslands()
    {
        
        while (spawnedIslandList.Count < spawnAmountIsland)
        {
            GameObject spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], new Vector3(transform.position.x + Random.Range(-bathtubWidth / 3, bathtubWidth / 3), 4f, transform.position.z + Random.Range(-bathtubLength / 3, bathtubLength / 3)), Quaternion.identity) as GameObject;
            spawnedIslandList.Add(spawnedIsland);
            for (int i = 0; i < spawnedIslandList.Count; i++)
            {
                if (Vector3.Distance(spawnedIsland.transform.position, spawnedIslandList[i].transform.position) < spawnDistance && spawnedIslandList[i].transform.position != spawnedIsland.transform.position)
                {
                    spawnedIslandList.RemoveAt(i);
                    Destroy(spawnedIsland);
                    i--;
                    Debug.Log("deleted 1");
                }
            }
        }
        //for (int i = 0; i < spawnAmountIsland; i++)
        //{
        //    GameObject spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], new Vector3(transform.position.x + Random.Range(-bathtubWidth/3, bathtubWidth/3), 4f, transform.position.z + Random.Range(-bathtubLength/3, bathtubLength/3)), Quaternion.identity) as GameObject;
        //    spawnedIslandList.Add(spawnedIsland);
        //    for (int j = 0; j < spawnedIslandList.Count; j++)
        //    {
        //        if (Vector3.Distance(spawnedIsland.transform.position, spawnedIslandList[j].transform.position) < spawnDistance && spawnedIslandList[j].transform.position != spawnedIsland.transform.position)
        //        {
        //            spawnedIslandList.RemoveAt(j);
        //            Destroy(spawnedIsland);
        //            i--;
        //            Debug.Log("deleted 1");
        //        }
        //    }
        //}
    }
}
