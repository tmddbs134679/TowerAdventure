using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{

    private readonly int LocomotionHas = Animator.StringToHash("Locomotion");
    private readonly int SpeedHas = Animator.StringToHash("Speed");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;


    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHas, CrossFadeDuration);
    }



    public override void Tick(float deltaTime)
    {
        if(!IsInChaseRange())
        {
            stateMachine.SwitchState(stateMachine.States[Define.EENEMYSTATE.IDLE]);
            return;
        }
        else if(IsInAttackRange())
        {
            stateMachine.SwitchState(stateMachine.States[Define.EENEMYSTATE.ATTACK]);
            return;
        }

        MoveToPlayer(deltaTime);

        Extension.LookAtPlayer(stateMachine.gameObject);




        stateMachine.Animator.SetFloat(SpeedHas, 1f, AnimatorDampTime, deltaTime);
    }

    public override void Exit()
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
            stateMachine.Agent.ResetPath();
            stateMachine.Agent.velocity = Vector3.zero;
        }
    }

    private void MoveToPlayer(float deltaTime)
    {

        if (!stateMachine.Agent.isOnNavMesh)
            return;

        // 1. 목적지 설정 (NavMeshAgent는 경로만 계산)
        stateMachine.Agent.updatePosition = false;
        stateMachine.Agent.updateRotation = false;
        stateMachine.Agent.destination = stateMachine.Player.transform.position;

        // 2. 경로 계산 결과를 기반으로 직접 이동
        Vector3 velocity = stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed;
        stateMachine.Controller.Move(velocity * deltaTime); // 이게 당신의 Move()

        // 3. 위치 동기화
        stateMachine.Agent.nextPosition = stateMachine.Controller.transform.position;
    }


  
}
