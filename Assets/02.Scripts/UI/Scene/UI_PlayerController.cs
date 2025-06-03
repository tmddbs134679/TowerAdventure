using System;
using System.Collections;
using System.Collections.Generic;
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
        Skill1Button,
        Skill2Button,
        Skill3Button,
        SelectPlayer1Button,
        SelectPlayer2Button,
        SelectPlayer3Button,
    }

    enum Images
    {
        Skill1_Icon,
        Skill2_Icon,
        Skill3_Icon,
    }

    enum Texts
    {
        Skill1_Text,
        Skill2_Text,
        Skill3_Text,
        SelectPlyer1_Text,
        SelectPlyer2_Text,
        SelectPlyer3_Text,
    }
    #endregion

    private void Awake()
    {
        Init();
    }
    public override bool Init()
    {
        if(base.Init() == false)
            return false;

        #region Bind


        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

;
        //GetButton((int)Buttons.SelectPlayer1Button).gameObject.BindEvent(OnClickPlayerSelectButton);
        //GetButton((int)Buttons.SelectPlayer2Button).gameObject.BindEvent(OnClickPlayerSelectButton);
        //GetButton((int)Buttons.SelectPlayer3Button).gameObject.BindEvent(OnClickPlayerSelectButton);


        #endregion
        return true;
    }


    private void OnClickPlayerSelectButton()
    {
       
    }

    private void OnClickAttackButton()
    {
       
    }
}
