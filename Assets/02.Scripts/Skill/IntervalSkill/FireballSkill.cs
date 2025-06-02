using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : IntervalSkill
{
    protected override void DoSkillJob()
    {
        if (PlayerSelector.Inst.selectedPlayer == null)
            return;

       //GenerateProjectile(1,Owner,) 
    }

}
