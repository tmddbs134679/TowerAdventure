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

            if (stateMachine is RangedStateMachine machine &&
                machine.baseAttackSkill is ParabolaSkill parabolaSkill)
            {
              
                parabolaSkill.Active
                                    (
                                        stateMachine.gameObject,
                                        stateMachine.Player.transform.position,
                                        null 
                                    );

                coolTime = parabolaSkill.cooldown;
            }
        }

        if (elapsedTime >= coolTime)
        {
            stateMachine.SwitchState(stateMachine.States[EENEMYSTATE.IDLE]);
        }
    }



    public override void Exit() { }
}
