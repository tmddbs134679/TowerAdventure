using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Define;

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
        Select1_CoolDownImage = 0,
        Select2_CoolDownImage,
        Select3_CoolDownImage, 
        Dodgecooldown_Image,
        Skill1cooldown_Image,
        Skill2cooldown_Image,
        Select1_LockImage,
        Select2_LockImage,
        Select3_LockImage,
    }

    enum Texts
    {
        Dodgecooldown_Text,
        Skill1cooldown_Text,
        Skill2cooldown_Text,
    }

    #endregion

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        GetImage((int)Images.Dodgecooldown_Image).gameObject.SetActive(false);
        GetImage((int)Images.Select1_LockImage).gameObject.SetActive(false);
        GetImage((int)Images.Select2_LockImage).gameObject.SetActive(false);
        GetImage((int)Images.Select3_LockImage).gameObject.SetActive(false);

        GetText((int)Texts.Dodgecooldown_Text).gameObject.SetActive(false);
    }


    public override bool Init()
    {
        if(base.Init() == false)
            return false;

        #region Bind
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
        //예외처리

        if (!PlayerSelector.Inst.CanSelectPlayer) return;

        PlayerSelector.Inst.SelectPlayer(idx);

        for(int i = 0; i < 3; i++)
        {
            GetImage((int)Images.Select1_LockImage + i).gameObject.SetActive(true);
            Image img = GetImage((int)Images.Select1_CoolDownImage + i);
            StartCoroutine(CooldownRoutine(img, PLAYER_SELECT_COOLTIME, null, true));
        }
       
    }

    private void OnClickDodge()
    {
        if (!PlayerSelector.Inst.selectedPlayer.CanDodge) return; 


        PlayerSelector.Inst.Input.OnDodgeClick();
        float cooldown = PlayerSelector.Inst.selectedPlayer.DodgeCooldown;
        StartCoroutine(CooldownRoutine(GetImage((int)Images.Dodgecooldown_Image), cooldown, GetText((int)Texts.Dodgecooldown_Text)));

    }

    private void OnAttackPointDown()
    {
        PlayerSelector.Inst.Input.OnAttackClick();
    }

    private void OnAttackPointUp()
    {
        PlayerSelector.Inst.Input.ResetAttack();
    }


    //Text까지 표시해야한다면 넣고 아니면 null, 잠금 있으면 isLocked = True
    private IEnumerator CooldownRoutine(Image cooldownFillImage, float duration, TMP_Text cooldownText = null, bool isLocked = false)   
    {
        cooldownFillImage.gameObject.SetActive(true);
        if (cooldownText != null)
            cooldownText.gameObject.SetActive(true);

        float remainingTime = duration;

        while (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;

            float ratio = Mathf.Clamp01(remainingTime / duration);
            cooldownFillImage.fillAmount = ratio;

            if (cooldownText != null)
                cooldownText.text = Mathf.CeilToInt(remainingTime).ToString("00");

            yield return null;
        }

        cooldownFillImage.fillAmount = 0f;
        cooldownFillImage.gameObject.SetActive(false);

        if (cooldownText != null)   //쿨타임 있으면 초기화
        {
            cooldownText.text = "";
            cooldownText.gameObject.SetActive(false);
        }

        if(isLocked)        //자물쇠 있으면 초기화
        {
            for(int i=0; i < 3; i++)
            {
                GetImage((int)Images.Select1_LockImage + i).gameObject.SetActive(false);
            }
        }

    }
}
