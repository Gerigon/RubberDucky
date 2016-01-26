using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpUI : MonoBehaviour {

    public GameObject popUpPanel;
    public Image thisImage;
    public Image confirmationImage;

    //public int yesPressed = 0;

    // Use this for initialization
    void Start()
    {
        //transform.position = transform.position + Vector3.up * imageHeight;

        DisableCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        if (confirmationImage.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                DisableCanvas();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                DisableCanvas();
            }
        }
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
        confirmationImage.enabled = false;
        popUpPanel.SetActive(false);
    }
    
    /// <summary>
    /// sets the images for the boat parts
    /// </summary>
    /// <param name="thisGameObject"></param>
    public void LoadImageBoatPart(string thisGameObject)
    {
        switch (thisGameObject)
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
            case "Water Pistol":
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
        if (booster == true)
        {
            thisImage.sprite = Resources.Load<Sprite>("rewardheart");
        }
        else if (heart == true)
        {
            thisImage.sprite = Resources.Load<Sprite>("Boost Reward");
        }
    }

    private void SwitchCabin()
    {
        confirmationImage.enabled = true;
        confirmationImage.sprite = Resources.Load<Sprite>("switchcabin");
        //StartCoroutine(OnYesNoCheck());
    }

    private void SwitchHull()
    {
        confirmationImage.enabled = true;
        confirmationImage.sprite = Resources.Load<Sprite>("switchhull");
        //StartCoroutine(OnYesNoCheck());
    }

    private void SwitchTool()
    {
        confirmationImage.enabled = true;
        confirmationImage.sprite = Resources.Load<Sprite>("switchitem");
        //StartCoroutine(OnYesNoCheck());
    }
    /*
    //if the player wants to change parts
    public IEnumerator OnYesNoCheck()
    {
        //Time.timeScale = 0;
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Y, KeyCode.N));
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode, KeyCode keyCode2)
    {
        while (!Input.GetKeyDown(keyCode) || (!Input.GetKeyDown(keyCode2)))
        {
            if (Input.GetKey(KeyCode.Y))
            {
                Debug.Log("Y pressed");
                DisableCanvas();
                confirmationImage.enabled = false;
                Time.timeScale = 1;
                yesPressed = 2;
            }
            else if (Input.GetKey(KeyCode.N))
            {
                Debug.Log("N pressed");
                DisableCanvas();
                confirmationImage.enabled = false;
                Time.timeScale = 1;
                yesPressed = 1;
            }

            yield return null;
        }
    }*/
}
