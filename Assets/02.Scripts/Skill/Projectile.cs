using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject attacker { get; private set; }
    public EFACTION OwnerFaction { get; private set; }
    private float damage;

    public void Init(GameObject attacker, float speed, float dmg)
    {

        //OwnerFaction = attacker.GetComponent<Faction>().faction;
        this.attacker = attacker;
        damage = dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Faction>(out var targetFaction))
        {
            if (targetFaction.faction == OwnerFaction)
                return;

            other.GetComponent<Health>().DealDamage(attacker, damage);
        }
    }
}
