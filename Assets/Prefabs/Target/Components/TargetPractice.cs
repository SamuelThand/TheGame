using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    enum Diff { ridiculous, easy, normal, hard, impossible };
    // Refs
    [SerializeReference] GameObject target;

    // Inputs
    [SerializeField] int points = 100;
    [SerializeField] Diff difficulty = Diff.normal;
    [SerializeField] bool pointsForDistance;

    private Renderer renderer;

    // 
    private float[] scales = { 3.0f, 2.0f, 1.0f, 0.5f, 0.25f };
    private Color[] colors = { new Color(0.0f, 1.0f, 0.0f), new Color(0.6f, 1.0f, 0.3f), new Color(0.5f, 0.5f, 0.0f), new Color(0.5f, 0.25f, 0.0f), new Color(1.0f, 0.0f, 0.0f) };
    

    void Start()
    {
        target.transform.localScale = Vector3.one * 1 * scales[(int)difficulty];
        renderer = target.GetComponent<Renderer>();
        renderer.material.SetColor("_Color",colors[(int)difficulty]);
        //renderer.GetComponent<Material>().color = color;
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
