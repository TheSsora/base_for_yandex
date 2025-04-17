using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float health;
    [SerializeField] private float speed;

    private Transform _target;
    private Vector3 _moveDirection = Vector3.zero;
    
    public void SpawnInit(Transform target)
    {
        _target = target;
    }

    public void TakeDamage(float damage)
    {
        if ((health -= damage) <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        _moveDirection = (_target.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(_moveDirection);
        
        characterController.Move(_moveDirection * (speed * Time.deltaTime));
    }
}
