using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMKey
{
    public KeyCode code;
    public bool state;
    public Func<KeyCode, bool> func;
    public Action<KeyCode> callback;
    public RMKey(KeyCode c)
    {
        code = c;
        state = false;
        func = Input.GetKey;
    }
    public RMKey(KeyCode c, Func<KeyCode, bool> f)
    {
        code = c;
        state = false;
        func = f;
    }

}
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
public class RMKeyManager
{
    public List<RMKey> keys;
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
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
public class RMInputScanner : MonoBehaviour
{
    private List<RMKey> keys;
    public bool listening = false;
    private void Start()
    {
        keys = RMListener.listener.keyManager.keys;
    }
    private void Update()
    {
        if (listening)
        {
            //Iterate keys
        }   
    }
    static public RMInputScanner GetScanner()
    {
        
        return new RMInputScanner();
    }
}
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
public class RMListener
{
    static public RMListener listener;
    public RMInputScanner scanner;
    public RMKeyManager keyManager;
    public RMListener()
    {
        keyManager = new RMKeyManager();
        scanner = RMInputScanner.GetScanner();
    }
    static public void Listen(bool state)
    {
        RMListener.listener = new RMListener();
    }
    public void Howl()
    {
        Debug.Log("I am RMListener");

    }
}
