using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    Player driver;
    public virtual string info { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        info = "Avatar";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void printInfo()
    {
        Debug.Log(info);
    }
        
    
}
