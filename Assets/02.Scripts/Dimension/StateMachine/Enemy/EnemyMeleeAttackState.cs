using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyBaseState
{
    private readonly int AttackHas = Animator.StringToHash("Attack1");
    private readonly int SpeedHas = Animator.StringToHash("Speed");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    private bool hasFacedPlayer = false;
    public EnemyMeleeAttackState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        if (stateMachine.Weapon != null)
            stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);
        stateMachine.Animator.CrossFadeInFixedTime(AttackHas, CrossFadeDuration);
    }


    public override void Tick(float deltaTime)
    {
        AnimatorStateInfo stateInfo = stateMachine.Animator.GetCurrentAnimatorStateInfo(0);

        // 애니메이션이 끝났으면
        if (stateInfo.normalizedTime % 1f < 0.02f && stateInfo.IsName("Attack1"))
        {
            if (!hasFacedPlayer)
            {
                FacePlayer();
                hasFacedPlayer = true;
            }
            else
            {
                hasFacedPlayer = false;
            }

        }


        if (!IsInAttackRange())
        {
            stateMachine.SwitchState(stateMachine.States[Define.EENEMYSTATE.CHASING]);
        }
    }


    public override void Exit()
    {

    }
}
