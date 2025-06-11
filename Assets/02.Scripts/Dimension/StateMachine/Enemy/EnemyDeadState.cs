using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class EnemyDeadState : EnemyBaseState
{
    private readonly int DeadHas = Animator.StringToHash("Dead");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        if(stateMachine.Weapon != null)
        stateMachine.Weapon.gameObject.SetActive(false);

        stateMachine.Animator.CrossFadeInFixedTime(DeadHas, CrossFadeDuration);

        GameObject.Destroy(stateMachine.Target);
    }

    public override void Tick(float deltaTime)
    {
        AnimatorStateInfo stateInfo = stateMachine.Animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f)
        {
            stateMachine.SwitchState(stateMachine.States[EENEMYSTATE.IDLE]);
        }
    }

    public override void Exit()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(stateMachine.transform.DOScale(0f, 0.2f).SetEase(Ease.InOutBounce)).OnComplete(() =>
        {
            stateMachine.StopAllCoroutines();
            stateMachine.Agent.velocity = Vector3.zero;
            Managers.Object.Despawn(stateMachine.GetComponent<MonsterController>());
        });
    }
}
