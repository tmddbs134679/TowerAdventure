using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRangedAttackState : EnemyBaseState
{
    private readonly int AttackHas = Animator.StringToHash("Attack");
    private const float CrossFadeDuration = 0.1f;
    private float elapsedTime = 0f;
    private bool hasAttacked = false;
    private float coolTime;
    public EnemyRangedAttackState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        elapsedTime = 0f;
        hasAttacked = false;
      
        FacePlayer();
        stateMachine.Animator.CrossFadeInFixedTime(AttackHas, CrossFadeDuration);

    }

    public override void Tick(float deltaTime)
    {
        elapsedTime += deltaTime;

        if (!hasAttacked)
        {
            hasAttacked = true;

            CreatureController cc = stateMachine.GetComponent<CreatureController>();
            cc.Skills.SkillList[0].ActivateSkill();

        }

        if (elapsedTime >= coolTime)
        {
            stateMachine.SwitchState(stateMachine.States[Define.EENEMYSTATE.IDLE]);
        }
    }



    public override void Exit() { }
}
