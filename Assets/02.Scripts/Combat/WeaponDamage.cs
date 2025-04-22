using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollder;

    private List<Collider> alreadyCollderWith = new List<Collider>();
    private int damage;

    private void OnEnable()
    {
        alreadyCollderWith.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other == myCollder) { return; }

        if(alreadyCollderWith.Contains(other)) { return; }

        alreadyCollderWith.Add(other);

        if(other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);
        }
    }

    public void SetAttack(int dmg)
    {
        this.damage = dmg;
    }
}
