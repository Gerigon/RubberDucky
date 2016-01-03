 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartSelecterUI : MonoBehaviour {

    public GameObject partSelectPanel = null;

    public GameObject[] hulls = null;
    public GameObject[] cabins = null;
    public GameObject[] weapons = null;

    public Text currentHullText = null;
    public Text currentCabinText = null;
    public Text currentWeaponText = null;

    private int currentHullNumber = 0;
    private int currentCabinNumber = 0;
    private int currentWeaponNumber = 0;

    public GameObject boat;

	// Use this for initialization
	void Start ()
    {
        partSelectPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.I))
        {
            onInventory();
        }
	}

    public void onInventory()
    {
        Time.timeScale = 0f;
        partSelectPanel.SetActive(true);
    }

    public void onResume()
    {
        Time.timeScale = 1f;
        partSelectPanel.SetActive(false);
    }

    public void onNextHull()
    {
        Destroy(GameObject.FindGameObjectWithTag("Hull"));
        if (currentHullNumber == hulls.Length -1)
        {
            currentHullNumber = 0;
        }
        else
        {
            currentHullNumber++;
        }
        GameObject newHull = Instantiate(hulls[currentHullNumber]);
        Vector3 position = newHull.transform.position + new Vector3(boat.transform.position.x, boat.transform.position.y, boat.transform.position.z);
        newHull.transform.Translate(position, Space.World);
        newHull.transform.SetParent(boat.transform);
        currentHullText.text = newHull.name;
    }

    public void onNextCabin()
    {
        Destroy(GameObject.FindGameObjectWithTag("Cabin"));
        if (currentCabinNumber == cabins.Length -1)
        {
            currentCabinNumber = 0;
        }
        else
        {
            currentCabinNumber++;
        }
        GameObject newCabin = Instantiate(cabins[currentCabinNumber]);
        Vector3 position = newCabin.transform.position + new Vector3(boat.transform.position.x, boat.transform.position.y, boat.transform.position.z);
        newCabin.transform.Translate(position, Space.World);
        newCabin.transform.SetParent(boat.transform);
        currentCabinText.text = newCabin.name;
    }

    public void onNextWeapon()
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        if (currentWeaponNumber == weapons.Length -1)
        {
            currentWeaponNumber = 0;
        }
        else
        {
            currentWeaponNumber++;
        }
        GameObject newWeapon = Instantiate(weapons[currentWeaponNumber]);
        Vector3 position = newWeapon.transform.position + new Vector3(boat.transform.position.x, boat.transform.position.y, boat.transform.position.z);
        newWeapon.transform.Translate(position, Space.World);
        newWeapon.transform.SetParent(boat.transform);
        currentWeaponText.text = newWeapon.name;
    }
}
