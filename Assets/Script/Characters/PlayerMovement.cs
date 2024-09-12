using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _characterSpeed = 4f;
    [SerializeField] private float _turnSmoothVelocity = 0.2f;
    CharacterController _character;
    float _gravity = -9.8f;
    float _velocity;
    float _turnSmoothTime;
    float _targetAngle;
    float _characterAngle;

    private void Start()
    {
        _character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //apply gravity so character can always be on floor
        if (!_character.isGrounded)
        {
            _velocity = _gravity * Time.deltaTime;

        }
        else
        {
            _velocity = 0f;
        }
    }

    public void Move(Vector2 direction)
    {
        if (direction.magnitude >= 0.1f)
        {
            _targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            _characterAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothTime, _turnSmoothVelocity);

            transform.rotation = Quaternion.Euler(0f, _characterAngle, 0f);
            Vector3 movement = new Vector3(direction.x, _velocity, direction.y);
            _character.SimpleMove(movement * _characterSpeed);
        }
    }
}
