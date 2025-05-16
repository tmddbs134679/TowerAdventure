using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;   
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void FaceTarget()
    {
        if(stateMachine.Targeter.CurrentTarget == null) { return; }

        Vector3 lookPos = stateMachine.Targeter.CurrentTarget.transform.position - stateMachine.transform.position;

        lookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }

    protected void Dodge()
    {
        stateMachine.SwitchState(stateMachine.States[EPLAYERSTATE.DODGE]);
    }

    protected void Skill_Q()
    {
        var skill = stateMachine.Skills[0]; 
        var skillState = (PlayerSkillState)stateMachine.States[EPLAYERSTATE.SKILL];
        
        skillState.SetSkill(skill);
        stateMachine.SwitchState(stateMachine.States[EPLAYERSTATE.SKILL]);
    }
    protected Vector3 CalculateMovement()
    {
        Vector3 movement = new Vector3();

        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;

        return movement;
    }
    //private Vector3 CalculateMovent()
    //{
    //    Vector3 movement = new Vector3();

    //    return movement;
    //}
}
