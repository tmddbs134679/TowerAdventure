using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class CreatureController : BaseController
{
    public CreatureData CreatureData;
    public virtual int DataId { get; set; }
    public virtual SkillBook Skills { get; set; }

    void Awake()
    {
        Init();
    }
    public override bool Init()
    {
        base.Init();

        Skills = gameObject.GetOrAddComponent<SkillBook>();

        return true;
    }
    public void SetInfo(int creatureId)
    {
        DataId = creatureId;
        Dictionary<int, Data.CreatureData> dict = Managers.Data.CreatureDic;
        CreatureData = dict[creatureId];
        InitCreatureStat();

        Init();
    }

    public void LoadSkill()
    {
        foreach(KeyValuePair<ESKILLTYPE, int> pair in Managers.Game.ContinueInfo.SavedBattleSkill.ToList())
        {
            Skills.LoadSkill(pair.Key, pair.Value);
        }
    }

    public virtual void InitSkill()
    {
        foreach (int skillId in CreatureData.SkillTypeList)
        {
            ESKILLTYPE type = Util.GetSkillTypeFromInt(skillId);
            if (type != ESKILLTYPE.NONE)
                Skills.AddSkill(type, skillId);
        }
    }

    private void InitCreatureStat()
    {
        
    }
}
