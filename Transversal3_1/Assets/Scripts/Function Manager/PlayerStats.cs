using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;

    public int maxHealth;

    public int currentHealth;

    public HealthBar healthBar;

    private Animator anim;

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int SetMaxHealthFromHealthLevel()
    {

        maxHealth = healthLevel * 10;

        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        healthBar.SetCurrentHealth(currentHealth);

        anim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            anim.SetTrigger("Death");

            
        }
    }
}
