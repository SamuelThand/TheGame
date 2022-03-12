using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{

    [Header("Base:")]
    [Min(0)] public int weight = 1;
    [Min(0)] public int maxSpeed = 1;


    [SerializeField] Transform defaultCamera;
    [SerializeReference] public Transform cameraPoint;
    [SerializeReference] List<Transform> cameraPoints;
    [SerializeReference] List<string> cameraPointsNames;

    public PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        
        player.avatar = this;
        SetCameraByPoint(defaultCamera);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCameraByPoint(Transform point)
    {
        cameraPoint = point;
    }
    public Transform SetCameraByName(string cName)
    {
        int i = cameraPointsNames.IndexOf(cName);
        cameraPoint = cameraPoints[i];
        return cameraPoint;
    }
    
    public void Rotate(Vector3 v, float f)
    {

    }
    public void Translate(Vector3 v, float f)
    {

    }
}

// GameObject obj = Instantiate(bullet) as GameObject;
