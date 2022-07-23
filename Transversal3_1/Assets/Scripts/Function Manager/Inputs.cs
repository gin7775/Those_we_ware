using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }

  
    // Update is called once per frame
    void Update()
    {
        InputPrincipalMovement();

        
    }


    void InputPrincipalMovement()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);
    }

    void InputSwordAttack()
    {

        
    }
}