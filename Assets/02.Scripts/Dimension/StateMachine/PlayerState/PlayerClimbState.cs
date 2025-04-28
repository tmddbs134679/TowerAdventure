using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerBaseState
{

    private readonly int ClimbHas = Animator.StringToHash("Climb");
    private readonly int SpeedHas = Animator.StringToHash("Speed");
    private const float CrossFadeDuration = 0.1f;

    private Vector3 ladderForward;

    public PlayerClimbState(PlayerStateMachine stateMachine, Vector3 ladderForward) : base(stateMachine)
    { 
        this.ladderForward = ladderForward;
    }

    // Start is called before the first frame update
    public override void Enter()
    {
        stateMachine.Animator.Play(ClimbHas);
        //stateMachine.Animator.CrossFadeInFixedTime(ClimbHas, CrossFadeDuration);
        //stateMachine.transform.rotation = Quaternion.LookRotation(ladderForward, Vector3.up);
       
    }



    public override void Tick(float deltaTime)
    {
        // µµÂøÇÏ¸é 
       // if(stateMachine.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) { return; }
      
       // stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    public override void Exit()
    {
       
        stateMachine.Controller.Move(Vector3.zero);
        stateMachine.ForceReceiver.Reset();
    }


}
