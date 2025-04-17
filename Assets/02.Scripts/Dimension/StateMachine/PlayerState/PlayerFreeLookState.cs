using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    //string은 컴파일 타임이기 떄문에 런타임에 작동하면서 빠르게 찾을 수 있게 Animator.stringToHah 사용
    private readonly int FreeLookSpeedHas = Animator.StringToHash("FreeLookSpeed");
    private const float AnimatorDampTime = 0.1f;

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.TargetEvent += OnTarget;
    }

    private void OnTarget()
    {
       stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movment = new Vector3();
        movment.x = stateMachine.InputReader.MovementValue.x;
        movment.y = 0;
        movment.z = stateMachine.InputReader.MovementValue.y;

        stateMachine.Controller.Move(movment * stateMachine.FreeLookMovementSpeed * deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHas, 0, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat(FreeLookSpeedHas, 1, AnimatorDampTime, deltaTime);
        FaceMovementDirection(movment, deltaTime);
    }
    public override void Exit()
    {
        stateMachine.InputReader.TargetEvent -= OnTarget;
    }

    private void FaceMovementDirection(Vector3 movment, float deltaTtime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movment),
            deltaTtime * stateMachine.RotationDamping
            );
    }
}
