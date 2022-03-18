using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Helper : MonoBehaviour
{

    void Start()
    {
        RMListener.Listen(true);
        RMListener.listener.Howl();

    }

    void ChosenCallBack(KeyCode keyCode)
    {
        Debug.Log("CallBack" + keyCode);
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }



    
}
