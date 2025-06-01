using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    //string은 컴파일 타임이기 떄문에 런타임에 작동하면서 빠르게 찾을 수 있게 Animator.stringToHah 사용
    private readonly int FreeLookSpeedHas = Animator.StringToHash("FreeLookSpeed");
    private const float AnimatorDampTime = 0.1f;
    private readonly string FreeLookAnimName = "FreeLookBlentTree";
    private const float CrossFadeDuration = 0.1f;

    private Vector3 ladderForward;

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
       
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FreeLookAnimName, CrossFadeDuration);
        stateMachine.InputReader.TargetEvent += OnTarget;
        stateMachine.InputReader.DodgeEvent += Dodge;
        stateMachine.LadderDetector.OnLadderDetect += HandleLadderDetect;
        EventBus.Subscribe<SkillUsedEvent>(OnSkillInvoked);

    }


    public override void Tick(float deltaTime)
    {

        if (stateMachine.InputReader.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine, 0));
            return;
        }


        Vector3 movement = CalculateMovement();

        Move(movement * stateMachine.FreeLookMovementSpeed, deltaTime);

        if (GameManager.Inst.JoystickDir == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHas, 0, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat(FreeLookSpeedHas, 1, AnimatorDampTime, deltaTime);
        FaceMovementDirection(movement, deltaTime);
    }
    public override void Exit()
    {
        stateMachine.LadderDetector.OnLadderDetect -= HandleLadderDetect;
        stateMachine.InputReader.TargetEvent -= OnTarget;
        stateMachine.InputReader.DodgeEvent -= Dodge;
        EventBus.Unsubscribe<SkillUsedEvent>(OnSkillInvoked);
    }


    private void OnTarget()
    {
        if(!stateMachine.Targeter.SelectTatget())
        { return; }

    }


    private void FaceMovementDirection(Vector3 movment, float deltaTtime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movment),
            deltaTtime * stateMachine.RotationDamping
            );
    }

    private void OnSkillInvoked(SkillUsedEvent e)
    {
        var skillState = (PlayerSkillState)stateMachine.States[Define.EPLAYERSTATE.SKILL];
        skillState.SetSkill(e.skill, e.skillIdx);
        stateMachine.SwitchState(stateMachine.States[Define.EPLAYERSTATE.SKILL]);
    }


    private void HandleLadderDetect(Vector3 ladderForward)
    {
        stateMachine.SwitchState(stateMachine.States[Define.EPLAYERSTATE.CLIMB]);
    }
}
