using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : Spell, IDirectionSpell
{
    [SerializeField] private float speed;
    
    private Vector3 _moveDirection;
    void Update()
    {
        transform.Translate(_moveDirection * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _moveDirection = direction.normalized;
        //transform.LookAt(_moveDirection);
    }
}
