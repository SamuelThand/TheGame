using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Refs
    // Sound

    // Attributes
    public float damage;
    public float piercing;
    public float velocity;
    public float mass;


    private void DeleteMe()
    {
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleteMe", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
