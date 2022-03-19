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
    [SerializeField] private int cannonMinAngle = -5;
    [SerializeField] private int cannonMaxAngle = 20;
    [SerializeField] bool turretCam;


    // Mouse rotation
    
    private float sensitivityX = 1.2f;
    private float sensitivityY = 1.0f;
    
    private Vector2 mouseOffset = Vector2.zero;

    private float rotationX = 0f;
    private float rotationY = 0f;
    public float distanceFromAvatar = 1;

    // Logs
    

    // Start is called before the first frame update
    void Start()
    {
         
        

    }

    // Update is called once per frame
    void Update()
    {
        // Turrent rotation = Z / forward
        // Cannon rotation  = X / right


        rotationX += (mousePosition.x * sensitivityX - mouseOffset.x);
        rotationY += (mousePosition.y * sensitivityY - mouseOffset.y);

        // Uncomment for turret turning limit
        // rotationY = Mathf.Clamp(rotationY, MIN, MAX);
        
        rotationY = Mathf.Clamp(rotationY, cannonMinAngle, cannonMaxAngle);

        
    }
    private void FixedUpdate()
    {
        //Turret and Cannon chases "Camera" position here
        cannon.localEulerAngles = new Vector3(rotationY,cannon.localEulerAngles.y,cannon.localEulerAngles.z);
        turret.localEulerAngles = new Vector3(turret.localEulerAngles.x,turret.localEulerAngles.y,rotationX-90);
       
    }
    private void OnValidate()
    {
        if (turretCam)
        {
            cameraPoint.parent = turret;
        }
        else
        {
            cameraPoint.parent = this.transform;
        }
    }
}
