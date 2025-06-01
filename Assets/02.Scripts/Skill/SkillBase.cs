using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class SkillStat
{
    public Define.ESKILLTYPE SkillType;
    public int Level;
    public float MaxHp;
    public Data.SkillData SkillData;
}
public abstract class SkillBase : MonoBehaviour
{
    bool _init = false;

    public State Owner { get; set; }

    int level = 0;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public bool IsLearnedSkill { get { return Level > 0; } }
    Define.ESKILLTYPE skillType;
    public Define.ESKILLTYPE SkillType
    {
        get
        {
            return skillType;
        }
        set
        {
            skillType = value;
        }

    }
    [SerializeField]
    public Data.SkillData _skillData;
    public Data.SkillData SkillData
    {
        get
        {
            return _skillData;
        }
        set
        {
            _skillData = value;
        }
    }

    void Awake()
    {
        Init();
    }

    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }

    public virtual void ActivateSkill()
    {
       // UpdateSkillData();
    }

    private void UpdateSkillData()
    {
       
    }
}
