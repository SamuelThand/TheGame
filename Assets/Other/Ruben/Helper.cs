using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RMInputEventListener;



public class Helper : MonoBehaviour
{
    
    void Start()
    {
        InputEventListener.MTListener.listenTo(KeyCode.Alpha0, TestCallBack);
        
    }

   

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    public void TestCallBack(KeyCode c)
    {
        Debug.Log("This is working.");
    }
}
