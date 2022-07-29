using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[System.Serializable]
public class MoveInputEvent : UnityEvent<float, float> { }

public class Input : MonoBehaviour
{
    PlayerInput playerInput;
    
    public MoveInputEvent moveInputEvent;

    

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
    private void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }


    private void Onmove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        moveInputEvent.Invoke(moveInput.x, moveInput.y);
        
    }

   
}
