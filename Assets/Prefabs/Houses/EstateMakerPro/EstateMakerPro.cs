using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;


public class EstateMakerPro : MonoBehaviour
{
    enum Heading { north, south , west, east}
    [SerializeReference] private GameObject[] cornerShops;
    [SerializeReference] private GameObject[] shops;
    [SerializeReference] private GameObject[] fillers;
    private GameObject[] fronts;
    public bool update;
    public int width;
    public int depth;
    [SerializeReference] Transform footPrint;

    GameObject target;

    GameObject nw;
    GameObject ne;
    GameObject sw;
    GameObject se;

    int northSide;
    int southSide;
    int westSide;
    int eastSide;
    // Start is called before the first frame update
    void Start()
    {
        fronts = shops.Concat<GameObject>(fillers).ToArray<GameObject>();
        positionFootprint();
        PlaceCornerShops();
        
        placeSide(nw,sw);
        placeSide(ne,nw);
        
        placeSide(sw,se);
        placeSide(se,ne);
     
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
        int rand = Random.Range(0, cornerShops.Length);

        return Instantiate(cornerShops[rand],this.transform);
    }
    private void placeSide(GameObject start,GameObject end)
    {
        float xSize = (end.transform.position.x - start.transform.position.x);
        float zSize = (end.transform.position.z - start.transform.position.z);
        float sSize = (end.GetComponent<Renderer>().bounds.size.x + start.GetComponent<Renderer>().bounds.size.x);
        int remainder = (int)Mathf.Round(Mathf.Abs(xSize + zSize) - sSize);
        
        
        GameObject preShop = start;
        
        int limit = 0;
        int offset = (int)start.GetComponent<MeshFilter>().mesh.bounds.size.x;
        while (remainder > 0)
        {
            
            bool fits = false;
            
            while (!fits)
            {
                int rand = Random.Range(0, fronts.Length);
                
                if((int)Mathf.Round(fronts[rand].GetComponent<Renderer>().bounds.size.x) <= remainder)
                {
                    int shopSize = (int)(fronts[rand].GetComponent<Renderer>().bounds.size.x);
                    GameObject aShop = Instantiate(fronts[rand],preShop.transform.position,preShop.transform.rotation,preShop.transform);
                    aShop.transform.Translate(Vector3.left * (shopSize));
                    
                    fits = true;
                    preShop = aShop;
                    remainder -= shopSize;
                    
                
                }
            }
            limit++;
        }
        start.transform.GetChild(0).transform.Translate(Vector3.left * offset);
    }
    private void PlaceCornerShops()
    {
        nw = GetRandomCornerShop();
        nw.name = "NorthWest";
        ne = GetRandomCornerShop();
        ne.name = "NorthEast";
        sw = GetRandomCornerShop();
        sw.name = "SouthWest";
        se = GetRandomCornerShop();
        se.name = "SouthEast";

        int nwWidth = (int)Mathf.Round(nw.GetComponent<Renderer>().bounds.size.x);
        int nwDepth = (int)Mathf.Round(nw.GetComponent<Renderer>().bounds.size.y);

        int neWidth = (int)Mathf.Round(ne.GetComponent<Renderer>().bounds.size.x);
        int neDepth = (int)Mathf.Round(ne.GetComponent<Renderer>().bounds.size.y);

        int swWidth = (int)Mathf.Round(sw.GetComponent<Renderer>().bounds.size.x);
        int swDepth = (int)Mathf.Round(sw.GetComponent<Renderer>().bounds.size.y);

        int seWidth = (int)Mathf.Round(se.GetComponent<Renderer>().bounds.size.x);
        int seDepth = (int)Mathf.Round(se.GetComponent<Renderer>().bounds.size.y);

        nw.transform.position = new Vector3(0, 0, depth);
        nw.transform.Rotate(0, -90, 0);

        ne.transform.position = new Vector3(width, 0, depth);
        ne.transform.Rotate(0, 0, 0);

        sw.transform.position = new Vector3(0, 0, 0);
        sw.transform.Rotate(0, 180, 0);

        se.transform.position = new Vector3(width, 0, 0);
        se.transform.Rotate(0, 90, 0);

        
        
    }
}
/*
 * Openings should have same texture as adjecent building
 * Not adding same module twice
 * Not adding same "type" twice
 * 
 * 
 */