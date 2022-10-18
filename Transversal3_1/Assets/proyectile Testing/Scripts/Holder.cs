using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public Gun_Test[] Guns;
    private void Start()
    {


        Guns = GetComponentsInChildren<Gun_Test>();
    }
    public void SetGun(int shoots, float fireRate, float speed)
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].shoots = shoots;
            Guns[i].fireRate = fireRate;
            Guns[i].speed = speed;
        }
    }
}
