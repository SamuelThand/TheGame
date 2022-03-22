using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmeniaDrive : MonoBehaviour
{
    [SerializeReference] private GameObject area;
    [SerializeField] private GameObject adFoundation;
    [SerializeField] private GameObject adBase;
    [SerializeField] private GameObject adFloor;
    [SerializeField] private GameObject adTopFloor;
    [SerializeField] private GameObject adRoof;

    public int stories;
    private float floorHeight = 2.6f;
    private float visibleFoundation = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(area);
        BuildEstate();

    }
    private void BuildEstate()
    {
        GameObject f = Instantiate(adFoundation,this.transform);
        f.transform.Translate(Vector3.up * visibleFoundation);

        GameObject b = Instantiate(adBase,this.transform);
        b.transform.Translate(Vector3.up * visibleFoundation);

        for(int i = 0; i < stories; i++)
        {
            GameObject fl = Instantiate(adFloor,this.transform);
            
            fl.transform.Translate((Vector3.up * visibleFoundation)+(Vector3.up * floorHeight)+ (Vector3.up * floorHeight * i));
        }

        //GameObject f = Instantiate(adTopFloor,this.transform);
        //GameObject f = Instantiate(adRoof,this.transform);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
