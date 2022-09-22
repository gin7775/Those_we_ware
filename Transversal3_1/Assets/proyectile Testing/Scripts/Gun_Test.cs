using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Test : MonoBehaviour
{
    public int shoots;
    public float fireRate;
    public GameObject projectile;
    void Start()
    {        
       StartCoroutine(Shooting());     
    }

    IEnumerator Shooting()
    {
        GameObject x = Instantiate(projectile,this.transform.position,Quaternion.identity);
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
