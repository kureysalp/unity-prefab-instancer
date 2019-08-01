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
            Debug.Log("za");
            Transform _transformData = go.transform;
            Object _prefab = PrefabUtility.InstantiatePrefab(prefab as GameObject);
            GameObject goPrefab = _prefab as GameObject;
            goPrefab.transform.parent = go.transform.parent;
            goPrefab.transform.position = _transformData.position;
            goPrefab.transform.rotation = _transformData.rotation;
            goPrefab.transform.localScale = _transformData.localScale;
            DestroyImmediate(go);
            _prefab.name = prefab.name;
        }
    }
}
