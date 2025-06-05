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

public class SkillBase : BaseController
{
    public string SkillName;
    public Sprite SkillIcon;
    public float cooldown = 1f;

    [Header("움직임 제어")]
    public bool canMove = false;
    public float moveSpeed;

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



    public virtual void OnChangedSkillData() { }

    // 레벨 0에서 1될때만 실행
    public virtual void ActivateSkill(Action onComplete = null)
    {
        //UpdateSkillData();
        //onComplete?.Invoke();
    }



    protected virtual void GenerateProjectile(CreatureController Owner, string prefabName, Vector3 startPos, Vector3 dir, Vector3 targetPos, SkillBase skill)
    {
        ProjectileController pc = Managers.Object.Spawn<ProjectileController>(startPos, prefabName: prefabName);
        pc.SetInfo(Owner, startPos, dir, targetPos, skill);
    }

    protected void HitEvent(Collider2D collision)
    {

    }

    //public abstract void Active(GameObject caster, Vector3 dir, Action onComplete = null);
 



  
}
