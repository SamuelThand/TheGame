using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class M1 : Tank
{
    string displayName;
    
    // Start is called before the first frame update
    void Start()
    {
        printMessage += "M1";
        displayName = "M1 Destroyer";
        Debug.Log(printMessage);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
