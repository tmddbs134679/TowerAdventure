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
    public void SetSkill(SkillBase skill, int skillIdx)
    {
        this.currentSkill = skill; 
    }

    public override void Enter()
    {
        SkillHas = Animator.StringToHash(currentSkill.SkillName);
        stateMachine.Animator.CrossFadeInFixedTime(SkillHas, AnimatorDampTime);

        currentSkill.Active
            (
                 stateMachine.gameObject,
                 stateMachine.transform.forward,
                 () => stateMachine.SwitchState(stateMachine.States[Define.EPLAYERSTATE.FREELOOK])
            );
    }


    public override void Tick(float deltaTime)
    {
        if(currentSkill.canMove)
        {
            Vector3 movement = CalculateMovement();

            Move(movement * currentSkill.moveSpeed, deltaTime);
        }


    }

    public override void Exit()
    {

    }

}
