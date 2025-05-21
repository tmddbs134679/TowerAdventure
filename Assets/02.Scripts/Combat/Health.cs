using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private float health;

    public event Action<float, Vector3>OnTakeDamage;
    public event Action OnDie;
    public bool IsDead => health == 0;
    public float Current => health;       
    public int Max => maxHealth;          

    private void Awake()
    {
        
    }
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(GameObject attacker ,float dmg)
    {
        if (health == 0) { return; }

        health = Mathf.Max(health - dmg, 0);

        OnTakeDamage?.Invoke(dmg, transform.position);

        EventBus.Publish(new PlayerDamagedEvent
        {
            Player = this.transform.root.gameObject,
            NewHP = (int)health,
            MaxHP = maxHealth
        });

        if (health == 0)
        {
            OnDie?.Invoke();
        }
    }
}
