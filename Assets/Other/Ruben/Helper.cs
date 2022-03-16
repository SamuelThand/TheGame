using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RMInputEventListener;

/*
public class KeyListener
{
    [SerializeField] public List<Key> keys;
    public KeyListener()
    {
        keys = new List<Key>();
    }
    public void AddKey(Key key)
    {
        if (key.func != null)
            key.func = Input.GetKey;

        keys.Add(key);
    }
    public void AddKeyCodeRange(List<KeyCode> ListOfKeys )
    {
        foreach( KeyCode k in ListOfKeys )
        {
            AddKey(new Key(k));
        }
    }
    public void scan()
    {
        foreach (Key key in keys)
        {
            bool result = key.func(key.code); 
            ;
            if (result)
            {
                key.state = true;
                Debug.Log("You pressed: " + key.code.ToString());
            }
        }
    }
    public void falsify()
    {
        foreach (Key key in keys)
        {
                key.state = false;
           
        }
    }
    // Premade lists of keys
    static public List<KeyCode> Numeric()
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
    static public List<KeyCode> Keypad()
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
    static public List<KeyCode> Move()
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
    static public List<KeyCode> Mouse()
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
*/
public class Helper : MonoBehaviour
{


    public InputEventListener listener = new InputEventListener();
     
    void Start()
    {
        listener.listenTo(KeyCode.Keypad5,ChosenCallBack);
        Debug.Log("Listener" + listener);
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
