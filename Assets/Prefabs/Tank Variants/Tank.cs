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
    Vector2 mouseRotation = Vector2.zero;
    private float sensitivityX = 1.2f;
    private float sensitivityY = 1.0f;
    
    private float offsetX;
    private float offsetY;

    private float rotationX = 0f;
    private float rotationY = 0f;
    public float distanceFromAvatar = 1;

    // Logs
    

    // Start is called before the first frame update
    void Start()
    {
         
        offsetX = Input.GetAxis("Mouse X") * sensitivityX;
        offsetY = Input.GetAxis("Mouse Y") * sensitivityY;

    }

    // Update is called once per frame
    void Update()
    {
        // Turrent rotation = Z / forward
        // Cannon rotation  = X / right

        rotationX += (Input.GetAxis("Mouse X") * sensitivityX) - offsetX;
        rotationY += (Input.GetAxis("Mouse Y") * sensitivityY) - offsetY;

        // Uncomment for turret turning limit
        // rotationY = Mathf.Clamp(rotationY, MIN, MAX);
        rotationY = Mathf.Clamp(rotationY, cannonMinAngle, cannonMaxAngle);


        cannon.localEulerAngles = new Vector3(rotationY,cannon.localEulerAngles.y,cannon.localEulerAngles.z);
        turret.localEulerAngles = new Vector3(turret.localEulerAngles.x,turret.localEulerAngles.y,rotationX-90);
    }
    private void FixedUpdate()
    {

       
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
