using UnityEngine;
using System.Collections;

public class EnemyAI : Pathfinding {

    public Duck _owner;

    public GameObject waypointContainer = null;
    public GameObject[] waypointHolder = null;
    
    private CharacterController controller = null;

    private Collider unitCollider = null;

    private bool movingToPlayer = false;

    private int currentWaypoint = 0;

    private GameObject player = null;

    private int lastWaypoint;

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
        waypointContainer = GameObject.Find("island");
        SetWaypoints();
        FindPath(transform.position, waypointHolder[0].transform.position);

        unitCollider.enabled = true;

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
            _owner.myMovementController.Movement(direction);
            if (Vector3.Distance(transform.position - Vector3.up, Path[0]) < 2F && PathType == PathfinderType.WaypointBased)
            {
                Path.RemoveAt(0);
                NextWaypoint();
            }
            else if(Vector3.Distance(transform.position - Vector3.up, Path[0]) < 2F && PathType == PathfinderType.GridBased)
            {
                Path.RemoveAt(0);
            }
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

    //moves to player
    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Player")
        {
            PathType = PathfinderType.GridBased;
            FindPath(transform.position, player.transform.position);

        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            PathType = PathfinderType.WaypointBased;
            NextWaypoint();
        }
    }

}
