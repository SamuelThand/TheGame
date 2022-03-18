using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RMInputEventListener;
public class InputEventListenerScanner : MonoBehaviour
{
    
    public List<Key> keys;
    public bool isScanning = true;
    public List<KeyCode> keyList;
    public List<bool> boolList;
    string name;
    // Start is called before the first frame update
    void Start()
    {
        name = "scanner";
        keys = InputEventListener.MTListener.keys;
        //keys = new List<Key>();
        keyList = new List<KeyCode>();
        boolList = new List<bool>();
    }

    // Update is called once per frame
    void Update()
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
