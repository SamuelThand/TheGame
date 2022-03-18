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
    

    public class InputEventListener
    {
        public List<Key> keys;
        private Dictionary<string, List<Key>> groups = new Dictionary<string, List<Key>>();
        
        
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
       
        
    }
}
