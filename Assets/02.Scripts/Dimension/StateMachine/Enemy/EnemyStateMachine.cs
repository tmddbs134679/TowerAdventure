using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Define;
public class EnemyStateMachine : StateMachine
{

    public Dictionary<EENEMYSTATE, EnemyBaseState> States = new Dictionary<EENEMYSTATE, EnemyBaseState>();
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }

    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    [field: SerializeField] public int AttackDamage { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float PlayerChasingRange { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }

    [field: SerializeField] public float AttackKnockback { get; private set; }

    [field: SerializeField] public Target Target { get; private set; }

    //protected float cooldownTimer = 0f;
    //public bool CanAttack => cooldownTimer <= 0f;

    public Health Player { get; private set; }

    protected virtual void Awake()
    {
        States.Add(EENEMYSTATE.IDLE, new EnemyIdleState(this));
        States.Add(EENEMYSTATE.CHASING, new EnemyChasingState(this));
        States.Add(EENEMYSTATE.ATTACK, new EnemyMeleeAttackState(this));
        States.Add(EENEMYSTATE.STUN, new EnemyStunState(this));
        States.Add(EENEMYSTATE.DEAD, new EnemyDeadState(this));
    }
 
    protected virtual void Start()
    {
        Player = PlayerSelector.Inst.selectedPlayer.GetComponent<Health>();

        Agent.updatePosition = false;
        Agent.updateRotation = false;

        SwitchState(States[EENEMYSTATE.IDLE]);
    }
    protected virtual void OnEnable()
    {
        PlayerSelector.Inst.OnPlayerChanged += TargetCanged; //Player가 바뀌면 Target바꿔줌
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void TargetCanged(GameObject player)
    {
        Player = player.GetComponent<Health>();
    }

    protected virtual void OnDisable()
    {
        if(PlayerSelector.Inst != null) //싱글톤이 먼저 사라지는거 같음 일단 예외처리
             PlayerSelector.Inst.OnPlayerChanged -= TargetCanged;

        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage(float _, Vector3 __)
    {
        SwitchState(States[EENEMYSTATE.STUN]);
    }
    private void HandleDie()
    {
        SwitchState(States[EENEMYSTATE.DEAD]);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
    }
 

}
