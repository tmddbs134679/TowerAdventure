using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
[CreateAssetMenu(menuName = "Skill/Spinning")]
public class Spinning : IntervalSkill                                                      
{
    //public float duration;
    //public float interval = 0.5f;
    //public float damage = 10f;
    //public float radius = 2f;
    //public float spinSpeed = 720f;

    private void Awake()
    {
        SkillType = Define.ESKILLTYPE.Spinning;
    }

    public override void ActivateSkill(Action OnComplete)
    {
        base.ActivateSkill();
        StartCoroutine(SpinAttackRoutine(OnComplete));
    }

    private IEnumerator SpinAttackRoutine(Action onComplete)
    {
        float elapsed = 0f;
        float timer = 0f;

        while (elapsed < SkillData.Duration)
        {
            elapsed += Time.deltaTime;
            timer += Time.deltaTime;

            // Å¸°Ý
            if (timer >= SkillData.AttackInterval)
            {
                timer = 0f;
                Collider[] hits = Physics.OverlapSphere(transform.position, SkillData.RecognitionRange);
                foreach (var hit in hits)
                {
                    if (hit.CompareTag("Enemy"))
                    {
                        hit.GetComponent<Health>()?.DealDamage(Owner, Owner.CreatureData.Atk);
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

