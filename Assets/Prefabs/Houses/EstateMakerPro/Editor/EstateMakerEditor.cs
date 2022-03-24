using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class EstateMakerEditor : EditorWindow
{
    Object currentTarget;
    int stories;
    int width;
    int depth;

    [MenuItem("MadTooth/Estate Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(EstateMakerEditor));
    }
    private void OnGUI()
    {
        currentTarget = Selection.activeGameObject;
        //GUILayout.Label("Estate Editor", EditorStyles.boldLabel);
        GUILayout.Label(currentTarget.name, EditorStyles.boldLabel);
        stories = EditorGUILayout.IntSlider("Stories", stories, 0, 100);
        width = EditorGUILayout.IntField("Width", width);
        depth = EditorGUILayout.IntField("Depth", depth);
        currentTarget = EditorGUILayout.ObjectField("Current", currentTarget, typeof(GameObject), false);

        if (GUILayout.Button("Update"))
        {
            UpdateEstate();
        }
    }
    private void UpdateEstate()
    {
        if(currentTarget == null)
        {
            Debug.LogError("No current target");
            return;
        }

        Object estate = Instantiate(currentTarget);
    }
}
