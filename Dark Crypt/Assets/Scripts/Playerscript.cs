using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    public float speed = 5;
    private CharacterController characterController;

    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementCheck();
    }

    void MovementCheck()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontalMovement, 0, verticalMovement);

        if(direction.magnitude >= 0.1f ) 
        { 
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}
