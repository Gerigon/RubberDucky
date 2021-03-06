﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelGeneration : MonoBehaviour {

    public List<GameObject> RandomItmes;

    public GameObject[] Walls;
    public GameObject[] islands;
    public GameObject[] ducks;
    public GameObject[] items;
    public GameObject[] TreasureBuoy;

    public GameObject water;

    public GameObject Player;

    public PopUpUI popUpUI;

    public float bathtubWidth = 100;
    public float bathtubLength = 50;

    public float spawnDistance = 13;
    public float spawnAmountIsland = 9;

    public bool drawGizmos;
    public List<GameObject> spawnedIslandList;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        List<GameObject> spawnedIslandList = new List<GameObject>();
        SpawnIslands();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIslands();
    }

    void CheckIslands()
    {
        for (int i = 0; i < spawnedIslandList.Count; i++)
        {
            if (Vector3.Distance(spawnedIslandList[i].transform.position, Player.transform.position) < 10)
            {
                if (spawnedIslandList[i].GetComponent<IslandScript>().Ducks.Count == 0 && spawnedIslandList[i].GetComponent<IslandScript>().storedItem != null)
                {
                    //if (spawnedIslandList[i].GetComponent<IslandScript>().playerClose == false)
                    //{
                    spawnedIslandList[i].GetComponent<IslandScript>().playerClose = true;
                    popUpUI.LoadImageBoatPart(spawnedIslandList[i].GetComponent<IslandScript>().storedItem.name);
                    popUpUI.EnableCanvas();
                    //spawnedIslandList[i].GetComponent<IslandScript>().playerClose = true;
                    if (Input.GetKeyDown(KeyCode.Y))
                    {
                        SpawnItems(spawnedIslandList[i].GetComponent<IslandScript>().storedItem.name);
                        spawnedIslandList[i].GetComponent<IslandScript>().storedItem = null;
                        popUpUI.DisableCanvas();
                    }
                    else if (Input.GetKeyDown(KeyCode.N))
                    {
                        popUpUI.DisableCanvas();
                    }
                    //}
                }
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                popUpUI.DisableCanvas();
            }
        }
    }
    //}
    //else
    //{
    //    spawnedIslandList[i].GetComponent<IslandScript>().playerClose = false;
    //}

    private void SpawnItems(string itemName)
    {
        Debug.Log(itemName);
        switch (itemName)
        {
            case "Bathbomb Cannon":
                Player.GetComponent<BoatParts>().SwitchEquipment(Weapons.BathbombCannon);
                break;
            case "Fishing Net":
                Player.GetComponent<BoatParts>().SwitchEquipment(Weapons.FishingNet);
                break;
            case "Figure Head":
                Player.GetComponent<BoatParts>().SwitchEquipment(Weapons.FigureHead);
                break;
            case "Harpoon Cannon":
                Player.GetComponent<BoatParts>().SwitchEquipment(Weapons.HarpoonCannon);
                break;
            case "Icebreaker":
                Player.GetComponent<BoatParts>().SwitchEquipment(Weapons.Icebreaker);
                break;
            case "Water Pistol":
                Player.GetComponent<BoatParts>().SwitchEquipment(Weapons.WaterPistol);
                break;
            case "Fast Hull":
                Player.GetComponent<BoatParts>().SwitchEquipment(Hull.FastHull);
                break;
            case "Sturdy Hull":
                Player.GetComponent<BoatParts>().SwitchEquipment(Hull.SturdyHull);
                break;
            case "Super Hull":
                Player.GetComponent<BoatParts>().SwitchEquipment(Hull.SuperHull);
                break;
            case "Mist Cabin":
                Player.GetComponent<BoatParts>().SwitchEquipment(Cabin.MistCabin);
                break;
            case "Nitro Cabin":
                Player.GetComponent<BoatParts>().SwitchEquipment(Cabin.NitroCabin);
                break;
            case "Super Cabin":
                Player.GetComponent<BoatParts>().SwitchEquipment(Cabin.SuperCabin);
                break;
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
        GameObject spawnedIsland = null;
        for (int i = 0; i < spawnAmountIsland; i++)
        {
            spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], FindIslandLoc(spawnDistance), Quaternion.identity) as GameObject;
            spawnedIslandList.Insert(0, (spawnedIsland));
            
            SpawnDucks(spawnedIsland);

            int randomNum = Random.Range(0, RandomItmes.Count - 1);
            spawnedIsland.GetComponent<IslandScript>().storedItem = RandomItmes[randomNum];
            RandomItmes.RemoveAt(randomNum);
        }
        for (int i = 0; i < 8; i++)
        {
            GameObject Chest = Instantiate(TreasureBuoy[Random.Range(0, islands.Length - 1)], FindIslandLoc(10) - Vector3.up * 4.25f, Quaternion.identity) as GameObject;
        }
        WaypointPathfinder.Instance.IniateWaypoints();
        water.GetComponent<BoxCollider>().enabled = false;

        
    }

    void SpawnDucks(GameObject island)
    {
        int randomDuckAmount = Random.Range(2, 4);
        for (int i = 0; i < randomDuckAmount; i++)
        {
            GameObject spawnedDuck = Instantiate(ducks[Random.Range(0, ducks.Length - 1)], island.transform.position + Vector3.forward * 3 - Vector3.up * 4 + Vector3.left*2*i, Quaternion.identity) as GameObject;
            spawnedDuck.GetComponent<Duck>().setIsland(island.transform.GetChild(0).gameObject);
            island.GetComponent<IslandScript>().Ducks.Add(spawnedDuck);
            
        }


    }

    Vector3 FindIslandLoc(float MinimumDistance)
    {
        Collider[] neighbours;
        Vector3 spawnLoc;
        do
        {
            spawnLoc = new Vector3(transform.position.x + Random.Range(-bathtubWidth / 3, bathtubWidth / 3), -2.25f, transform.position.z + Random.Range(-bathtubLength / 3, bathtubLength / 3));
            neighbours = Physics.OverlapSphere(spawnLoc, MinimumDistance, 1 << 10);
        }
        while (neighbours.Length > 0);
        return spawnLoc;

        //GameObject spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], spawnLoc, Quaternion.identity) as GameObject;
        //spawnedIslandList.Insert(0, (spawnedIsland));
        //for (int i = 0; i < spawnedIslandList.Count; i++)
        
        //{
        //    if (Vector3.Distance(spawnLoc, spawnedIslandList[i].transform.position) < spawnDistance )
        //    {
        //        break;
        //    }
        //    else
        //    {
        //        counter++;
        //    }
        //    if (counter == spawnedIslandList.Count)
        //    {
        //        GameObject spawnedIsland = Instantiate(islands[Random.Range(0, islands.Length - 1)], spawnLoc, Quaternion.identity) as GameObject;
        //        spawnedIslandList.Insert(0, (spawnedIsland));

        //    }
        //}
        //counter = 0;
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
