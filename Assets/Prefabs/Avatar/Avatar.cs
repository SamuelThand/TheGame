using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    //
    

    // Refs
    [Header("Avatar")]
    [SerializeReference] public Transform cameraPoint;
    public Vector2 mousePitchYaw;
    public Weapon[] weapons;

    // Attributes
    [Min(0)] public float weight = 1;
    [Min(0)] public float topSpeed = 1;
    [Min(0)] public float turnSpeed = 1;
    [Min(0)] public float accelerationSpeed = 1;

    // Mouse rotation
    private float sensitivityX = 1.2f;
    private float sensitivityY = 1.0f;
    private Vector2 mouseOffset = Vector2.zero;

    // As different ammo eventually is developed theese variable will become obsolete
    //private  int[] weaponCoolDown  = { 10, 5 };
    //private bool[] isWeaponCooling = { false, false };



    public void SetMouse(Vector3 mp)
    {
        mousePitchYaw.x += mp.x * sensitivityX - mouseOffset.x;
        mousePitchYaw.y += (mp.y*-1) * sensitivityY - mouseOffset.y;
        
    }
    public void SetScrollDelta(Vector2 sd)
    {
        cameraPoint.Translate(Vector3.forward*sd.y);
    }
    public void SetMove()
    {

    }
    public bool FirePrimary()
    {
        return FireWeapon(0);
    }
    public bool FireSecondary()
    {
        return FireWeapon(1);
    }
    /* Uncomment for third and forth weapon
    public bool FireTertiary()
    {
        return FireWeapon(2);
    }
    public bool FireQuaternary()
    {
        return FireWeapon(3);
    }
    */

    
   

    // Fires chosen weapon if not cooling and starts cooldown. Returns if it was fired
    public bool FireWeapon(int weapon)
    {
        bool cooling = weapons[weapon].IsCooling;
        Debug.Log("Fire? - " + cooling);
        bool wasWeaponFired = false; // !weapons[weapon].IsCooling;
        if (!weapons[weapon].IsCooling)
        {
            // Fire!
            Debug.Log("Weaponn will fire");
            weapons[weapon].IsCooling = true;
        }
        else if (weapons[weapon].IsCooling)
        {
            // Dont fire, still cooling.
        }
        return wasWeaponFired;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

// GameObject obj = Instantiate(bullet) as GameObject;
