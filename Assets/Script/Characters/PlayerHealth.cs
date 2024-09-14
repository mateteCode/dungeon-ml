using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    [SerializeField] int _health;

    public event Action OnDie;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyController>();
        if(enemy != null)
        {
            //TakeDamage(enemy.Damage);
        }
    }

    void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0) OnDie?.Invoke();
    }

}
