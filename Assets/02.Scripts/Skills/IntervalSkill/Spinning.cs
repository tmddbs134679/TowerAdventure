using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class Spinning : IntervalSkill                                                      
{

    private void Awake()
    {
        SkillType = Define.ESKILLTYPE.Spinning;
    }

    //public override void ActivateSkill(Action OnComplete)
    //{
    //    base.ActivateSkill();
    //    StartCoroutine(SpinAttackRoutine(OnComplete));
    //}

    //private IEnumerator SpinAttackRoutine()
    //{
       
    //}


    protected override void DoSkillJob()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, SkillData.RecognitionRange);
        foreach (var hit in hits)
        {
            hit.GetComponent<Health>()?.DealDamage(Owner, Owner.CreatureData.Atk);
        }
    }



}

