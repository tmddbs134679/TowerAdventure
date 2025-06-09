using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Fireball : IntervalSkill
{

    private void Awake()
    {
        SkillType = Define.ESKILLTYPE.Fireball;
    }
    protected override void DoSkillJob()
    {
        string prefabName = SkillType.ToString();

        Vector3 startPos = Owner.Indicator.transform.position;
        Vector3 target = PlayerSelector.Inst.selectedPlayer.transform.position;
        Vector3 dir = (target - startPos).normalized;
        if (Owner.TryGetComponent<Animator>(out var animator))
        {
            animator.CrossFadeInFixedTime(Define.ProjectileHas, 0.1f);
         
        }

        GenerateProjectile(Owner, prefabName, startPos, dir, target, this);
    
        
    }

}
