using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Attack : UI_Base
{
    enum GameObjects
    { 
        AttackObject,
    }
    enum Buttons
    {
        AttackButton,
    }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        #region Object Bind
        BindObject(typeof(GameObjects));
        GetButton((int)GameObjects.AttackObject).gameObject.BindEvent(OnPointerDown, null, type: Define.EUIEVENT.POINTERDOWN);
        GetButton((int)GameObjects.AttackObject).gameObject.BindEvent(OnPointerUp, null, type: Define.EUIEVENT.POINTERUP);


        #endregion

        return true;
    }

    public void OnPointerDown()
    {
        PlayerSelector.Inst.Input.OnAttackClick();
    }

    public void OnPointerUp()
    {
        PlayerSelector.Inst.Input.ResetAttack();
    }

}
