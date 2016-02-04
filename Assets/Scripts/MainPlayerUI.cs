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
        for (int i = 0; i < 15; i++)
        {
            HealthUp();
        }
    }
    void Update()
    {
        DecreaseBoost();

        if (health.Count < 1)
        {
            Application.LoadLevel(0);
        }
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

    public void DecreaseBoost()
    {
        bool isBoosting = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (boosterSlider.value > 0)
            {
                isBoosting = true;
                boosterSlider.value--;
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isBoosting = false;
            if (isBoosting == false)
            {
                StartCoroutine(RegenBoost());
            }
        }
    }

    private IEnumerator RegenBoost()
    {
        while(boosterSlider.value < boosterSlider.maxValue)
        {
            boosterSlider.value++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SetSliderMax(float newMax)
    {
        float differenceMax = newMax - boosterSlider.maxValue;
        RectTransform rt = boosterSlider.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y + differenceMax);
        boosterSlider.maxValue = newMax;
        
        StartCoroutine(RegenBoost());
    }
}
