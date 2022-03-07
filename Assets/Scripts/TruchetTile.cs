using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruchetTile : MonoBehaviour
{
    [SerializeField] Texture T01;
    [SerializeField] Texture T02;
    [SerializeField] Texture T03;
    [SerializeField] Texture T04;
    //

    // Start is called before the first frame update
    void Start()
    {
        Texture[] textures = { T01, T02, T03, T04};
        Texture tex = textures[Random.Range(0, 4)];

        //string filename = "TruchetTile0" + "3.png"; //Random.Range(1, 5);

        //Texture tex = Resources.Load("Textures/" + filename) as Texture;
        Renderer ren = GetComponent<Renderer>();
        ren.material.mainTexture = tex;
        //ren.material.SetTexture("Albedo", tex);
        //Debug.Log(filename);
        //Debug.Log(cur_t.ToString());
        //Texture tex = Resources.Load(filename, typeof(Texture)) as Texture;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
