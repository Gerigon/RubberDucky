using UnityEngine;
using System.Collections;

public class Duck : Actor {

    private EnemyAI myAIController;

    // Use this for initialization
    protected override void Start()
    {
        myAIController = gameObject.AddComponent<EnemyAI>() as EnemyAI;
        myAIController._owner = this;
        Debug.Log(myAIController);
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
    }

}
