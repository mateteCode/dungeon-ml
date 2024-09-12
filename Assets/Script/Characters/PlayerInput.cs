using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Direction {  get; private set; }
    public bool Defense { get; private set; }
    public event Action OnFire;

    private void Update()
    {
        GetInteractInput();
        GetMovementInput();
    }

    void GetMovementInput()
    {
        Direction = new Vector2(Input.GetAxis("Horizontal") * -1, Input.GetAxis("Vertical") * -1);
        Direction.Normalize();
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Direction *= 1.5f;
        }
    }

    void GetInteractInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnFire?.Invoke();
        }
        Defense = Input.GetKey(KeyCode.LeftControl);
    }



}
