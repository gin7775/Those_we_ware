using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Test : MonoBehaviour
{
    private Vector3 localReference;
    public int shoots;
    public float fireRate;
    public GameObject projectile;
    public float speed = 3;
    public Rigidbody rb;
    void Start()
    {        
       StartCoroutine(Shooting());     
    }

    IEnumerator Shooting()
    {
        GameObject x = Instantiate(projectile,this.transform.position,Quaternion.identity);
        rb = x.GetComponent<Rigidbody>();
        localReference = this.transform.forward;
        rb.AddForce(localReference * speed, ForceMode.VelocityChange);
        shoots--;
        yield return new WaitForSeconds(fireRate);
        if(shoots > 0)
        {
            StartCoroutine(Shooting());
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
