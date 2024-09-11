using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    Transform _player;
    public void Damage(int damageAmount)
    {
        // TODO: Sacar vida y generar muerte. Agregar animaciones. Es necesario refactorizar?
        Debug.Log("Get Some Damage, But not too much");
    }

    private void Start()
    {
        _player = GameObject.FindWithTag("Player")?.transform;
    }

    private void Update()
    {
        if(_player)
        {
            transform.LookAt(_player.position);
        }
    }


}
