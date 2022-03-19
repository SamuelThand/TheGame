using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.Specialized;
using System;

public class PlayerController : MonoBehaviour
{
    // Refs
    public Avatar avatar;
    Rigidbody playerBody;
    public Transform cameraPoint;
    [SerializeReference] Camera playerCamera;
    
    
    [SerializeField] private CursorLockMode cursor;
    public string lockState;
    // Keypress variables
    private bool wKeywasPressed;
    private bool aKeywasPressed;
    private bool sKeywasPressed;
    private bool dKeywasPressed;
    private bool mouse0KeywasPressed;
    private bool mouse1KeywasPressed;


    // HUD
    [SerializeField] private string speedKMh;
    double currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = avatar.GetComponent<Rigidbody>();
        cameraPoint = avatar.cameraPoint;
    }

    // Update is called once per frame
    void Update()
    {   
        Cursor.lockState = (CursorLockMode)cursor;
        

        

        // Sets camera to camerapoint in Avatar
        playerCamera.transform.SetPositionAndRotation(avatar.cameraPoint.position, avatar.cameraPoint.rotation);

        

        if (Input.GetKey(KeyCode.W))
        {
            wKeywasPressed = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            aKeywasPressed = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            sKeywasPressed = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dKeywasPressed = true;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            mouse0KeywasPressed = true;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            mouse1KeywasPressed = true;
        }

    }
    private void FixedUpdate()
    {
        currentSpeed = Math.Round(playerBody.velocity.magnitude * 3.6);
        
        // Logs the current speed in KM/h to the playerController
        speedKMh = "" + ((Math.Round(playerBody.velocity.magnitude * 3.6)) + "Km/h");
        
        if (wKeywasPressed)
        {
            if (!(currentSpeed >= avatar.topSpeed)) {
            playerBody.AddForce(avatar.transform.forward * 25 * avatar.accelerationSpeed, ForceMode.Acceleration);
            wKeywasPressed = false;
            } 
        }
        if (aKeywasPressed)
        {
            playerBody.transform.Rotate(Vector3.up, -0.7f * avatar.turnSpeed);
            aKeywasPressed = false;
        }
        if (sKeywasPressed)
        {
            if (!(currentSpeed >= (avatar.topSpeed / 2))) {
            playerBody.AddForce(avatar.transform.forward * -20 * avatar.accelerationSpeed, ForceMode.Acceleration);
            sKeywasPressed = false;
            }
        }
        if (dKeywasPressed)
        {
            playerBody.transform.Rotate(Vector3.up, 0.7f * avatar.turnSpeed);
            dKeywasPressed = false;
        }
        if (mouse0KeywasPressed)
        {
            avatar.FirePrimary();
            mouse0KeywasPressed = false;
        }
        if (mouse1KeywasPressed)
        {
            avatar.FireSecondary();
            mouse1KeywasPressed = false;
        }

    }
    
}
