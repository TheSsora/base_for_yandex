using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    
    private Vector3 _moveDirection = Vector3.zero;
    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (_moveDirection.magnitude > 0)
        {
            animator.SetBool("IsMove", true);
            transform.rotation = Quaternion.LookRotation(_moveDirection);
        }
        else
        {
            animator.SetBool("IsMove", false);
        }
        
        characterController.Move(_moveDirection * (speed * Time.deltaTime));
    }
}
