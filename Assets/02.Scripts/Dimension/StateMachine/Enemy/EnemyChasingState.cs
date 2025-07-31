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

        // 1. ������ ���� (NavMeshAgent�� ��θ� ���)
        stateMachine.Agent.updatePosition = false;
        stateMachine.Agent.updateRotation = false;
        stateMachine.Agent.destination = stateMachine.Player.transform.position;

        // 2. ��� ��� ����� ������� ���� �̵�
        Vector3 velocity = stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed;
        stateMachine.Controller.Move(velocity * deltaTime); // �̰� ����� Move()

        // 3. ��ġ ����ȭ
        stateMachine.Agent.nextPosition = stateMachine.Controller.transform.position;
    }


  
}
