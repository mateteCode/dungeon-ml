using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] Transform _followTarget;
    //GameObject _target;
    public GameObject Target { get; set; }
    [SerializeField] Vector3 _cameraOffset;
    [SerializeField] float _smoothTime = 0.3f;
    Vector3 _velocity = Vector3.zero;

    void Start()
    {
        _cameraOffset = Camera.main.transform.position;
        //_cameraOffset = Camera.main.transform.position - transform.position;
    }

    void Update()
    {
        if (Target != null)
        {
            //transform.position = _target.transform.position + _cameraOffset;
            Vector3 targetPosition = Target.transform.position + _cameraOffset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }
        //else TargetToPlayer();
    }

    private void OnEnable()
    {
        //GameManager.Instance.OnShowed += TargetToPlayer;
    }


    private void TargetToPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Target = player;
    }
}
