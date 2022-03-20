using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    // Enums
    public enum WeaponTypes { primary, secondary };

    // Refs
    public WeaponTypes type;

    //Sound
    private Transform weaponPoint;

    

    // Attributes
    public float coolDown;
    public float range;
    public Ammo ammunition;
    public bool _isCooling = false;
    public int coolingTimer;

    // Getter Setter
    public bool IsCooling
    {
        get             
        {
            return _isCooling;
        }
        set            
        {
            
            _isCooling = value;
            if (value)
            {
                coolingTimer = (int)Mathf.Round(coolDown * 100);
                Debug.Log((WeaponTypes)type + ":Boom");
                Invoke("resetCooling",coolDown);
            }
        }
    }
    public void resetCooling()
    {
        IsCooling = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        _isCooling = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(coolingTimer > 0)
        {
            coolingTimer--;
            
        }Debug.Log((WeaponTypes)type + ":" + coolingTimer);
    }
    public Ammo SetAmmunition(Ammo a)
    {
        Ammo oldAmmo = ammunition;
        this.ammunition = a;
        return oldAmmo;
    }
    /*
    // "yield" causes delay before continuing
    static private IEnumerator Stall(int weapon)
    {
        yield return new WaitForSecondsRealtime(weapons[weapon].coolDown);
        weapons[weapon].isCooling = false;
        Debug.Log((WeaponLabel)weapon + "  cooling ended");
    }
    static private void startCoolingWeapon(int weapon)
    {
        StartCoroutine(Stall(weapon));
    }
    */
}
