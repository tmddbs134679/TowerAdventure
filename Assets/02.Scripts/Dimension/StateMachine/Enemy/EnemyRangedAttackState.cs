using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class EnemyRangedAttackState : EnemyBaseState
{
    private readonly int AttackHas = Animator.StringToHash("Fireball");
    private const float CrossFadeDuration = 0.1f;
    private float elapsedTime = 0f;
    private bool hasAttacked = false;

    public EnemyRangedAttackState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        Debug.Log("Enter");
        elapsedTime = 0f;
        hasAttacked = false;
      
        FacePlayer();
        stateMachine.Animator.CrossFadeInFixedTime(AttackHas, CrossFadeDuration);
        CreatureController cc = stateMachine.GetComponent<CreatureController>();
        cc.Skills.SkillList[0].ActivateSkill();
    }

    public override void Tick(float deltaTime)
    {
        elapsedTime += deltaTime;

        if (!IsInAttackRange())
            stateMachine.SwitchState(stateMachine.States[Define.EENEMYSTATE.IDLE]);
    }



    public override void Exit()
    {
        CreatureController cc = stateMachine.GetComponent<CreatureController>();
        cc.Skills.SkillList[0].InterruptSkill();
    }
}
