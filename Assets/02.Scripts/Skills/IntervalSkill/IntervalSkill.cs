using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IntervalSkill : SkillBase
{
    Coroutine _coSkill;

    protected abstract void DoSkillJob();
    public override void ActivateSkill(Action onComplelte = null)
    {
        base.ActivateSkill();
        if (_coSkill != null)
            StopCoroutine(_coSkill);

        gameObject.SetActive(true);
        _coSkill = StartCoroutine(CoStartSkill());
    }


    protected virtual IEnumerator CoStartSkill()
    {
        while (true)
        {

            DoSkillJob();
            yield return null;
        }
    }
}
