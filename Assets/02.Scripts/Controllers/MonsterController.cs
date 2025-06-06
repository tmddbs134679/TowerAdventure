using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterController : CreatureController
{

    private void OnEnable()
    {
        if (DataId != 0)
            SetInfo(DataId);
    }



    public override bool Init()
    {
        base.Init();
        ObjectType = EOBJECTTPYE.MONSTER;

        //TODO
        if (Skills)
        {
            foreach (SkillBase skill in Skills.SkillList)
            {
                skill.UpdateSkillData();
            }
        }

        return true;
    }

    public void UseSkill(int idx)
    {
        Skills.SkillList[idx].ActivateSkill();
    }
}
