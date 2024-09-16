using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator _anim;
    Camera _mainCamera;
   
    List<IDamagable> _damagablesInRange;
    [SerializeField] LayerMask _layerMask;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _damagablesInRange = new List<IDamagable>();
        _mainCamera = Camera.main;
    }

    void SimpleAttack(Vector3 toLook)
    {   
        if(_damagablesInRange.Count >= 1)
        {
            this.transform.LookAt(toLook);
            _damagablesInRange[0].Damage(10);
            _anim.SetTrigger("SimpleAttack");
        }
    }

    void StrongAttack()
    {
        _anim.SetTrigger("StrongAttack");
    }

    private void OnTriggerEnter(Collider other) 
    {
        var damagable = other.GetComponent<IDamagable>();

        if(damagable != null)
        {
            _damagablesInRange?.Add(damagable);
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        var damagable = other.GetComponent<IDamagable>();

        if(damagable != null && _damagablesInRange.Contains(damagable))
        {
            _damagablesInRange?.Remove(damagable);
        }    
    }

    public void Attack()
    {
        Ray _ray;
        RaycastHit _hit;
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit, 20, _layerMask))
        {
            var damagable = _hit.transform.GetComponent<IDamagable>();
            if (damagable != null)
            {
                SimpleAttack(_hit.transform.position);
            }
        }
    }
}
