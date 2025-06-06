using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterController : CreatureController
{
    public override bool Init()
    {
        base.Init();
        ObjectType = EOBJECTTPYE.MONSTER;
        
        //TODO


        return true;
    }

    public void UseSkill(int idx)
    {
        Skills.SkillList[idx].ActivateSkill();
    }
}
