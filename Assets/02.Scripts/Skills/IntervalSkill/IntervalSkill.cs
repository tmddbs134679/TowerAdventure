using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IntervalSkill : SkillBase
{
    Coroutine _coSkill;

    protected abstract void DoSkillJob();
    public override void ActivateSkill(Action onComplete = null)
    {
        base.ActivateSkill();
        if (_coSkill != null)
            StopCoroutine(_coSkill);

        gameObject.SetActive(true);
        _coSkill = StartCoroutine(CoStartSkill(onComplete));
    }

    //스킬 쿨타임 어디서 제어할지 고민
    protected virtual IEnumerator CoStartSkill(Action onComplete)
    {
        float elapsed = 0f;
        float timer = 0f;

        DoSkillJob(); // 시작하자마자 한 번 공격

        while (elapsed < SkillData.Duration)
        {
            elapsed += Time.deltaTime;
            timer += Time.deltaTime;

            if (timer >= SkillData.AttackInterval)
            {
                timer = 0f;
                //스킬 사용할 때 Player 처다보기
                Extension.LookAtPlayer(gameObject);
                DoSkillJob(); 
            }

            yield return null;
        }

        onComplete?.Invoke();
    }

    public override void InterruptSkill()
    {
        if (_coSkill != null)
        {
            StopCoroutine(_coSkill);
            _coSkill = null;
        }
    }
}
