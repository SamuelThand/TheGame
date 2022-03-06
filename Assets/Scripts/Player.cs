using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    string handle;
    Vector2 rotation = Vector2.zero;
    public float speed = 3;
    //Vehicle me;
    // Start is called before the first frame update
    void Start()
    {
        
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
