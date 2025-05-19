using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Dictionary<EPLAYERSTATE, PlayerBaseState> States = new Dictionary<EPLAYERSTATE, PlayerBaseState>();
    [field: SerializeField]public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }

    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    [field: SerializeField] public LadderDetector LadderDetector { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Targeter Targeter { get; private set; }
    [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
    [field: SerializeField] public float RotationDamping { get; private set; }

    [field: SerializeField] public WeaponDamage Weapon { get; private set; }

    [field: SerializeField] public Attack[] Attaks { get; private set; }

    [field: SerializeField] public List<SkillBase> Skills { get; private set; }

    [field: SerializeField] public float DodgeCooldown;
    public bool CanDodge => Time.time >= lastDodgeTime + DodgeCooldown;

    [HideInInspector]
    public float lastDodgeTime = -Mathf.Infinity;
    private void Awake()
    {
        States.Add(EPLAYERSTATE.FREELOOK, new PlayerFreeLookState(this));
        States.Add(EPLAYERSTATE.DODGE, new PlayerDodgeState(this));
        States.Add(EPLAYERSTATE.ATTACK, new PlayerAttackingState(this, 0));
        States.Add(EPLAYERSTATE.SKILL, new PlayerSkillState(this));
        States.Add(EPLAYERSTATE.DEAD, new PlayerDeadState(this));
        States.Add(EPLAYERSTATE.CLIMB, new PlayerClimbState(this, Vector3.zero));
        States.Add(EPLAYERSTATE.STUN, new PlayerStunState(this));
    }


    // Start is called before the first frame update
    private void Start()
    {
        //SwitchState(new PlayerFreeLookState(this));
        SwitchState(States[EPLAYERSTATE.FREELOOK]);
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage(float _, Vector3 __)
    {
        SwitchState(States[EPLAYERSTATE.STUN]);
    }

    private void HandleDie()
    {
        SwitchState(States[EPLAYERSTATE.DEAD]);
    }



}
