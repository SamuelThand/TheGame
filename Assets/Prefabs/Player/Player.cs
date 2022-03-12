using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // [SerializeField]private bool firstPerson = false;
    string handle;
    [SerializeField] private Camera cam;
    private Vector3 orbitPosition = Vector3.zero;
    // private int vOrbitLimit = 360;
    // private int hOrbitLimit = 360;
    Avatar avatar;
    [SerializeField]List<GameObject> os;

    private Rigidbody playerBody;

    // Keypress variables
    private bool wKeywasPressed;
    private bool aKeywasPressed;
    private bool sKeywasPressed;
    private bool dKeywasPressed;
    private bool mouse0KeywasPressed;

    // Start is called before the first frame update
    void Start()
    {

        //avatar = GetComponent<Cap>();

        // currently not working, ruben fix
        // cam = Camera.main;
        // cam.transform.position = orbitPosition;
        playerBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     orbitPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        // }

        if(Input.GetKey(KeyCode.W))
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

        // Currently not functioning - ruben fix
        // if (Input.GetMouseButton(0))
        // {
        //     Vector3 direction = orbitPosition - cam.ScreenToViewportPoint(Input.mousePosition); //Normalized?

        //     cam.transform.position = new Vector3();
        //     cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
        //     cam.transform.Rotate(new Vector3(0, 1, 0), direction.x * 180, Space.World);
        //     cam.transform.Translate(new Vector3(0, 0, -10));
            

        //     orbitPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        // }
        //Debug.Log("Camera:" + cam.transform.rotation.x);
    }

    private void FixedUpdate() {

        if (wKeywasPressed)
        {
            playerBody.AddForce(transform.forward * 100, ForceMode.Acceleration);
            wKeywasPressed = false;
        }
        if (aKeywasPressed)
        {
            transform.Rotate(Vector3.up, -5f);
            aKeywasPressed = false;
        }
        if (sKeywasPressed)
        {
            playerBody.AddForce(transform.forward * -30, ForceMode.Acceleration);
            sKeywasPressed = false;
        }
        if (dKeywasPressed)
        {
            transform.Rotate(Vector3.up, 5f);
            dKeywasPressed = false;
        }
    }
}
