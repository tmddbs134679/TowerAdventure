using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class PlayerController : CreatureController
{
    [SerializeField]

    public override bool Init()
    {
        base.Init();

        ObjectType = EOBJECTTPYE.PLAYER;

        return true;
    }

    private void Start()
    {
        SetInfo(201000);

        InitSkill();
    }

    public override void InitSkill()
    {
        base.InitSkill();

        //TODO
        if (Skills)
        {
            foreach (SkillBase skill in Skills.SkillList)
            {
                skill.UpdateSkillData(skill.DataId);
            }
        }
    }


    public void UseSkill(int idx)
    {
        Skills.SkillList[idx].ActivateSkill();
    }
}
