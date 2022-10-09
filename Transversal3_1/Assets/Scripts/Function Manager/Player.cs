using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool isMovementPressed;

    public float rotationSpeed;

    float horizontal;

    float vertical;
    [SerializeField] AnimationCurve dodgeCurve;

    bool isDodging;

    float dodgeTimer;

    public bool withWeapon;
    public bool isAttacking;
   

    Vector3 direction;
    Animator animator;

    private PlayerInput playerInput;
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Keyframe dodgeLastFrame = dodgeCurve[dodgeCurve.length - 1];   
        dodgeTimer = dodgeLastFrame.time;
    }
    void Update()
    {
        if(!isDodging) MovementDirection();
        Animations();
       

       
    }
    public void OnRoll(InputValue value)
    {

        if (direction.magnitude != 0)                         //Solo cuando el jugador se este moviendo.
        {
           
            if(!isDodging )
            {
                StartCoroutine(Dodge());                       
            }
        }
       

    }

    public void OnAttack(InputValue input)
    {
        if(!isDodging)
        {
            Attack();
        }
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
        direction = moveDirection;
    }
    
    public void Animations()
    {


        animator.SetFloat("speed", characterController.velocity.sqrMagnitude / moveSpeed);



    }

    IEnumerator Dodge()
    {
        animator.SetTrigger("Dodge");

        isDodging = true;

        float timer = 0;

        characterController.center = new Vector3(0, 0.47f, 0);

        characterController.height = 0.93f;
        while (timer < dodgeTimer)
        {

            float speed = dodgeCurve.Evaluate(timer);
            Vector3 dir = (transform.forward * speed) + (Vector3.up * vertical);        //Añadade la velocidad y la direccion del personaje

            characterController.Move(dir * Time.deltaTime);

            timer += Time.deltaTime;
            yield return null; 
        }
        characterController.center = new Vector3(0, 0.94f, 0);
        characterController.height = 1.86f;
        isDodging = false;

    }


    private void Attack()
    {

        if (withWeapon)
        {
            animator.SetTrigger("Attack");
            isAttacking = true;

        }

        
    }

    private void StopAttack()
    {
        isAttacking = false;                         //Se le añade un evento a la animación de ataque
    }


}
