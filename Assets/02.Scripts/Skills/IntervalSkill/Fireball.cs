using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        GenerateProjectile(Owner, prefabName, startPos, dir, Vector3.forward, this);
    
        
    }

}
