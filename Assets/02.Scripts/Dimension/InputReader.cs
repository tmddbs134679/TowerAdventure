using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue {  get; private set; } 

    public event Action JumpEvent;
    public event Action DodgeEvent;
    public event Action TargetEvent;
    public event Action CancelEvent;
    public event Action SkillEvent;
    public bool IsAttacking { get; private set; }

    private Controls controls;

    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        DodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        TargetEvent?.Invoke();  
    }

 
    public void OnCancel(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        CancelEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //if (context.performed)
        //{
        //    IsAttacking = true;
        //}
    }
    public void OnAttackClick()
    {
        IsAttacking = true;
    }

    // 공격 입력 처리 후 꼭 호출!
    public void ResetAttack()
    {
        IsAttacking = false;
    }

    public void OnSkill(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SkillEvent?.Invoke();
    }

  
}
