using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class UI_PlayerController : UI_Scene
{
    #region Enum

    enum GameObjects
    {

    }
    enum Buttons
    {
        AttackButton,
        DodgeButton,
        Skill1Button,
        Skill2Button,
        SelectPlayer1Button,
        SelectPlayer2Button,
        SelectPlayer3Button,
    }

    enum Images
    {
        Dodge_Icon,
        Skill1_Icon,
        Skill2_Icon,
    }

    enum Texts
    {
        Dodgecooldown_Text,
        Skill1cooldown_Text,
        Skill2cooldown_Text,
        SelectPlyer1cooldown_Text,
        SelectPlyer2cooldown_Text,
        SelectPlyer3cooldown_Text,
    }
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Start()
    {

    }


    public override bool Init()
    {
        if(base.Init() == false)
            return false;

        #region Bind


        //BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindImage(typeof(Images));


        GetButton((int)Buttons.AttackButton).gameObject.BindEvent(OnAttackPointDown, null, type: Define.EUIEVENT.POINTERDOWN);
        GetButton((int)Buttons.AttackButton).gameObject.BindEvent(OnAttackPointUp, null, type: Define.EUIEVENT.POINTERUP);
        GetButton((int)Buttons.DodgeButton).gameObject.BindEvent(OnClickDodge);
        GetButton((int)Buttons.Skill1Button).gameObject.BindEvent(()=> UseSkill(0));
        GetButton((int)Buttons.Skill2Button).gameObject.BindEvent(() => UseSkill(1));
        GetButton((int)Buttons.SelectPlayer1Button).gameObject.BindEvent(() => OnClickPlayerSelectButton(0));
        GetButton((int)Buttons.SelectPlayer2Button).gameObject.BindEvent(() => OnClickPlayerSelectButton(1));
        GetButton((int)Buttons.SelectPlayer3Button).gameObject.BindEvent(() => OnClickPlayerSelectButton(2));


        #endregion
        return true;
    }

    private void UseSkill(int idx)
    {
        
    }

    private void OnClickPlayerSelectButton(int idx)
    {
        PlayerSelector.Inst.SelectPlayer(idx);
    }

    private void OnClickDodge()
    {
        PlayerSelector.Inst.Input.OnDodgeClick();
    }

    private void OnAttackPointDown()
    {
        PlayerSelector.Inst.Input.OnAttackClick();
    }

    private void OnAttackPointUp()
    {
        PlayerSelector.Inst.Input.ResetAttack();
    }
}
