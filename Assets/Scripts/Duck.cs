using UnityEngine;
using System.Collections;

public class Duck : Actor {

    
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        ReceiveHit();
    }

    public void ReceiveHit()
    {
        rb.AddTorque(transform.up * 10);
    }

}
