using UnityEngine;
using System.Collections;

public class Duck : Actor {

    private EnemyAI myAIController;

    // Use this for initialization
    protected override void Start()
    {
        health = 10;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void setIsland(GameObject Island)
    {
        
        myAIController = gameObject.AddComponent<EnemyAI>() as EnemyAI;
        myAIController._owner = this;
        myAIController.waypointContainer = Island;
        myAIController.InstantiatePath();

    }

    protected override void FixedUpdate()
    {
    }

}
