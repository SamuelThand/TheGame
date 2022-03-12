using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.Specialized;
using System;

public class PlayerController : MonoBehaviour
{

    public Avatar avatar;
    Rigidbody playerBody;
    public Transform cameraPoint;
    [SerializeReference] Camera playerCamera;

    // Keypress variables
    private bool wKeywasPressed;
    private bool aKeywasPressed;
    private bool sKeywasPressed;
    private bool dKeywasPressed;
    private bool mouse0KeywasPressed;

    // HUD 
    private double currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sets camera to camerapoint in Avatar
        playerCamera.transform.SetPositionAndRotation(avatar.cameraPoint.position, avatar.cameraPoint.rotation);

        // TODO - Få bórt detta från update
        playerBody = avatar.GetComponent<Rigidbody>();

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
        
        
    }
    private void FixedUpdate()
    {
        currentSpeed = Math.Round(playerBody.velocity.magnitude * 3.6);
        
        // Logs the current speed in KM/h to console
        Debug.Log((Math.Round(playerBody.velocity.magnitude * 3.6)) + "Km/h");
        
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
    }
}
