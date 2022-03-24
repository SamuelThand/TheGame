using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class EstateMakerPro : MonoBehaviour
{
    [SerializeReference] private GameObject[] cornerShops;
    [SerializeReference] private GameObject[] shops;
    [SerializeReference] private GameObject[] fillers;
    public bool update;
    public int width;
    public int depth;
    [SerializeReference] Transform footPrint;

    GameObject nw;
    GameObject ne;
    GameObject sw;
    GameObject se;


    // Start is called before the first frame update
    void Start()
    {
        positionFootprint();
        PlaceCornerShops();
        
     
        //GetCorners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnValidate()
    {
        
    }
    private void positionFootprint()
    {
        footPrint.transform.Translate(width / 2, 0, depth / 2); 
        footPrint.transform.localScale = new Vector3(width,0.05f,depth);
        
    }
    private GameObject GetRandomCornerShop()
    {
        int rand = (int)Random.Range(0f,cornerShops.Length);
        return Instantiate(cornerShops[3],this.transform);
    }
    private void PlaceCornerShops()
    {
        GameObject nw = GetRandomCornerShop();
        nw.name = "NorthWest";
        GameObject ne = GetRandomCornerShop();
        ne.name = "NorthEast";
        GameObject sw = GetRandomCornerShop();
        sw.name = "SouthWest";
        GameObject se = GetRandomCornerShop();
        se.name = "SouthEast";

        int nwWidth = (int)Mathf.Round(nw.GetComponent<Renderer>().bounds.size.x);
        int nwDepth = (int)Mathf.Round(nw.GetComponent<Renderer>().bounds.size.y);

        int neWidth = (int)Mathf.Round(ne.GetComponent<Renderer>().bounds.size.x);
        int neDepth = (int)Mathf.Round(ne.GetComponent<Renderer>().bounds.size.y);

        int swWidth = (int)Mathf.Round(sw.GetComponent<Renderer>().bounds.size.x);
        int swDepth = (int)Mathf.Round(sw.GetComponent<Renderer>().bounds.size.y);

        int seWidth = (int)Mathf.Round(se.GetComponent<Renderer>().bounds.size.x);
        int seDepth = (int)Mathf.Round(se.GetComponent<Renderer>().bounds.size.y);

        nw.transform.position = new Vector3(0+nwDepth, 0, depth-nwWidth);
        nw.transform.Rotate(0, -90, 0);

        ne.transform.position = new Vector3(width-neWidth, 0, depth-neDepth);
        ne.transform.Rotate(0, 0, 0);

        sw.transform.position = new Vector3(0+swWidth, 0, 0+swDepth);
        sw.transform.Rotate(0, 180, 0);

        se.transform.position = new Vector3(width-seDepth, 0, 0+seWidth);
        se.transform.Rotate(0, 90, 0);


    }
}
