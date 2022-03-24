using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.Specialized;
using System;

public class PlayerController : MonoBehaviour
{
    // Refs
    public  Avatar avatar;
    private Rigidbody playerBody;
    private Transform cameraPoint;
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

    // 
    public Vector3 mouseOffset;
    public Vector3 mousePosition;
    public float mouseX;
    public float mouseY;
    public Vector2 mouseScrollDelta;

    // HUD
    [SerializeField] private string speedKMh;
    private double currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = avatar.GetComponent<Rigidbody>();
        cameraPoint = avatar.cameraPoint;
        Cursor.lockState = (CursorLockMode)cursor;
        mouseOffset = Input.mousePosition;
        //offsetX = Input.GetAxis("Mouse X");
        //offsetY = Input.GetAxis("Mouse Y");

    }

    // Update is called once per frame
    void Update()
    {   
        // Sets camera to camerapoint in Avatar
        playerCamera.transform.SetPositionAndRotation(avatar.cameraPoint.position, avatar.cameraPoint.rotation);
        
        // Keys
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

        // Mouse
        mousePosition.x = Input.GetAxis("Mouse X");
        mousePosition.y = Input.GetAxis("Mouse Y");
        avatar.SetMouse(mousePosition);

        mouseScrollDelta = Input.mouseScrollDelta;
        avatar.SetScrollDelta(mouseScrollDelta);
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            avatar.FirePrimary();
            mouse0KeywasPressed = true;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            avatar.FireSecondary();
            mouse1KeywasPressed = true;
        }
    }
    private void FixedUpdate()
    {
        currentSpeed = Math.Round(playerBody.velocity.magnitude * 3.6);
        
        // Logs the current speed in KM/h to the playerController
        speedKMh = "" + ((Math.Round(playerBody.velocity.magnitude * 3.6)) + "Km/h");

        // Keys
        if (wKeywasPressed)
        {
            if (!(currentSpeed >= avatar.topSpeed)) {
            playerBody.AddForce(avatar.transform.forward * 100 * avatar.accelerationSpeed, ForceMode.Acceleration);
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
            playerBody.AddForce(avatar.transform.forward * -100 * avatar.accelerationSpeed, ForceMode.Acceleration);
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
