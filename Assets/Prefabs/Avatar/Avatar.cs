using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    //
    private enum weaponLabel { primary,secondary};

    // Refs
    [SerializeReference] public Transform cameraPoint;
    public PlayerController player;

    // Attributes
    [Min(0)] public float weight = 1;
    [Min(0)] public float topSpeed = 1;
    [Min(0)] public float turnSpeed = 1;
    [Min(0)] public float accelerationSpeed = 1;


    // As different ammo eventually is developed theese variable will become obsolete
    private  int[] weaponCoolDown  = { 10, 5 };
    private bool[] isWeaponCooling = { false, false };





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
    
    private void resetCoolDownForWeapon(int weapon)
    {
        isWeaponCooling[weapon] = false;
        Debug.Log((weaponLabel)weapon + "  cooling ended");
    }

    // Fires chosen weapon if not cooling and starts cooldown. Returns if it was fired
    public bool FireWeapon(int weapon)
    {

        bool wasWeaponFired = false;
        if (!isWeaponCooling[weapon])
        {
            // Fire!
            Debug.Log((weaponLabel)weapon + " will fire");
            isWeaponCooling[weapon] = true;
            wasWeaponFired = true;
            string resetCoolDown = "resetCoolDownForWeapon(" + weapon + ")";
            Invoke(resetCoolDown,weaponCoolDown[weapon]);
            
        }
        else if (isWeaponCooling[weapon])
        {
            // Dont fire.
            Debug.Log((weaponLabel)weapon + " is still cooling");
            wasWeaponFired = false;
        }
        return wasWeaponFired;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Sets reference to avatar
        player.avatar = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

// GameObject obj = Instantiate(bullet) as GameObject;
