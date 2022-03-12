using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    // Attributes
    public float turretSpeed = 1;
    public float cannonSpeed = 1;
    
    // References
    public Transform turret;
    public Transform cannon;

    // Mouse rotation
    Vector2 mouseRotation = Vector2.zero;
    private float mouseSpeed = 1;
    public float distanceFromAvatar = 1;

    // Logs
    public Quaternion tRot;
    public Quaternion cRot;
    public Vector2 turretRotation;
    public Vector2 cannonRotation;
    public Quaternion tankRotation;
    public Transform ROT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Turrent rotation = Z / forward
        // Cannon rotation  = X / right

        mouseRotation = new Vector2 (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Quaternion rotation = turret.transform.rotation;
        turret.Rotate(Vector3.forward*mouseRotation.x*turretSpeed);
        cannon.Rotate(Vector3.right*mouseRotation.y*cannonSpeed);

        /*
        this.transform.rotation;
        tRot = turret.rotation;
        cRot = cannon.rotation;
        tankRotation = this.transform.rotation;
        // Mouselook on cameraPoint
        

        turretRotation = new Vector2(-90,mouseRotation.y);

        cannon.rotation = turret.rotation;
        cannonRotation = new Vector3(-mouseRotation.x-90,mouseRotation.y,1);

        turret.eulerAngles = (Vector2)turretRotation * mouseSpeed;
        cannon.eulerAngles = cannonRotation * mouseSpeed;

        //cannon.eulerAngles = (Vector2)cannonRotation * cannonSpeed;
        //turret.eulerAngles = (Vector2)mouseRotation * mouseSpeed;
        */
    }
}
