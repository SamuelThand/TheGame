using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key
{
    public KeyCode code;
    public bool state;
    public Func<KeyCode, bool> func;
}
public class KeyListener
{
    List<Key> keys;
    public KeyListener()
    {

    }

    void Add(KeyCode key,Func<KeyCode,bool> func)
    {
        Key newKey = new Key();
        newKey.code = key;
        newKey.func = func;
        newKey.state = false;
    }
    void AddRange(List<KeyCode> newKeys)
    {

    }
    void scan()
    {
        foreach (Key key in keys)
        {
            if (key.func(key.code))
            {
                key.state = true;
            }
        }
    }
}
public class Helper : MonoBehaviour
{
    

   
    void Start()
    {

        
    }

    
    void Update()
    {
        

    }

    
    private List<KeyCode> AddNumeric()
    {
        List<KeyCode> numeric = new List<KeyCode>();
        //Keys
        numeric.Add(KeyCode.Alpha0);
        numeric.Add(KeyCode.Alpha1);
        numeric.Add(KeyCode.Alpha2);
        numeric.Add(KeyCode.Alpha3);
        numeric.Add(KeyCode.Alpha4);
        numeric.Add(KeyCode.Alpha5);
        numeric.Add(KeyCode.Alpha6);
        numeric.Add(KeyCode.Alpha7);
        numeric.Add(KeyCode.Alpha8);
        numeric.Add(KeyCode.Alpha9);
        //
        
        return numeric;
    }
    private List<KeyCode> AddKeypad()
    {
        List<KeyCode> keypad = new List<KeyCode>();
        //Keys
        keypad.Add(KeyCode.Keypad0);
        keypad.Add(KeyCode.Keypad1);
        keypad.Add(KeyCode.Keypad2);
        keypad.Add(KeyCode.Keypad3);
        keypad.Add(KeyCode.Keypad4);
        keypad.Add(KeyCode.Keypad5);
        keypad.Add(KeyCode.Keypad6);
        keypad.Add(KeyCode.Keypad7);
        keypad.Add(KeyCode.Keypad8);
        keypad.Add(KeyCode.Keypad9);
        //
        return keypad;
    }
    private List<KeyCode> AddMove()
    {
        List<KeyCode> move = new List<KeyCode>();
        //Keys
        move.Add(KeyCode.W);
        move.Add(KeyCode.A);
        move.Add(KeyCode.S);
        move.Add(KeyCode.D);
        move.Add(KeyCode.LeftShift);
        move.Add(KeyCode.LeftControl);
        move.Add(KeyCode.Space);
        //
        return move;
    }
    private List<KeyCode> AddMouse()
    {
        List<KeyCode> mouse = new List<KeyCode>();
        //keys
        mouse.Add(KeyCode.Mouse0);
        mouse.Add(KeyCode.Mouse1);
        mouse.Add(KeyCode.Mouse2);
        //
        return mouse;
    }
    
}
