using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;
    // C# property
    public int CurrentHealth
    {
        get{
            return currentHealth;
        }

        // set{
        //     currentHealth = value;
        // }
    }

    public int damage;
    public int armor;

    public event System.Action<int,int> OnHealthChanged;

    private void Awake() {
        currentHealth = maxHealth;
        StartCoroutine(HealthIncrease());
        // StopCoroutine(HealthIncrease());
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= armor;

        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void RestoreHealth(int restore)
    {
        // currentHealth += restore;
        // Make sure to not have health above max health
        currentHealth = Mathf.Clamp(currentHealth + restore, 0, maxHealth);

        Debug.Log(currentHealth);

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }
    }

    IEnumerator HealthIncrease()
    {
        Debug.Log("Start Coroutine");

        for(int x = 1; x <= maxHealth; x++)
        {
            currentHealth = x;
            if(OnHealthChanged != null)
            {
                OnHealthChanged(maxHealth, currentHealth);
            }

            yield return new WaitForSeconds(0.01f);
            Debug.Log("HP: " + currentHealth + " / " + maxHealth);
        }

        Debug.Log("The current health is " + currentHealth);
        Debug.Log("End Coroutine");
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died!");
    }
}
