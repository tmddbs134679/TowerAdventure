using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private readonly int DeadHas = Animator.StringToHash("Dead");
    private readonly int SpeedHas = Animator.StringToHash("Speed");
    private const float AnimatorDampTime = 0.1f;

    private const float CrossFadeDuration = 0.1f;
    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {

        stateMachine.Weapon.gameObject.SetActive(false);
        stateMachine.Animator.CrossFadeInFixedTime(DeadHas, AnimatorDampTime);
    }

    public override void Tick(float deltaTime){ }

    public override void Exit(){ }
}
