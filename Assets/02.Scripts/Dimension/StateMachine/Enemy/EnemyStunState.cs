using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunState : EnemyBaseState
{

    private readonly int StunHas = Animator.StringToHash("GetHit");
    private readonly int SpeedHas = Animator.StringToHash("Speed");

    private const float CrossFadeDuration = 0.1f;

    private float duration = 1f;


    public EnemyStunState(EnemyStateMachine stateMachine) : base(stateMachine)  { }

    public override void Enter()
    {
        duration = 1f;
        stateMachine.Animator.CrossFadeInFixedTime(StunHas, CrossFadeDuration);
    }



    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        duration -= deltaTime;

        if(duration <= 0f)
        {
            stateMachine.SwitchState(stateMachine.States[EENEMYSTATE.IDLE]);
        }
    }

    public override void Exit()
    {
    }
}
