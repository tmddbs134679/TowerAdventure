using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.Examples.TMP_ExampleScript_01;
using static Define;
using Unity.VisualScripting;

public class SkillBook : MonoBehaviour
{
    [SerializeField]
    private List<SkillBase> _skillList = new List<SkillBase>();
    public List<SkillBase> SkillList { get { return _skillList; } }
    public List<SequenceSkill> SequenceSkills { get; } = new List<SequenceSkill>();
    public List<IntervalSkill> IntervalSkills { get; } = new List<IntervalSkill>();
    public EOBJECTTPYE _ownerType;

    public void Awake()
    {
        _ownerType = GetComponent<CreatureController>().ObjectType;
    }

    public void SetInfo(EOBJECTTPYE type)
    {
        _ownerType = type;
    }

    public void LoadSkill(Define.ESKILLTYPE skillType, int level)
    {
        AddSkill(skillType);
    }
    public void AddSkill(Define.ESKILLTYPE skillType, int skillId = 0)
    {
        string className = skillType.ToString();

        // AddComponent¸¸ ÇÏ¸é‰Î
        SequenceSkill skill = gameObject.AddComponent(Type.GetType(className)) as SequenceSkill;
        if (skill != null)
        {
            skill.Owner = GetComponent<CreatureController>();
            skill.DataId = skillId;
            SkillList.Add(skill);
            SequenceSkills.Add(skill);
        }
        else
        {
            IntervalSkill skillbase = gameObject.GetComponent(Type.GetType(className)) as IntervalSkill;
            skillbase.DataId = skillId;
            SkillList.Add(skillbase);
        }
    }
    
}
