using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabCorrector : MonoBehaviour
{
    public List<GameObject> objectList = new List<GameObject>();
    public GameObject prefab;

    [Header("SETTINGS")]
    public bool keepMaterial;

   public void CorrectPrefabs()
    {
        // Iterate every selected gameobject in hierarchy.
        foreach (GameObject go in objectList)
        {
            Transform _transformData = go.transform;
            
            Object _prefab = PrefabUtility.InstantiatePrefab(prefab as GameObject);
            GameObject goPrefab = _prefab as GameObject;
            
            // Get all transform values of existing object and set it to instanced prefab.
            goPrefab.transform.parent = go.transform.parent;
            goPrefab.transform.position = _transformData.position;
            goPrefab.transform.rotation = _transformData.rotation;
            goPrefab.transform.localScale = _transformData.localScale;

            if(keepMaterial)
                goPrefab.GetComponent<MeshRenderer>().sharedMaterial = _transformData.GetComponent<MeshRenderer>().sharedMaterial; // Get scene object's material and set it to prefab.
            
            // Remove old object.
            DestroyImmediate(go);
            _prefab.name = prefab.name;
        }
    }
}
