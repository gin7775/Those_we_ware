using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public bool isMovementPressed;

    public float rotationSpeed;

    float horizontal;

    float vertical;

   
    Animator animator;

    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        MovementDirection();
        Animations();

    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;
        isMovementPressed = horizontal != 0 || vertical != 0 ;
       
    }


    public void MovementDirection()
    {
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;

       

        Vector3 cameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);          //Necesitamos el vector que tiene la camara 

        Quaternion rotationToCamera = Quaternion.LookRotation(cameraForward, Vector3.up);
        
        moveDirection = rotationToCamera * moveDirection;
                           

        if(moveDirection != Vector3.zero)
        {
            Quaternion rotationToMoveDirection = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMoveDirection, rotationSpeed * Time.deltaTime);
        }
   

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
    
    public void Animations()
    {


        animator.SetFloat("speed", characterController.velocity.sqrMagnitude / moveSpeed);



    }
    
}
