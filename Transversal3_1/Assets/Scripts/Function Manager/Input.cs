using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[System.Serializable]
public class MoveInputEvent : UnityEvent<float, float> { }



[System.Serializable]
public class RollInput : UnityEvent<bool> { }

public class Input : MonoBehaviour
{
    PlayerInput playerInput;
    
    public MoveInputEvent moveInputEvent;

    public RollInput rollInput;

    PlayerInput playerInputRoll;

   
    public float moveAmount;
    Vector2 input;


    private bool b_input;

    
    private void Awake()
    {
        playerInput = new PlayerInput();
       
    }

    // Update is called once per frame


    private void OnEnable()
    {
        playerInput.CharacterControls.Enable();

        playerInput.CharacterControls.Move.performed += Onmove;                  

        playerInput.CharacterControls.Move.canceled += Onmove;

       
        
        
    }
   


    private void Onmove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        input = moveInput;
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
        
    }

    
     
    
   
}
