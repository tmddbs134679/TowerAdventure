using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject attacker { get; private set; }
    public EFACTION OwnerFaction { get; private set; }
    protected float damage;

    public void Init(GameObject attacker, float speed, float dmg)
    {
        this.attacker = attacker;
        damage = dmg;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Faction>(out var targetFaction))
        {
            if (targetFaction.faction == OwnerFaction)
                return;

            other.GetComponent<Health>().DealDamage(attacker, damage);
        }
    }
}
