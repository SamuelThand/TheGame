using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Vehicle : Avatar
{
    // Refs
    [Header("Vehicle")]
    public Color paint;
    [SerializeReference] public Transform secondaryWeaponPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
