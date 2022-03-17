using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RMInputEventListener;


public class Helper : MonoBehaviour
{


    public List<KeyCode> keyList;
    public List<bool> boolList;
    
    void Start()
    {
        InputEventListener.ActivateMTListener();
        InputEventListener MTListener = InputEventListener.MTListener;
        MTListener.Howl();
        MTListener.listenTo(KeyCode.Space ,ChosenCallBack);
        Debug.Log("Listener" + MTListener);
        keyList  = InputEventListener.MTListener.keyList;
        boolList = InputEventListener.MTListener.boolList;
        InputEventListener.MTListener.scanner.Howl();
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
