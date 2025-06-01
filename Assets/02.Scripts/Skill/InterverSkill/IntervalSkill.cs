using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IntervalSkill : SkillBase
{
    public float CollTime { get; set; } = 1.0f;

    Coroutine _coSkill;


    public override bool Init()
    {
        base.Init();
        return true;
    }

    public override void ActivateSkill()
    {
        base.ActivateSkill();

        if (_coSkill != null)
            StopCoroutine(_coSkill);

        gameObject.SetActive(true);
        _coSkill = StartCoroutine(CoStartSkill());
    }

    protected abstract void DoSkillJob();

    protected virtual IEnumerator CoStartSkill()
    {
        WaitForSeconds wait = new WaitForSeconds(SkillData.CoolTime);

        yield return wait;
        while (true)
        {
            if (SkillData.CoolTime != 0)
                yield return wait;
            //Managers.Sound.Play(Define.Sound.Effect, SkillData.CastingSound);
            DoSkillJob();
            yield return wait;
        }
    }
}
