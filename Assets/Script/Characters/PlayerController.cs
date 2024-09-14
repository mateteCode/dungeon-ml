using System.Collections;
using System.Collections.Generic;
using SVS;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    Animator _anim;
    PlayerMovement _playerMovement;
    PlayerInput _playerInput;
    PlayerAttack _playerAttack;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.OnFire += () => _playerAttack.Attack();
    }

    void Update()
    {        
        //Control de Animaciones
        _anim.SetFloat("WalkVelocity", _playerInput.Direction.magnitude, 0.05f, Time.deltaTime);
        _anim.SetBool("Defense", _playerInput.Defense);

        // Movement
         _playerMovement.Move(_playerInput.Direction, _playerInput.Run);
    }

}
