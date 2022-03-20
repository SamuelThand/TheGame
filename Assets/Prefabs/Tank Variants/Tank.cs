using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Vehicle
{
    // References
    [Header("Tank")]
    public Transform turret;
    public Transform cannon;


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

    }

    // Update is called once per frame
    void Update()
    {
        // Turrent rotation = Z / forward
        // Cannon rotation  = X / right

        // Turret rotation limit
        // rotationY = Mathf.Clamp(rotationY, MIN, MAX);
        
        // Cannon inclination limit
        mousePitchYaw.y = Mathf.Clamp(mousePitchYaw.y, cannonMinAngle, cannonMaxAngle);

        
    }
    private void FixedUpdate()
    {
        //Turret and Cannon chases "Camera" position here
        cannon.localEulerAngles = new Vector3(mousePitchYaw.y, cannon.localEulerAngles.y,cannon.localEulerAngles.z);
        turret.localEulerAngles = new Vector3(turret.localEulerAngles.x,turret.localEulerAngles.y, mousePitchYaw.x + 90);
        
       
    }
    private void OnValidate()
    {

    }
}
