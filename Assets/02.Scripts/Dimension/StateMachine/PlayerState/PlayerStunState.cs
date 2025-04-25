using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStunState : PlayerBaseState
{
    private readonly int StunHas = Animator.StringToHash("GetHit");
    private readonly int SpeedHas = Animator.StringToHash("Speed");

    private const float CrossFadeDuration = 0.1f;

    private float duration = 0.2f;

    public PlayerStunState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(StunHas, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        duration -= deltaTime;

        if(duration <= 0f)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
    }

    public override void Exit()
    {

    }
}
