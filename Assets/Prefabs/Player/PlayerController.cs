using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.Specialized;

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

    
    
    
        
       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCamera.transform.SetPositionAndRotation(avatar.cameraPoint.position, avatar.cameraPoint.rotation);
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
        if (wKeywasPressed)
        {
            playerBody.AddForce(avatar.transform.forward * 25, ForceMode.Acceleration);
            wKeywasPressed = false;
        }
        if (aKeywasPressed)
        {
            playerBody.transform.Rotate(Vector3.up, -0.7f);
            
            aKeywasPressed = false;
        }
        if (sKeywasPressed)
        {
            playerBody.AddForce(avatar.transform.forward * -20, ForceMode.Acceleration);
            sKeywasPressed = false;
        }
        if (dKeywasPressed)
        {
            playerBody.transform.Rotate(Vector3.up, 0.7f);
            dKeywasPressed = false;
        }
    }
}
