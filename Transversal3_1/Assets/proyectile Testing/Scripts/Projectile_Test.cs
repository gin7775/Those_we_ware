using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Test : MonoBehaviour
{

    public float speed;
    public Rigidbody rb;

    void Start()
    {


        rb = this.gameObject.GetComponent<Rigidbody>();

        rb.AddForce(Vector3.right * speed,ForceMode.VelocityChange);
    }

   
}
