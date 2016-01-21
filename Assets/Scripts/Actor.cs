using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    public MovementController myMovementController;

    bool inWater = false;
    LayerMask waterLayer = 4;
    public Rigidbody rb;
    public int health;

    public GameManager gameManager;

    // Use this for initialization
    protected virtual void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        myMovementController = new MovementController(this);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        myMovementController.Update();
        if (health < 0)
        {
            StartCoroutine(DeathAnimation());
        }
        /*transform.position = new Vector3(Mathf.Clamp(transform.position.x, gameManager.Walls[3].transform.position.x + 1.5f, gameManager.Walls[1].transform.position.x - 1.5f),
                                                                 transform.position.y,
                                                     Mathf.Clamp(transform.position.z, gameManager.Walls[2].transform.position.z + 1.5f, gameManager.Walls[0].transform.position.z - 1.5f));
        */
    }

    protected virtual void FixedUpdate()
    {
        if (inWater == true)
        {
            //Vector3 force = transform.up * buoyancy;
            //rb.AddForce(force, ForceMode.Acceleration);
        }
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == waterLayer && inWater == false)
        {
            rb.drag = 0.5f;
            inWater = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == waterLayer && inWater == true)
        {
            rb.drag = 0.003f;
            inWater = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("CannonBal"))
        {
            ReceiveDamage(5);
        }
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        StartCoroutine(DamageFlash());
    }

    IEnumerator DamageFlash(int NumbFlashes = 6)
    {
        Debug.Log("flashing");
        for (int i = 0; i < NumbFlashes; i++)
        {
            yield return new WaitForSeconds(.1f);
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
        }
    }

    IEnumerator DeathAnimation()
    {
        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(Vector3.up, 4);
            transform.Translate(Vector3.down / 70);
            GetComponent<EnemyAI>().enabled = false;
            yield return new WaitForEndOfFrame();
        }
        Destroy(this.gameObject);
    }
}
