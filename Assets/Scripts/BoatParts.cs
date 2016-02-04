using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Cabin
{
    MistCabin,
    NitroCabin,
    StandardCabin,
    SuperCabin
}

public enum Hull
{
    FastHull,
    StandardHull,
    SturdyHull,
    SuperHull
}

public enum Weapons
{
    BathbombCannon,
    FigureHead,
    FishingNet,
    HarpoonCannon,
    Icebreaker,
    MisthornSmall,
    WaterPistol
}

public class BoatParts : MonoBehaviour {

    private GameObject owner;

    public Cabin currentCabin;
    public Hull currentHull;
    public Weapons currentWeapon;

    public GameObject currentCabinGO;
    public GameObject currentHullGO;
    public GameObject currentWeaponGO;
	// Use this for initialization
	void Start ()
    {
        owner = GameObject.Find("Boat");

        currentCabin = Cabin.StandardCabin;
        currentHull = Hull.StandardHull;
        currentWeapon = Weapons.WaterPistol;

        currentCabinGO = GameObject.Find("StandardHull");
        currentHullGO = GameObject.Find("StandardCabin");
        currentWeaponGO = GameObject.Find("WaterPistol");
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void SwitchEquipment(Cabin newCabin)
    {
        Debug.Log("Switch");
        foreach (Transform child in transform.GetChild(1).transform)
        {
            child.gameObject.SetActive(false);
            if (child.gameObject.name == newCabin.ToString())
            {
                child.gameObject.SetActive(true);
                currentCabin = newCabin;
                currentCabinGO = child.gameObject;
            }
        }
    }
    public void SwitchEquipment(Hull newHull)
    {
        Debug.Log("Switch");
        foreach (Transform child in transform.GetChild(0).transform)
        {
            child.gameObject.SetActive(false);
            if (child.gameObject.name == newHull.ToString())
            {
                child.gameObject.SetActive(true);
                currentHull = newHull;
                currentHullGO = child.gameObject;
            }
        }
    }
    public void SwitchEquipment(Weapons newWeapon)
    {
        Debug.Log("Switch");
        foreach (Transform child in transform.GetChild(2).transform)
        {
            child.gameObject.SetActive(false);
            if (child.gameObject.name == newWeapon.ToString())
            {
                child.gameObject.SetActive(true);
                currentWeapon = newWeapon;
                currentWeaponGO = child.gameObject;
                owner.GetComponent<BoatCamera>().cameraAxis = currentWeaponGO.transform.GetChild(4).gameObject;
                owner.GetComponent<Player>().crossHair = owner.GetComponent<BoatCamera>().crossHair = currentWeaponGO.transform.GetChild(3).gameObject;
                 
                
            }
        }
    }
    public void AddEquipment(Weapons newWeapon)
    {
        foreach (Transform child in transform.GetChild(2).transform)
        {
            if (child.gameObject.name == newWeapon.ToString())
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    public void ReceiveItem<T>(Object item)
    {
        if (item is T)
        {

        }
    }
}
