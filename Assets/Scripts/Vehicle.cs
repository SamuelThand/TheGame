using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    
    string vehicleClass;
    string vehicleModel;
    string displayName;
    int armorPoints;
    int healthPoints;
    int damagePoints;

    float damageMultiPlyer;
    
    // Start is called before the first frame update
    void Start()
    {
        damageMultiPlyer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
