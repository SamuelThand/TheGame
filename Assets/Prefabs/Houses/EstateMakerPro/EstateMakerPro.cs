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
        placeSide(nw,0);
        //placeSide(ne,180);
        //placeSide(sw,-90);
        //placeSide(se,90);
     
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
        int rand = Random.Range(0,cornerShops.Length);
        //Debug.Log("random = " + rand);
        return Instantiate(cornerShops[3],this.transform);
    }
    private void placeSide(GameObject starter,int rot)
    {
        int constructed = 0;
        int remainder = northSide-constructed;
        int offset = 0;
        int rand = 0;
        GameObject preShop = starter;
        Debug.Log("Mini:" + fillers[2].GetComponent<Renderer>().bounds.size.x);
        int limit = 0;
        while (limit < 1)
        {
            offset = (int)preShop.GetComponent<Renderer>().bounds.size.x;
            bool fits = false;
            
            while (!fits)
            {
                rand = Random.Range(0, fronts.Length);
                
                if((int)Mathf.Round(fronts[rand].GetComponent<Renderer>().bounds.size.x) <= remainder)
                {
                    GameObject aShop = Instantiate(fronts[rand],preShop.transform);
                    
                    aShop.transform.position = new Vector3(preShop.transform.position.x + offset, preShop.transform.position.y, preShop.transform.position.z);
                    //aShop.transform.Rotate(new Vector3(0,rot,0));
                    constructed += (int)aShop.GetComponent<Renderer>().bounds.size.x;
                    fits = true;
                    preShop = aShop;
                    remainder = northSide-constructed;
                    Debug.Log("Remainin:" + remainder);
                
                }
            }
            limit++;
        }
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

        northSide = (int)(ne.transform.position.x - nw.transform.position.x) - nwDepth - neWidth;
        //northSide = (int)(ne.transform.position.x - nw.transform.position.x);
        //northSide = (int)(ne.transform.position.x - nw.transform.position.x);
        //northSide = (int)(ne.transform.position.x - nw.transform.position.x);
        Debug.Log("North side:" + northSide);
    }
}
