using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpUI : MonoBehaviour {

    public Camera boatCamera;
    public Canvas thisCanvas;
    public Image thisImage;

    public float waitingTime = 5f;

    public float imageHeight = 2f;

	// Use this for initialization
	void Start ()
    {
        boatCamera = Camera.main;
        thisCanvas = gameObject.GetComponent<Canvas>();
        thisCanvas.worldCamera = boatCamera;

        thisImage = gameObject.GetComponentInChildren<Image>();

        transform.position = transform.position + Vector3.up * imageHeight;

        DisableCanvas();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(thisCanvas.enabled == true)
        {

            //rotation
            Vector3 v = boatCamera.transform.position - transform.position;
            v.z = 0f;
            transform.LookAt(boatCamera.transform.position - v);
            transform.Rotate(0, 180, 0);
        }

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
        thisCanvas.transform.gameObject.SetActive(true);
    }

    /// <summary>
    /// Disables the Canvas GameObject
    /// </summary>
    public void DisableCanvas()
    {
        thisCanvas.transform.gameObject.SetActive(false);
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
                StartCoroutine(SwitchHull());
                break;
            case "Fast Hull":
                thisImage.sprite = Resources.Load<Sprite>("Hull/Speed Hull");
                StartCoroutine(SwitchHull());
                break;
            case "Standart Hull":
                thisImage.sprite = Resources.Load<Sprite>("Hull/Basic Hull");
                StartCoroutine(SwitchHull());
                break;
            case "Sturdy Hull":
                thisImage.sprite = Resources.Load<Sprite>("Hull/Sturdy Hull");
                StartCoroutine(SwitchHull());
                break;

            case "Standard Cabin":
                thisImage.sprite = Resources.Load<Sprite>("Cabin/Basic Cabin");
                StartCoroutine(SwitchCabin());
                break;
            case "Nitro Cabin":
                thisImage.sprite = Resources.Load<Sprite>("Cabin/Nitro Cabin");
                StartCoroutine(SwitchCabin());
                break;
            case "Mist Cabin":
                thisImage.sprite = Resources.Load<Sprite>("Cabin/Mist Cabin");
                StartCoroutine(SwitchCabin());
                break;
            case "Super Cabin":
                thisImage.sprite = Resources.Load<Sprite>("Cabin/Super Cabin");
                StartCoroutine(SwitchCabin());
                break;

            case "Bathbomb Cannon":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Bathbomb Canon");
                StartCoroutine(SwitchTool());
                break;
            case "Fishing Net":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Fishing Net");
                StartCoroutine(SwitchTool());
                break;
            case "Harpoon Cannon":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Harpoon Canon");
                StartCoroutine(SwitchTool());
                break;
            case "Icebreaker":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Icebreaker");
                StartCoroutine(SwitchTool());
                break;
            case "Water pistol":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Waterpistol");
                StartCoroutine(SwitchTool());
                break;
            case "Figure Head":
                thisImage.sprite = Resources.Load<Sprite>("Tool/Bathbomb Canon");
                StartCoroutine(SwitchTool());
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

    private IEnumerator SwitchCabin()
    {
        yield return new WaitForSeconds(waitingTime);
        thisImage.sprite = Resources.Load<Sprite>("switchcabin");
        OnYesNoCheck();
    }

    private IEnumerator SwitchHull()
    {
        yield return new WaitForSeconds(waitingTime);
        thisImage.sprite = Resources.Load<Sprite>("switchhull");
        OnYesNoCheck();
    }

    private IEnumerator SwitchTool()
    {
        yield return new WaitForSeconds(waitingTime);
        thisImage.sprite = Resources.Load<Sprite>("switchitem");
        OnYesNoCheck();
    }

    //if the player wants to change parts
    private void OnYesNoCheck()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            //instantiate new prefab
            DisableCanvas();
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            DisableCanvas();
        }
    }
}
