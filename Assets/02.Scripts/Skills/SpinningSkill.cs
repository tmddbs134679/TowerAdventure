using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
[CreateAssetMenu(menuName = "Skill/Spinning")]
public class SpinningSkill : IntervalSkill                                                      
{
    public float duration;
    public float interval = 0.5f;
    public float damage = 10f;
    public float radius = 2f;
    public float spinSpeed = 720f;

    public override void ActivateSkill()
    {
        base.ActivateSkill();
        //StartCoroutine(SpinAttackRoutine)
    }

    private IEnumerator SpinAttackRoutine(Action onComplete)
    {
        float elapsed = 0f;
        float timer = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            timer += Time.deltaTime;

            // Å¸°Ý
            if (timer >= interval)
            {
                timer = 0f;
                Collider[] hits = Physics.OverlapSphere(transform.position, radius);
                foreach (var hit in hits)
                {
                    if (hit.CompareTag("Enemy"))
                    {
                        Debug.Log($"Spin hit {hit.name} for {damage}");
                        hit.GetComponent<Health>()?.DealDamage(Owner, damage);
                    }
                }
            }

            yield return null;
        }
        onComplete?.Invoke();
    }


    protected override void DoSkillJob()
    {

    }



}

