using UnityEngine;
using System.Collections;

public class EnemyMovement : Pathfinding {

    public GameObject waypointContainer = null;
    public GameObject[] waypointHolder = null;
    
    private CharacterController controller = null;

    private Collider unitCollider = null;

    private bool isMoving = false;

    private bool movingToPlayer = false;

    // Use this for initialization
    void Start ()
    {
        unitCollider = gameObject.GetComponent<SphereCollider>();
        controller = gameObject.GetComponent<CharacterController>();
        SetWaypoints();
        FindPath(transform.position, waypointHolder[1].transform.position);
        unitCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Path.Count > 0 && PathType == PathfinderType.WaypointBased && movingToPlayer == false)
        {
            StartCoroutine(MovementLoop());
            MoveMethod();
        }
        if (Path.Count > 0 && PathType == PathfinderType.GridBased)
        {
            MoveMethod();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            Path.Clear();
            StopCoroutine("MovementLoop");
            movingToPlayer = true;
            GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
            PathType = PathfinderType.GridBased;
            FindPath(transform.position, thePlayer.transform.position);
            MoveMethod();
        }
    }
    
    void MoveMethod()
    {
        if (Path.Count > 0)
        {
            Vector3 direction = (Path[0] - transform.position).normalized;

            controller.SimpleMove(direction * 10F);
            if (Vector3.Distance(transform.position - Vector3.up, Path[0]) < 1F)
            {
                Path.RemoveAt(0);
            }
        }
    }

    
    IEnumerator MovementLoop()
    {
        if (isMoving == false)
        {
            isMoving = true;
            for (int i = 0; i < waypointHolder.Length; i++)
            {
                FindPath(transform.position, waypointHolder[i].transform.position);
                yield return new WaitForSeconds(0.7f);
                if (i == waypointHolder.Length - 1)
                {
                    isMoving = false;
                }
            }
        }
    }

    void SetWaypoints()
    {
        waypointHolder = new GameObject[waypointContainer.transform.childCount];
        for(int i = 0; i < waypointContainer.transform.childCount; i++)
        {
            waypointHolder[i] = waypointContainer.transform.GetChild(i).gameObject;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Vector3 thePlayer = new Vector3(collider.transform.position.x, 1, collider.transform.position.z);
            PathType = PathfinderType.GridBased;
            FindPath(transform.position, thePlayer);
        }
    }
}
