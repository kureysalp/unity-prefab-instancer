using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PrefabCorrector))]
public class PrefabCorrectorInspector : Editor
{


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PrefabCorrector _prefab = (PrefabCorrector)target;

        if (GUILayout.Button("Correct"))
        {
            _prefab.CorrectPrefabs();
        }
    }



}
