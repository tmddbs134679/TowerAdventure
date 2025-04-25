using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHas = Animator.StringToHash("Attack1");
    private readonly int SpeedHas = Animator.StringToHash("Speed");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);
        stateMachine.Animator.CrossFadeInFixedTime(AttackHas, CrossFadeDuration);
    }

  
    public override void Tick(float deltaTime)
    {
        //AnimatorStateInfo stateInfo = stateMachine.Animator.GetCurrentAnimatorStateInfo(0);

        //// 애니메이션이 끝났으면
        //if (stateInfo.normalizedTime >= 1f && stateInfo.IsName("Attack1"))
        //{
        //    FacePlayer();
        //}


        if (!IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        }
    }


    public override void Exit()
    {

    }

}
