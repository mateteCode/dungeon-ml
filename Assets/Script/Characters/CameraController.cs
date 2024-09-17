using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    //[SerializeField] Transform _followTarget;
    //GameObject _target;
    public GameObject Target { get; set; }
    [SerializeField] Vector3 _cameraOffset = new Vector3(0, 40, 9);
    [SerializeField] float _smoothTime = 0.3f;
    Vector3 _velocity = Vector3.zero;

    public float smoothTime = 0.3f; // El tiempo para suavizar la rotación
    private Vector3 angularVelocity = Vector3.zero; // Almacenamos la velocidad angular

    Vector3 _targetRotation;

    void Start()
    {
        //_cameraOffset = Camera.main.transform.position;
        //_cameraOffset = Camera.main.transform.position - transform.position;
        _targetRotation = new Vector3(90, -180, 0);
    }

    void Update()
    {
        if (Target != null)
        {
            //transform.position = _target.transform.position + _cameraOffset;
            Vector3 targetPosition = Target.transform.position + _cameraOffset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);

            Vector3 currentRotation = transform.eulerAngles;
            // Aplicar SmoothDamp a la rotación en cada eje
            float smoothX = Mathf.SmoothDampAngle(currentRotation.x, _targetRotation.x, ref angularVelocity.x, smoothTime);
            float smoothY = Mathf.SmoothDampAngle(currentRotation.y, _targetRotation.y, ref angularVelocity.y, smoothTime);
            float smoothZ = Mathf.SmoothDampAngle(currentRotation.z, _targetRotation.z, ref angularVelocity.z, smoothTime);

            // Actualizar la rotación del objeto
            transform.rotation = Quaternion.Euler(smoothX, smoothY, smoothZ);
        }
        //else TargetToPlayer();
    }

    private void OnEnable()
    {
        //GameManager.Instance.OnShowed += TargetToPlayer;
    }


    public void TargetToPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Target = player;
        _cameraOffset = new Vector3(0, 10, 9);
        _targetRotation = new Vector3(40, -180, 0);
    }

    public void TargetToMaze()
    {
        GameObject centerOfMaze = GameObject.FindWithTag("CenterOfMaze");
        Target = centerOfMaze;
        _cameraOffset = new Vector3(0, 40, 9);
        _targetRotation = new Vector3(90, -180, 0);
        
    }


}
