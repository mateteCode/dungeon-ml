using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] Transform _followTarget;
    GameObject _target;
    [SerializeField] Vector3 _cameraOffset;

    void Start()
    {
        _cameraOffset = Camera.main.transform.position;
    }

    void Update()
    {
        //transform.position = _followTarget.position + _cameraOffset;
        if (_target != null)
        {
            transform.position = _target.transform.position + _cameraOffset;
        }
        else TargetToPlayer();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnPlayerShowed += TargetToPlayer;
    }


    private void TargetToPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        _target = player;
    }
}
