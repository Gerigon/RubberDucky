using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class MainPlayerUI : MonoBehaviour {

    public GameObject HealthPanel;

    public GameObject heart;
    private Animator animator;

    public Slider boosterSlider;

    private List<GameObject> health = new List<GameObject>();
    private GameObject newHeart;

    // Use this for initialization
    void Start()
    {
        HealthUp();
        HealthUp();
        HealthUp();
    }

    // Decreases the health of a player
    public IEnumerator HealthDown()
    {
        animator = health[health.Count - 1].GetComponent<Animator>();
        animator.SetTrigger("HealthDown");
        yield return new WaitForSeconds(1.2f);
        Destroy(health[health.Count - 1]);
        health.RemoveAt(health.Count - 1);
    }
    
    // Gives the player another heart
    public void HealthUp()
    {
        int currentHealth = (health.Count - 1);
        newHeart = Instantiate(heart, Vector3.one, Quaternion.identity) as GameObject;
        newHeart.transform.SetParent(HealthPanel.transform, false);
        health.Add(newHeart);
    }
}
