using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMInputEventListener
{

    public class Key
    {
        public KeyCode code;
        public bool state;
        public Func<KeyCode, bool> func;
        public Action<KeyCode> callback;
        public Key(KeyCode c)
        {
            code = c;
            state = false;
            func = Input.GetKey;
        }
        public Key(KeyCode c, Func<KeyCode, bool> f)
        {
            code = c;
            state = false;
            func = f;
        }

    }
    public class InputEventListenerScanner : MonoBehaviour
    {
        public List<Key> keys;
        public bool isScanning = true;
        public List<KeyCode> keyList;
        public List<bool> boolList;
        string name;
        private void Start()
        {
            name = "scanner";
            keys   = InputEventListener.MTListener.keys;
            //keys = new List<Key>();
            keyList  = new List<KeyCode>();  
            boolList = new List<bool>();    
        }
        private void Update()
        {
            if (isScanning)
            {
                Debug.Log("Scanning");
                scan();
            }

        }
        
        public void scan()
        {
            foreach (Key key in InputEventListener.MTListener.keys)
            {
                bool result = key.func(key.code);
                Debug.Log("Checking:" + key.code + ":" + key.func(key.code));
                if (result)
                {
                    key.state = true;
                    Debug.Log("You pressed: " + key.code.ToString());
                }
            }
        }
        public void Howl()
        {
            Debug.Log("I am a scanner:" + name);
        }
    }

    public class InputEventListener
    {
        public List<Key> keys;
        private Dictionary<string, List<Key>> groups = new Dictionary<string, List<Key>>();
        
        public InputEventListenerScanner scanner;
        static public InputEventListener MTListener;
        //
        public List<KeyCode> keyList = new List<KeyCode>();  
        public List<bool> boolList = new List<bool>(); 
        public InputEventListener()
        {
            
            keys = new List<Key>();
            groups.Add("All", new List<Key>());
            MTListener = this;
        }
        
        public void listenTo(KeyCode keyCode, Action<KeyCode> callback)
        {
            Debug.Log("Listen to:" + keyCode);
            Key key = new Key(keyCode);
            key.callback = callback;
            keys.Add(key);
            Debug.Log("Key added. Singleton key count" + InputEventListener.MTListener.keys.Count);
            KeyDisplay();
        }
        
        
        public void Clear()
        {
            foreach (Key key in keys)
            {
                if (key.state)
                {
                    key.callback(key.code);
                }
            }
        }
        public void KeyDisplay()
        {
            keyList.Clear();
            boolList.Clear();
            foreach (Key key in keys)
            {
                keyList.Add(key.code);
                boolList.Add(key.state);
            }
        }
        static public void ActivateMTListener()
        {
            InputEventListener.MTListener = new InputEventListener();
            //InputEventListener.MTListener.scanner.isScanning = true;
        }
        public void Howl()
        {
            Debug.Log("Im alive:" + this.keys.Count);
        }
        /*
         * 
         *
         */

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
}
