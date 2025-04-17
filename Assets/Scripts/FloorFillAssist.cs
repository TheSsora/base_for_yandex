using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[ExecuteInEditMode]
public class FloorFillAssist : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private Transform parent;
    [SerializeField] private Vector3 zeroPosition;
    [SerializeField] private float x,z;

    public void Create()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                var floor = Instantiate(prefabs[Random.Range(0,prefabs.Count)], zeroPosition + new Vector3(i,0,j), Quaternion.identity, parent);
            }
        }
    }
    public void Clear()
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(parent.GetChild(i).gameObject);
        }
    }
}
