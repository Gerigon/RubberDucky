﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : Pathfinding {

    public Duck _owner;

    public GameObject waypointContainer = null;
    public GameObject[] waypointHolder = null;
    
    private CharacterController controller = null;

    private Collider unitCollider = null;

    private bool movingToPlayer = false;

    private int currentWaypoint = 0;

    private GameObject player = null;

    private bool hitOnce = false;

    // Use this for initialization
    public EnemyAI(Duck owner)
    {
        if (owner != null)
        {
            this._owner = owner;
        }
        else
        {
            Debug.LogError("No actor attached");
        }
    }

    void Start ()
    {
        base.Start();
        unitCollider = gameObject.GetComponent<SphereCollider>();
        controller = gameObject.GetComponent<CharacterController>();
        player = GameObject.Find("Boat");
        //waypointContainer = GameObject.Find("island");
        unitCollider.enabled = true;

    }

    public void InstantiatePath()
    {
        SetWaypoints();
        FindPath(transform.position, waypointHolder[0].transform.position);
        currentWaypoint = Random.Range(0, waypointHolder.Length - 1);
    }
    // Update is called once per frame
    void Update()
    {
        MoveMethod();


    }
    
    //moves unit based on pathfindertype
    void MoveMethod()
    {
        if (Path.Count > 0)
        {
            Vector3 direction = (Path[0] - transform.position).normalized;
            
            Quaternion newRotation = Quaternion.LookRotation(Path[0] - transform.position , Vector3.up);
            newRotation.x = newRotation.z = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 6f);
            //controller.SimpleMove(direction * 10F);
            _owner.myMovementController.Movement(direction,true);
            if (Vector3.Distance(transform.position - Vector3.up, Path[0]) < 5F && PathType == PathfinderType.WaypointBased)
            {
                Path.RemoveAt(0);
                NextWaypoint();
            }
            else if(Vector3.Distance(transform.position - Vector3.up, Path[0]) < 5F && PathType == PathfinderType.GridBased)
            {
                Path.RemoveAt(0);
            }
        }
        else
        {
            Path.Add(waypointHolder[Random.Range(0, waypointHolder.Length - 1)].transform.position);
        }
    }

    //sets the next waypoint to walk to
    void NextWaypoint()
    {
        if (Path.Count < 1)
        {
            FindPath(transform.position, waypointHolder[currentWaypoint].transform.position);
            currentWaypoint++;
            if (currentWaypoint == waypointHolder.Length - 1)
            {
                currentWaypoint = 0;
            }
        }
    }

    //sets waypoint route
    void SetWaypoints()
    {
        waypointHolder = new GameObject[waypointContainer.transform.childCount];
        for(int i = 0; i < waypointContainer.transform.childCount; i++)
        {
            waypointHolder[i] = waypointContainer.transform.GetChild(i).gameObject;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _owner.GetComponent<SphereCollider>().radius *= 2;
        }
    }
        //moves to player
    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Player" && hitOnce == false)
        {
            PathType = PathfinderType.GridBased;
            FindPath(transform.position, player.transform.position);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _owner.GetComponent<SphereCollider>().radius /= 2;
            hitOnce = false;
            PathType = PathfinderType.WaypointBased;
            NextWaypoint();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("hit the player");
            hitOnce = true;
            PathType = PathfinderType.WaypointBased;
            NextWaypoint();
        }
    }
}
