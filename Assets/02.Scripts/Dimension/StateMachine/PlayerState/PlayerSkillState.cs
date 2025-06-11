using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerSkillState : PlayerBaseState
{
    private int SkillHas;
    private const float AnimatorDampTime = 0.1f;
    private SkillBase currentSkill;

    public PlayerSkillState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
       
    }
    public void SetSkill(SkillBase skill)
    {
        this.currentSkill = skill; 
    }

    public override void Enter()
    {
        SkillHas = Animator.StringToHash(currentSkill.SkillType.ToString());
        stateMachine.Animator.CrossFadeInFixedTime(SkillHas, AnimatorDampTime);
        currentSkill.ActivateSkill(OnSkillFinished);
        stateMachine.IsCastingSkill = true;
    }


    public override void Tick(float deltaTime)
    {
        if(currentSkill.SkillData.IsMove)
        {
            Vector3 movement = CalculateMovement();
            Move(movement * currentSkill.SkillData.moveSpeed, deltaTime);
        }

    }

    public override void Exit()
    {
        stateMachine.IsCastingSkill = false;
    }
    private void OnSkillFinished()
    {
        stateMachine.SwitchState(stateMachine.States[Define.EPLAYERSTATE.FREELOOK]);
    }
}
