using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Test : MonoBehaviour
{
    public float lifeTime=10;
   
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

   
}
