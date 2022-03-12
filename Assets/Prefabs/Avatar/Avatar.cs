using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{

    // Attributes
    [Min(0)] public float weight = 1;
    [Min(0)] public float topSpeed = 1;


    [SerializeReference] public Transform cameraPoint;

    public PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        // Sets reference to avatar
        player.avatar = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

// GameObject obj = Instantiate(bullet) as GameObject;
