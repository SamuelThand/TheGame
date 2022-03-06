using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vehicle : MonoBehaviour
{
    private protected string printMessage;

    // Start is called before the first frame update
    void Start()
    {
        printMessage = "Vehicle ";
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(base.name);
    }
    protected void PrintInfo()
    {
        Debug.Log(printMessage);
    }

}
