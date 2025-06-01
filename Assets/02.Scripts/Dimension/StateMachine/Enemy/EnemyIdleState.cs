using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyIdleState : EnemyBaseState
{
    private readonly int IdleHas = Animator.StringToHash("Locomotion");
    private readonly int SpeedHas = Animator.StringToHash("Speed");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;


    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }
    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(IdleHas, CrossFadeDuration);
      
    }



    public override void Tick(float deltaTime)
    {

        Move(deltaTime);


       // if (!stateMachine.CanAttack) { return; }

        if(IsInChaseRange())
        {
            stateMachine.SwitchState(stateMachine.States[Define.EENEMYSTATE.CHASING]);
            return;
        }


        stateMachine.Animator.SetFloat(SpeedHas, 0, AnimatorDampTime, deltaTime);
    }

 
    public override void Exit()
    {

    }
}
