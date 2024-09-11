using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _followTarget;
    [SerializeField] Vector3 _cameraOffset;

    void Start()
    {
        _cameraOffset = Camera.main.transform.position;
    }

    void Update()
    {
        transform.position = _followTarget.position + _cameraOffset;
    }
}
