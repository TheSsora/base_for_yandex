using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private new Transform camera;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraOffset;

    private void OnValidate()
    {
        cameraOffset = camera.position;
    }

    private void Update()
    {
        camera.position = player.position + cameraOffset;
    }
}
