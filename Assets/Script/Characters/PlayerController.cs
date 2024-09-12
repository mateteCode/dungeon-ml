using System.Collections;
using System.Collections.Generic;
using SVS;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    Animator _anim;
    Vector2 _direction;
    PlayerMovement _playerMovement;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {        
        //Input Keyboard
        _direction.x = Input.GetAxis("Horizontal") * -1;
        _direction.y = Input.GetAxis("Vertical") * -1;
        _direction = _direction.normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _direction *= 1.5f;
        }

        //Control de Animaciones
        _anim.SetFloat("WalkVelocity",_direction.magnitude, 0.05f, Time.deltaTime);

        // Movement
        _playerMovement.Move(_direction);
    }

}
