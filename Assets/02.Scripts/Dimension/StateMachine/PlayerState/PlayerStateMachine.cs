using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.Examples.TMP_ExampleScript_01;


public class PlayerStateMachine : StateMachine
{
    public Dictionary<Define.EPLAYERSTATE, PlayerBaseState> States = new Dictionary<Define.EPLAYERSTATE, PlayerBaseState>();
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

    [field: SerializeField] public SkillBook skillBook { get; private set; }

    [field: SerializeField] public float DodgeCooldown;

    //이동 필요
    [field: SerializeField] public GameObject FollowCam;
    public bool CanDodge => Time.time >= lastDodgeTime + DodgeCooldown;



    // public bool CanSkillQ => Time.time >= lastSkill_Q_Time + Skills[0].cooldown;
    [HideInInspector]
    public float lastDodgeTime = -Mathf.Infinity;
    public float lastSkill_Q_Time = -Mathf.Infinity;
    private void Awake()
    {
        States.Add(Define.EPLAYERSTATE.FREELOOK, new PlayerFreeLookState(this));
        States.Add(Define.EPLAYERSTATE.DODGE, new PlayerDodgeState(this));
        States.Add(Define.EPLAYERSTATE.ATTACK, new PlayerAttackingState(this, 0));
        States.Add(Define.EPLAYERSTATE.SKILL, new PlayerSkillState(this));
        States.Add(Define.EPLAYERSTATE.DEAD, new PlayerDeadState(this));
        States.Add(Define.EPLAYERSTATE.CLIMB, new PlayerClimbState(this, Vector3.zero));
        States.Add(Define.EPLAYERSTATE.STUN, new PlayerStunState(this));
    }


    // Start is called before the first frame update
    private void Start()
    {
        SwitchState(States[Define.EPLAYERSTATE.FREELOOK]);
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;

        SwitchState(States[Define.EPLAYERSTATE.FREELOOK]);
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage(float _, Vector3 __)
    {
        SwitchState(States[Define.EPLAYERSTATE.STUN]);
    }

    private void HandleDie()
    {
        SwitchState(States[Define.EPLAYERSTATE.DEAD]);
    }

    public void DisconnectInput()
    {
        if (InputReader == null) return;
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
        InputReader = null;
    }

    //2번,,..?
    public void ConnectInput(InputReader reader)
    {
        InputReader = reader;
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }


}
