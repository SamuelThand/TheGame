using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;


public class EstateMakerPro : MonoBehaviour
{
    enum Heading { NW, NE , SW, SE}
    [SerializeReference] private GameObject[] cornerShops;
    [SerializeReference] private GameObject[] shops;
    [SerializeReference] private GameObject[] fillers;
    [SerializeReference] private GameObject[] cornerApartments;
    [SerializeReference] private GameObject[] apartments;
    [SerializeField] private int stories;
    private GameObject[] fronts;
    public bool update;
    public int width;
    public int depth;
    //[SerializeReference] Transform footPrint;

    GameObject target;


    float floorHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        floorHeight = 0;
        fronts = shops.Concat<GameObject>(fillers).ToArray<GameObject>();
        //positionFootprint();
        GameObject[] shopFloor =  PlaceCornersFromCollection(cornerShops);

        placeSide(shopFloor[(int)Heading.NW], shopFloor[(int)Heading.SW], fronts);
        placeSide(shopFloor[(int)Heading.NE], shopFloor[(int)Heading.NW], fronts);
        placeSide(shopFloor[(int)Heading.SW], shopFloor[(int)Heading.SE], fronts);
        placeSide(shopFloor[(int)Heading.SE], shopFloor[(int)Heading.NE], fronts);

        floorHeight = 4;

        for(int i = 0; i < stories; i++)
        {
            GameObject[] aFloor = PlaceCornersFromCollection(cornerApartments);
            placeSide(aFloor[(int)Heading.NW], aFloor[(int)Heading.SW],apartments);
            placeSide(aFloor[(int)Heading.NE], aFloor[(int)Heading.NW],apartments);
            placeSide(aFloor[(int)Heading.SW], aFloor[(int)Heading.SE],apartments);
            placeSide(aFloor[(int)Heading.SE], aFloor[(int)Heading.NE],apartments);
            floorHeight += 2.5f;
        }
       
        //placeSide((int)Heading.NW, Heading.SW);
        //placeSide((int)Heading.NE, Heading.NW);

        //placeSide((int)Heading.SW, Heading.SE);
        //placeSide((int)Heading.SE, Heading.NE);

        //GetCorners();

    }

    // Update is called once per frame
    void Update()
    {
        //pFillers = AssetDatabase.LoadAllAssetsAtPath("Assets/Prefabs/Houses/EstateMakerPro/templates/Fillers/*");
        //pCorners = AssetDatabase.LoadAllAssetsAtPath("Assets/Prefabs/Houses/EstateMakerPro/templates/Corners/*");
        // = AssetDatabase.LoadAllAssetsAtPath("Assets/Prefabs/Houses/EstateMakerPro/templates/Stores/*");
        //Debug.Log("pFillers:" + pFillers.Length);
    }
    private void OnValidate()
    {
        

    }
    private void Awake()
    {
        
    }

    private void positionFootprint()
    {
        //footPrint.transform.Translate(width / 2, 0, depth / 2); 
        //footPrint.transform.localScale = new Vector3(width,0.05f,depth);
        
    }

    private GameObject GetRandomCornerFromCollection(GameObject[] collection)
    {
        int rand = Random.Range(0, collection.Length);

        return Instantiate(collection[rand],this.transform);
    }
    private void placeSide(GameObject start,GameObject end, GameObject[] collection)
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
                int rand = Random.Range(0, collection.Length);
                Debug.Log("rand:" + rand);
                if((int)Mathf.Round(collection[rand].GetComponent<Renderer>().bounds.size.x) <= remainder)
                {
                    int shopSize = (int)(collection[rand].GetComponent<Renderer>().bounds.size.x);
                    GameObject aShop = Instantiate(collection[rand],preShop.transform.position,preShop.transform.rotation,preShop.transform);
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
    private GameObject[] PlaceCornersFromCollection(GameObject[] collection)
    {
        
        GameObject nw;
        GameObject ne;
        GameObject sw;
        GameObject se;
        
        nw = GetRandomCornerFromCollection(collection);
        nw.name = "NorthWest";
        ne = GetRandomCornerFromCollection(collection);
        ne.name = "NorthEast";
        sw = GetRandomCornerFromCollection(collection);
        sw.name = "SouthWest";
        se = GetRandomCornerFromCollection(collection);
        se.name = "SouthEast";

        int nwWidth = (int)Mathf.Round(nw.GetComponent<Renderer>().bounds.size.x);
        int nwDepth = (int)Mathf.Round(nw.GetComponent<Renderer>().bounds.size.y);

        int neWidth = (int)Mathf.Round(ne.GetComponent<Renderer>().bounds.size.x);
        int neDepth = (int)Mathf.Round(ne.GetComponent<Renderer>().bounds.size.y);

        int swWidth = (int)Mathf.Round(sw.GetComponent<Renderer>().bounds.size.x);
        int swDepth = (int)Mathf.Round(sw.GetComponent<Renderer>().bounds.size.y);

        int seWidth = (int)Mathf.Round(se.GetComponent<Renderer>().bounds.size.x);
        int seDepth = (int)Mathf.Round(se.GetComponent<Renderer>().bounds.size.y);

        nw.transform.position = new Vector3(0, floorHeight, depth);
        nw.transform.Rotate(0, -90, 0);

        ne.transform.position = new Vector3(width, floorHeight, depth);
        ne.transform.Rotate(0, 0, 0);

        sw.transform.position = new Vector3(0, floorHeight, 0);
        sw.transform.Rotate(0, 180, 0);

        se.transform.position = new Vector3(width, floorHeight, 0);
        se.transform.Rotate(0, 90, 0);

        GameObject[] ret = new GameObject[4];
        ret[(int)Heading.NW] = nw;
        ret[(int)Heading.NE] = ne;
        ret[(int)Heading.SW] = sw;
        ret[(int)Heading.SE] = se;
        
        return ret;
    }
}
/*
 * Openings should have same texture as adjecent building
 * Not adding same module twice
 * Not adding same "type" twice
 * 
 * 
 */