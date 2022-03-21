using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Refs
    public Avatar shooter;
    // Sound

    // Attributes
    public float damage;
    public float piercing;
    public float velocity;                          //853
    public float mass;                              //0.010

    [SerializeReference] public Light glow;
    [SerializeReference] public TrailRenderer trail;
    [SerializeReference] public Color color;


    private void DeleteMe()
    {
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        glow.color = color;
        trail.startColor = color;
        trail.endColor = new Color(1.0f, 1.0f, 1.0f,0.0f);
        Invoke("DeleteMe", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        
            color = new Color(0.0f, 0.0f, 1.0f,1.0f);
            //GetComponent<Rigidbody>().velocity *= 0.2f; 
            Debug.Log("Collision");
        
    }
}
