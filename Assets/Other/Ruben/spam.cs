using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
