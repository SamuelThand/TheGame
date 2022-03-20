using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Refs
    //Sound
    private Transform weaponPoint;

    // Attributes
    public float coolDown;
    public float range;
    public Ammo ammunition;
    public bool isCooling = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Ammo SetAmmunition(Ammo a)
    {
        Ammo oldAmmo = ammunition;
        this.ammunition = a;
        return oldAmmo;
    }
}
