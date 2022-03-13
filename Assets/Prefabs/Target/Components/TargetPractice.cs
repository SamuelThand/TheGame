using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    enum Diff { hard,medium,easy};
    // Refs
    [SerializeReference] GameObject target;
    // Inputs
    [SerializeField] int reward = 100;
    [SerializeField] float difficulty = 1;
    [SerializeField] bool includeDistanceInReward;

    //
    
    Color color;


    void Start()
    {
        
        //color = target.GetComponent<Material>().color;
        //color.g = 1f;
        //target.GetComponent<Material>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Epic Explosion
        Debug.Log("I exploded!");
        

    }
}
