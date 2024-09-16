using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Vector3 _defaultScale;
    float _scaleFactor = 1.2f;
    float _speed = 2f;

    private void Awake()
    {
       _defaultScale = transform.localScale;
    }
    void Update()
    {
        float scaleOffset = Mathf.Sin(Time.time * Mathf.PI / _speed) * (_scaleFactor - 1);
        transform.localScale = _defaultScale * (1 + scaleOffset);    
    }
}
