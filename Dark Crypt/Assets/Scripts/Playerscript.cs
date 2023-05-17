using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    public float speed = 5;
    private CharacterController characterController;
    private Animator animator;

    private bool isMoving;

    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 direction;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MovementCheck();
            AnimationCheck();
        }
    }

    void MovementCheck()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontalMovement, 0, verticalMovement);

        if(direction.magnitude >= 0.1f ) 
        { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0,angle, 0);

            characterController.Move(direction * speed * Time.deltaTime);
        }
    }

    private void AnimationCheck()
    {
        if(direction != Vector3.zero && !isMoving)
        {
            isMoving= true;
            animator.SetBool("isRunning", isMoving);
        }
        else if (direction == Vector3.zero && isMoving)
        {
            isMoving = false;
            animator.SetBool("isRunning", isMoving);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            canMove= false;
            animator.SetTrigger("IsDead");
        }
    }
}
