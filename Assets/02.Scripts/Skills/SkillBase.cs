using Data;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;



public class SkillBase : BaseController
{
    public int DataId;
    public CreatureController Owner { get; set; }


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

    #region skillData
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
    #endregion


    public bool IsLearnedSkill { get; set;  }
    public Data.SkillData UpdateSkillData(int dataId = 0)
    {
        SkillData skillData = new Data.SkillData();

        if (Managers.Data.SkillDic.TryGetValue(dataId, out skillData) == false)
            return SkillData;


        SkillData = skillData;
        return SkillData;
    }

    public virtual void OnChangedSkillData() { }

    public virtual void ActivateSkill(Action onComplete = null)
    {
        //UpdateSkillData();
        onComplete?.Invoke();
    }
    protected virtual void GenerateProjectile(CreatureController Owner, string prefabName, Vector3 startPos, Vector3 dir, Vector3 targetPos, SkillBase skill)
    {
        ProjectileController pc = Managers.Object.Spawn<ProjectileController>(startPos, prefabName: prefabName);
        pc.SetInfo(Owner, startPos, dir, targetPos, skill);
    }

    protected void HitEvent(Collider2D collision)
    {

    }
    public virtual void InterruptSkill(){ }
}
