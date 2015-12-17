using UnityEngine;
using System.Collections;

public class EnemyMovement : Pathfinding {

    public GameObject[] waypointholder;
    
    private CharacterController controller;

    private bool isMoving = false;

    // Use this for initialization
    void Start ()
    {
        controller = gameObject.GetComponent<CharacterController>();
        FindPath(transform.position, waypointholder[1].transform.position);
    }
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(MovementLoop());

        if (Path.Count > 0)
        {
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
        /*foreach (Transform child in waypointholder.transform)
        {
            FindPath(transform.position, waypointNode.position);
            //waypointIDs.Add(waypointNode.ID);
        }*/
        if (isMoving == false)
        {
            isMoving = true;
            for (int i = 0; i < waypointholder.Length; i++)
            {
                FindPath(transform.position, waypointholder[i].transform.position);
                yield return new WaitForSeconds(0.7f);
                if (i == waypointholder.Length - 1)
                {
                    isMoving = false;
                }
            }
        }
    }
}
