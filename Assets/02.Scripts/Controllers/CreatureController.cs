using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    private void InitCreatureStat()
    {
        
    }
}
