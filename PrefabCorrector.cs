using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabCorrector : MonoBehaviour
{
    public List<GameObject> objectList = new List<GameObject>();
    public GameObject prefab;
    

   public void CorrectPrefabs()
    {
        foreach (GameObject go in objectList)
        {
            Transform _transformData = go.transform;
            
            Object _prefab = PrefabUtility.InstantiatePrefab(prefab as GameObject);
            GameObject goPrefab = _prefab as GameObject;
            
            // Get all transform values of existing object and set it to instanced prefeb.
            goPrefab.transform.parent = go.transform.parent;
            goPrefab.transform.position = _transformData.position;
            goPrefab.transform.rotation = _transformData.rotation;
            goPrefab.transform.localScale = _transformData.localScale;
            
            // Remove old object.
            DestroyImmediate(go);
            _prefab.name = prefab.name;
        }
    }
}
