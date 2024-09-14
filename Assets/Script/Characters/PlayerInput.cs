using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Direction {  get; private set; }
    public bool Run { get; private set; }
    public bool Defense { get; private set; }
    public event Action OnFire;

    private void Update()
    {
        GetMovementInput();
        GetInteractInput();
    }

    void GetMovementInput()
    {
        Direction = new Vector2(Input.GetAxis("Horizontal") * -1, Input.GetAxis("Vertical") * -1);
        Direction.Normalize();

        Run = Input.GetKey(KeyCode.LeftShift);
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
