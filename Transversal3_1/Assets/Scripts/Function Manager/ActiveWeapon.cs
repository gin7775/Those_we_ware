using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public int weaponNumber;

    public TakeWeapon takeWeapon;
    void Start()
    {
        takeWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<TakeWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            takeWeapon.ActivateWeapon(weaponNumber);
            Destroy(gameObject);

        }
    }
}
