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


    private Cabin currentCabin;
    private Hull currentHull;
    private Weapons currentWeapon;
	// Use this for initialization
	void Start ()
    {
        currentCabin = Cabin.StandardCabin;
        currentHull = Hull.StandardHull;
        currentWeapon = Weapons.WaterPistol;

        SwitchEquipment(Hull.FastHull);
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void SwitchEquipment(Cabin newCabin)
    {
        foreach (Transform child in transform.GetChild(1).transform)
        {
            child.gameObject.SetActive(false);
            if (child.gameObject.name == newCabin.ToString())
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    public void SwitchEquipment(Hull newHull)
    {
        foreach (Transform child in transform.GetChild(0).transform)
        {
            child.gameObject.SetActive(false);
            if (child.gameObject.name == newHull.ToString())
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    public void SwitchEquipment(Weapons newWeapon)
    {
        foreach (Transform child in transform.GetChild(2).transform)
        {
            child.gameObject.SetActive(false);
            if (child.gameObject.name == newWeapon.ToString())
            {
                child.gameObject.SetActive(true);
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
