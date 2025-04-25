using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollder;

    private List<Collider> alreadyCollderWith = new List<Collider>();
    private int damage;
    private float knockback;

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

        if(other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver))
        {
            Vector3 dir = (other.transform.position - myCollder.transform.position).normalized;
            forceReceiver.AddForce(dir * knockback);
        }
    }

    public void SetAttack(int dmg, float knockback)
    {
        this.damage = dmg;
        this.knockback = knockback;
    }
}
