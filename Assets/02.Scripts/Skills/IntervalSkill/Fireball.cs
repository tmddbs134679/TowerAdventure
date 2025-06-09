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

        Vector3 startPos = transform.position;
        Vector3 dir = PlayerSelector.Inst.selectedPlayer.transform.position;

        if (Owner.TryGetComponent<Animator>(out var animator))
        {
            int animHash = Animator.StringToHash(SkillType.ToString());
            animator.CrossFadeInFixedTime(animHash, 0.1f);
            //animator.CrossFade(animHash, 0.1f);
        }

        GenerateProjectile(Owner, prefabName, startPos, Vector3.forward, dir, this);
    
        
    }

}
