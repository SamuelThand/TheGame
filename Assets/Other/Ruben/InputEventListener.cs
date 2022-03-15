using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
namespace RMInputEventListener
{

    public class InputEventListener : MonoBehaviour
    {
        public List<Key> keys = new List<Key>();
        private Dictionary<string, List<Key>> groups = new Dictionary<string, List<Key>>();
        public List<KeyCode> keyList;
        public List<bool> boolList;
        static public InputEventListener MTListener;
        void start()
        {
            groups.Add("All", new List<Key>());
            MTListener = this;
        }
        public void listenToGroup()
        {

        }
        public void listenTo(KeyCode keyCode, Action<KeyCode> callback)
        {
            Key key = new Key(keyCode);
            key.callback = callback;
            keys.Add(key);
        }
        public void listenTo(KeyCode keyCode, Action<KeyCode> callback, Func<KeyCode, bool> call)
        {
            Key key = new Key(keyCode, call);
            key.callback = callback;
            keys.Add(key);
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


        void Update()
        {
            scan();
        }
        void FixedUpdate()
        {
            foreach (Key key in keys)
            {
                if (key.state)
                {
                    key.callback(key.code);
                }
            }
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
