using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int health;


    void Start()
    {
        health = maxHealth;
    }


    void Update()
    {
        
    }


    public void DealDamage(int dmg)
    {
        if (health <= 0) { return; }

        health = Mathf.Max(health - dmg, 0);

        Debug.Log(health);
    }
}
