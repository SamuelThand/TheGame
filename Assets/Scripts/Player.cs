using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    string handle;
    [SerializeField] private Camera cam;
    private Vector3 orbitPosition = Vector3.zero;
    private int vOrbitLimit = 360;
    private int hOrbitLimit = 360;
    //Vehicle me;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cam.transform.position = orbitPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            orbitPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("s");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("a");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("d");
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = orbitPosition - cam.ScreenToViewportPoint(Input.mousePosition); //Normalized?

            cam.transform.position = new Vector3();
            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), direction.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0, 0, -10));

            orbitPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        //Debug.Log("Camera:" + cam.transform.rotation.x);
    }
}
