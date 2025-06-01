using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static TMPro.Examples.TMP_ExampleScript_01;
using static Define;


public class SkillBook : MonoBehaviour
{
    [SerializeField]
    private List<SkillBase> _skillList = new List<SkillBase>();
    public List<SkillBase> SkillList { get { return _skillList; } }
    public List<SkillBase> RepeatedSkills { get; } = new List<SkillBase>();

    public List<SequenceSkill> SequenceSkills { get; } = new List<SequenceSkill>();
    public List<SkillBase> ActivatedSkills
    {
        get { return SkillList.Where(skill => skill.IsLearnedSkill).ToList(); }
    }
    public EOBJECTTYPE  _ownerType;

    public void Awake()
    {
        _ownerType = GetComponent<StateMachine>().ObjectType;
    }
    public void SetInfo(EOBJECTTYPE type)
    {
        _ownerType = type;
    }



}
