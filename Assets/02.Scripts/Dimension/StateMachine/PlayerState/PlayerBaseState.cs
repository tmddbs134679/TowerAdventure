using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
        if(stateMachine.CanDodge)
        {
            stateMachine.SwitchState(stateMachine.States[EPLAYERSTATE.DODGE]);
            SetDodgeCooldown();
        }
      
    }

    //protected void Skill_Q()
    //{
    //    var skill = stateMachine.Skills[0];

    //    if (!stateMachine.CanSkillQ) return;

    //    SetSkillCooldown();

    //    var skillState = (PlayerSkillState)stateMachine.States[EPLAYERSTATE.SKILL];
        
    //    skillState.SetSkill(skill);
    //    stateMachine.SwitchState(stateMachine.States[EPLAYERSTATE.SKILL]);
    //}

  

    protected Vector3 CalculateMovement()
    {
        Vector3 movement = new Vector3();

        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;

        return movement;
    }


    public void SetDodgeCooldown()
    {
        stateMachine.lastDodgeTime = Time.time;
    }
    public void SetSkillCooldown()
    {
        stateMachine.lastSkill_Q_Time = Time.time;
    }
}
