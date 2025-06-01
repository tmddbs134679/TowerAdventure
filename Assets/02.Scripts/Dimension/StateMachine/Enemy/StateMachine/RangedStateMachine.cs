using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedStateMachine : EnemyStateMachine
{
    [field: SerializeField] public SkillBase baseAttackSkill;


    protected override void Awake()
    {
        States.Add(Define.EENEMYSTATE.IDLE, new EnemyIdleState(this));
        States.Add(Define.EENEMYSTATE.CHASING, new EnemyChasingState(this));
        States.Add(Define.EENEMYSTATE.ATTACK, new EnemyRangedAttackState(this));
        States.Add(Define.EENEMYSTATE.STUN, new EnemyStunState(this));
        States.Add(Define.EENEMYSTATE.DEAD, new EnemyDeadState(this));

    }
    protected override void Update()
    {
        base.Update();
       // UpdateCooldown(Time.deltaTime);
    }

    //public void UpdateCooldown(float deltaTime)
    //{
    //    cooldownTimer -= deltaTime;
    //}

    //public void ResetCooldown()
    //{
    //    cooldownTimer = baseAttackSkill.cooldown;
    //}
}
