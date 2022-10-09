using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeWeapon : MonoBehaviour
{

    public Player player;
    public GameObject[] weapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDisableGun(InputValue value)
    {
        DisableWeapon();

    }

    public void ActivateWeapon(int number)
    {
        for(int i = 0; i < weapon.Length; i++)
        {

            weapon[i].SetActive(false);
        }

        weapon[number].SetActive(true);
        player.withWeapon = true;
    }

    public void DisableWeapon()
    {

        for(int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false);

        }
        player.withWeapon = false;
    }
}
