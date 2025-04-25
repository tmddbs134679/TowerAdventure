using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private float previousFrameTime;

    private bool alreadyAppliedForce;

    private Attack attack;
    public PlayerAttackingState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attaks[attackIndex];
    }

    public override void Enter()
    {
        stateMachine.Weapon.SetAttack(attack.Damage, attack.Knockback);
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);
    }

  

    public override void Tick(float deltaTime)
    {
        
        if (stateMachine.Targeter.SelectTatget())
            FaceTarget();

        Move(deltaTime);
        
        float normalizedTime = GetNormalizedTime(stateMachine.Animator);

        if (normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            if(normalizedTime >= attack.ForceTime)
            {
                TryApplyForce();
            }

            if(stateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        }
        else
        {
            //if(stateMachine.Targeter.CurrentTarget != null)
            //{
            //    stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            //}
            //else
            //{
            //    stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            //}

            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
    }


    public override void Exit()
    {
       
    }

    private void TryComboAttack(float normalizedTime)
    {
       
        if(attack.ComboStateIndex == -1) { return; }

       
        if(normalizedTime < attack.ComboAttackTime) { return; }

        stateMachine.SwitchState
        (
            new PlayerAttackingState
            (
                 stateMachine,
                 attack.ComboStateIndex
            )
        );

    }


    void TryApplyForce()
    {
        if(alreadyAppliedForce) { return; }

        stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.Force);

        alreadyAppliedForce = true;
    }



}
