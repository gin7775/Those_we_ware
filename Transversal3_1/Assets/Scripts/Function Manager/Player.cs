using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inputs inputs;


    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;



    [SerializeField]
    private Camera Camera;

    Animator animator;


    private void Awake()
    {
        inputs =  GetComponent<Inputs>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetVector = new Vector3(inputs.InputVector.x,0, inputs.InputVector.y);            //Revisa el input vertical y horizontal 

        Vector3 movementVector = MoveTowardTarget(targetVector);                //Se mueva a la direccion que esta apuntando

        RotateTowardMovementVector(movementVector);                         //Rote en la dirección que vea el jugador
    }


    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        
        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * MovementSpeed * Time.deltaTime;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        
        if (movementVector.magnitude == 0) 
        {
            animator.SetFloat("Speed", 0);
            
            return; 

        
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }


}
