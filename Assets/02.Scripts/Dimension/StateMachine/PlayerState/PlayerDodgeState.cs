using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : PlayerBaseState
{
    private readonly int DodgeHas = Animator.StringToHash("Dodge");
    private const float CrossFadeDuration = 0.1f;
    private float dodgeDuration = 0.2f;
    private float elapsedTime = 0f;
    private Vector3 dodgeDir = Vector3.zero;
    private float dodgeForce = 6f;

    public PlayerDodgeState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        dodgeDir = stateMachine.transform.forward;
        Debug.Log("Dodge");
        stateMachine.Animator.CrossFadeInFixedTime(DodgeHas, CrossFadeDuration);
    }

 
    public override void Tick(float deltaTime)
    {
        Move(dodgeDir * dodgeForce, deltaTime);

        elapsedTime += deltaTime;

        if(elapsedTime > dodgeDuration)
        {
            stateMachine.SwitchState(stateMachine.States[Define.EPLAYERSTATE.FREELOOK]);
        }
    
     
    }
    public override void Exit()
    {
        elapsedTime = 0;
    }

}
