using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillItem : UI_Base
{
    #region Enums
    enum GameObjects
    {
        UI_Skill,
    }

    enum Texts
    {
        SkillCoolTimeText,
    }

    enum Images
    {
        SkillbackgroundImage,
        SkillImage,
    }
    #endregion

    private SkillBase _skill;


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        #region Object Bind
        BindObject(typeof(GameObjects));
        BindText(typeof(Texts));
        BindImage(typeof(Images));
        gameObject.BindEvent(UseSkill);
        #endregion

        return true;
    }

    private void UseSkill()
    {
       //누른 스킬 시작
    }
}
