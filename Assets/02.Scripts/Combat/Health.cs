using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private float health;

    public event Action OnTakeDamage;
    public event Action OnDie;

    public bool IsDead => health == 0;
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float dmg)
    {
        if (health == 0) { return; }

        health = Mathf.Max(health - dmg, 0);

        OnTakeDamage?.Invoke();

        DamageTextPool.Inst.ShowDamageText(dmg, gameObject.transform.position);

        if(health == 0)
        {
            OnDie?.Invoke();
        }
        Debug.Log(health);
    }
}
