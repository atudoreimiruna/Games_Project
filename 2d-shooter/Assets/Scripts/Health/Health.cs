using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action OnDamaged;
    public event Action OnDeath;

    public float health, maxHealth;

    public bool godMode = false;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            godMode = !godMode;
        }
    }

    public void TakeDamage(float amount)
    {
        if (!godMode || this.gameObject.tag != "Player")
        {
            health -= amount;
            OnDamaged?.Invoke();

            if (health <= 0)
            {
                health = 0;
                Debug.Log("You're dead");
                OnDeath?.Invoke();
            }
        }
    }
}
