using UnityEngine;
using System.Collections;

public class Duck : Actor
{

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

    public IEnumerator DeathAnimation()
    {
        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(Vector3.up, 4);
            transform.Translate(Vector3.down / 70);
            GetComponent<EnemyAI>().enabled = false;
            yield return new WaitForEndOfFrame();
        }
        myAIController.waypointContainer.transform.parent.GetComponent<IslandScript>().Ducks.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    protected override void FixedUpdate()
    {
    }

    void OnParticleCollision(GameObject other)
    {
        ReceiveDamage(0.1f);
        Vector3 direction =   (transform.position -other.transform.position).normalized;
        rb.AddForce(direction * 1.5f, ForceMode.VelocityChange);
    }
}
