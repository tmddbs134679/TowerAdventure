using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Define;


public class SpinningSkill : SequenceSkill                                                      
{
    //public float duration;
    //public float interval = 0.5f;
    //public float damage = 10f;
    public float radius = 2f;
    //public float spinSpeed = 720f;

    Coroutine _co;

    public void Awake()
    {
     
        SkillType = Define.ESKILLTYPE.SPINNING;
    }

    public override void DoSkill(Action callback = null)
    {
        //if (_co != null)
          //  StopCoroutine(_co);

        //_co = StartCoroutine(SpinAttackRoutine(callback));
        StartCoroutine(SpinAttackRoutine(callback));
    }

    private IEnumerator SpinAttackRoutine(Action callback = null)
    {
        float elapsed = 0f;
        float timer = 0f;

        while (elapsed < 3)
        {
            elapsed += Time.deltaTime;
            timer += Time.deltaTime;

            // Å¸°Ý
            if (timer >= 3)
            {
                timer = 0f;
                Collider[] hits = Physics.OverlapSphere(transform.position, radius);
                foreach (var hit in hits)
                {
                    if (hit.CompareTag("Enemy"))
                    {
                       
                       //hit.GetComponent<Health>()?.DealDamage(caster, damage);
                    }
                }
            }

            yield return null;
        }

        callback?.Invoke();
    }

}

