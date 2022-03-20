using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Vehicle
{
    // References
    [Header("Tank")]
    public Transform turret;
    public Transform cannon;
    [SerializeReference] int primaryTemp;
    [SerializeReference] int secondaryTemp;

    // Attributes
    public float turretSpeed = 1;
    public float cannonSpeed = 1;
    [SerializeField] private int cannonMinAngle;
    [SerializeField] private int cannonMaxAngle;
    [SerializeField] bool turretCam;

    

    

    // Start is called before the first frame update
    void Start()
    {
        
        //cameraPoint.parent = turret;
        cameraPoint.parent = cannon;
        primaryWeaponPoint.parent = cannon;
        secondaryWeaponPoint.parent = turret;
        weapons[0] = Instantiate(weapons[0],primaryWeaponPoint.position,primaryWeaponPoint.rotation,primaryWeaponPoint);
        weapons[0].shooter = this;
        weapons[1] = Instantiate(weapons[1],secondaryWeaponPoint.position, secondaryWeaponPoint.rotation, secondaryWeaponPoint);
        weapons[1].shooter = this;
        
        //weapons[1].transform.SetPositionAndRotation(secondaryWeaponPoint.position, turret.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        primaryTemp = weapons[0].coolingTimer;
        secondaryTemp = weapons[1].coolingTimer;
        
        // Set limits
        mousePitchYaw.y = Mathf.Clamp(mousePitchYaw.y, cannonMinAngle, cannonMaxAngle);
        //mousePitchYaw.x = Mathf.Clamp(mousePitchYaw.x, MIN, MAX);
        
    }
    private void FixedUpdate()
    {
        //Turret and Cannon chases "Camera" position here
        cannon.localEulerAngles = new Vector3(mousePitchYaw.y, cannon.localEulerAngles.y,cannon.localEulerAngles.z);
        turret.localEulerAngles = new Vector3(turret.localEulerAngles.x,mousePitchYaw.x,turret.localEulerAngles.z );
        
       
    }
    private void OnValidate()
    {

    }
}
