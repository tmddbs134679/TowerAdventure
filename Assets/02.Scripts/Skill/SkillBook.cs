using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.Examples.TMP_ExampleScript_01;
using static Define;

public class SkillBook : MonoBehaviour
{
    [SerializeField]
    private List<SkillBase> _skillList = new List<SkillBase>();
    public List<SkillBase> SkillList { get { return _skillList; } }
    public List<IntervalSkill> SequenceSkills { get; } = new List<IntervalSkill>();

    public event Action UpdateSkillUi;
    public EOBJECTTPYE _ownerType;


    public void SetInfo(EOBJECTTPYE type)
    {
        _ownerType = type;
    }



}
