using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public Camera cam;
    public GameObject p1;
    public GameObject p2;
    public GameObject pOut;

    public float screenX;
    public float screenY;
    public Vector3 mouse3D;
    public float offX;
    public float offY;
    public float speed = 1;
    Vector2 rotation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = p1.transform.position;
        /*
        screenX = Input.mousePosition.x;   
        screenY = Input.mousePosition.y;   
        mouse3D = cam.ScreenToViewportPoint(new Vector3(screenX,screenY,1));
        offX = mouse3D.x - p2.transform.position.x;
        offY = mouse3D.y - p2.transform.position.y;
        //pOut.transform.position = mouse3D;
        */
        
   
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        p1.transform.eulerAngles = (Vector2)rotation * speed;



        cam.transform.position = p1.transform.position;
        cam.transform.rotation = p1.transform.rotation;

    }
}
