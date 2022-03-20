using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    // Enums
    public enum WeaponTypes { primary, secondary };

    // Refs
    public WeaponTypes type;
    [SerializeReference] private Transform ammoSpawnPoint;

    //Sound
    private Transform weaponPoint;

    

    // Attributes
    public float coolDown;
    public float range;
    public Ammo ammunition;
    private int rpm;
    [SerializeReference] public bool _isCooling = false;
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
                // Instantiate projectile
                Ammo shot = Instantiate(ammunition,ammoSpawnPoint.position, ammoSpawnPoint.rotation);
                //shot.GetComponent<Rigidbody>().AddForce(shot.transform.forward * ammunition.velocity,ForceMode.VelocityChange);
                shot.GetComponent<Rigidbody>().mass = ammunition.mass;
                shot.GetComponent<Rigidbody>().velocity = shot.transform.forward * ammunition.velocity;
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
        IsCooling = false;

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
        }
    }
    public Ammo SetAmmunition(Ammo a)
    {
        Ammo oldAmmo = ammunition;
        this.ammunition = a;
        return oldAmmo;
    }
}
