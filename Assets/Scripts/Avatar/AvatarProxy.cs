using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AvatarProxy : Avatar
{
    private string _info;
    public override string info
    {
        get { return _info; }
        set { _info = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        info = "Proxy";
    }

    protected override void printInfo()
    {
        Debug.Log("<" + info);
        base.printInfo();
    }    
}
