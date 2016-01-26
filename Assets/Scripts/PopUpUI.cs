using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpUI : MonoBehaviour {
    
    public GameObject popUpPanel;
    public Image thisImage;
    public Image confirmationImage;

    public float waitingTime = 5f;

    public float imageHeight = 2f;

	// Use this for initialization
	void Start ()
    {
        confirmationImage.enabled = false;

        //transform.position = transform.position + Vector3.up * imageHeight;

        DisableCanvas();
    }
	
	// Update is called once per frame
	void Update ()
    {/*
        if(thisCanvas.enabled == true)
        {

            //rotation
            Vector3 v = boatCamera.transform.position - transform.position;
            v.z = 0f;
            transform.LookAt(boatCamera.transform.position - v);
            transform.Rotate(0, 180, 0);
        }*/

        /* a test
	    if(Input.GetKeyDown(KeyCode.A))
        {
            LoadImageTest();
        } */
	}

    /// <summary>
    /// Enables the Canvas GameObeject
    /// </summary>
    public void EnableCanvas()
    {
        popUpPanel.SetActive(true);
    }

    /// <summary>
    /// Disables the Canvas GameObject
    /// </summary>
    public void DisableCanvas()
    {
        popUpPanel.SetActive(true);
    }

    /*
    //test
    public void LoadImageTest()
    {
        thisImage.sprite = Resources.Load<Sprite>("Cabin/Mist Cabin");
        StartCoroutine(SwitchCabin());
    }*/

    /// <summary>
    /// sets the images for the boat parts
    /// </summary>
    /// <param name="thisGameObject"></param>
    public void LoadImageBoatPart(GameObject thisGameObject)
    {
        switch(thisGameObject.name)
        {
            case "Super Hull":
                thisImage.sprite = Resources.Load<Sprite>("Hull/Super Hull");
                SwitchHull();
                break;
            case "Fast Hull":
                thisImage.sprite = Resources.Load<Sprite>("Hull/Speed Hull");
                SwitchHull();
                break;
            case "Standart Hull":
                thisImage.sprite = Resources.Load<Sprite>("Hull/Basic Hull");
                SwitchHull();
                break;
            case "Sturdy Hull":
                thisImage.sprite = Resources.Load<Sprite>("Hull/Sturdy Hull");
                SwitchHull();
                break;

            case "Standard Cabin":
                thisImage.sprite = Resources.Load<Sprite>("Cabin/Basic Cabin");
                SwitchCabin();
                break;
            case "Nitro Cabin":
                thisImage.sprite = Resources.Load<Sprite>("Cabin/Nitro Cabin");
                SwitchCabin();
                break;
            case "Mist Cabin":
                thisImage.sprite = Resources.Load<Sprite>("Cabin/Mist Cabin");
                SwitchCabin();
                break;
            case "Super Cabin":
                thisImage.sprite = Resources.Load<Sprite>("Cabin/Super Cabin");
                SwitchCabin();
                break;

            case "Bathbomb Cannon":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Bathbomb Canon");
                SwitchTool();
                break;
            case "Fishing Net":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Fishing Net");
                SwitchTool();
                break;
            case "Harpoon Cannon":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Harpoon Canon");
                SwitchTool();
                break;
            case "Icebreaker":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Icebreaker");
                SwitchTool();
                break;
            case "Water pistol":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Waterpistol");
                SwitchTool();
                break;
            case "Figure Head":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Bathbomb Canon");
                SwitchTool();
                break;
        }
    }
    
    /// <summary>
    /// sets the images for the other rewards
    /// set one of the two true to get the image
    /// </summary>
    /// <param name="booster"></param>
    /// <param name="heart"></param>
    public void LoadImageOtherReward(bool booster, bool heart)
    {
        if(booster == true)
        {
            thisImage.sprite = Resources.Load<Sprite>("rewardheart");
        }
        else if(heart == true)
        {
            thisImage.sprite = Resources.Load<Sprite>("Boost Reward");
        }
    }

    private void SwitchCabin()
    {
        confirmationImage.enabled = true;
        confirmationImage.sprite = Resources.Load<Sprite>("switchcabin");
        OnYesNoCheck();
    }

    private void SwitchHull()
    {
        confirmationImage.enabled = true;
        confirmationImage.sprite = Resources.Load<Sprite>("switchhull");
        OnYesNoCheck();
    }

    private void SwitchTool()
    {
        confirmationImage.enabled = true;
        confirmationImage.sprite = Resources.Load<Sprite>("switchitem");
        OnYesNoCheck();
    }

    //if the player wants to change parts
    private bool OnYesNoCheck()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //instantiate new prefab
            DisableCanvas();
            confirmationImage.enabled = false;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            DisableCanvas();
            confirmationImage.enabled = false;
            return false;
        }
        else
        {
            return false;
        }
    }
}
