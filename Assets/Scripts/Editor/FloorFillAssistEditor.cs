using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FloorFillAssist))]
public class FloorFillAssistEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FloorFillAssist script = (FloorFillAssist)target;
        
        if (GUILayout.Button("Создать"))
        {
            script.Create();
        }
        if (GUILayout.Button("Очистить"))
        {
            script.Clear();
        }
    }
}
