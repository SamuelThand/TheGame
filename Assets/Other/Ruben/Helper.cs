using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RMInputEventListener;



public class Helper : MonoBehaviour
{
    InputEventListener listener = new InputEventListener();
    void Start()
    {
        listener.listenTo(KeyCode.Keypad0, testCallBack);
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    public void testCallBack(List<KeyCode> keyCodes)
    {
        Debug.Log("This is working.");
    }
}
