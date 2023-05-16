using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    public float speed = 5;
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private Transform camtransform;

    private bool isMoving;

    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 direction;
    private Vector3 camForward;
    private Vector3 camRight;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementCheck();
        AnimationCheck();
    }

    void MovementCheck()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        //cam dir
        camForward = camtransform.forward;
        camRight = camtransform.right;

        camForward.y = 0;
        camRight.y = 0;

        //relative cam dir
        Vector3 forwardRelative = verticalMovement * camForward;
        Vector3 rightRelative = horizontalMovement * camRight;

        Vector3 movedir = forwardRelative + rightRelative;

        direction = new Vector3(horizontalMovement, 0, verticalMovement);

        if(direction.magnitude >= 0.1f ) 
        { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(movedir.x , 0, movedir.z);

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
}
