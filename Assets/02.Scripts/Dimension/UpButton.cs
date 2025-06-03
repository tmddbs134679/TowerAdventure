using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpButton : Button
{
     //m_OnUp;
    public ButtonClickedEvent onButtonUp
    {
        get; private set;
    } = new ButtonClickedEvent();

    public ButtonClickedEvent onButtonDown
    {
        get; private set;
    } = new ButtonClickedEvent();


    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        onButtonUp.Invoke();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        onButtonDown.Invoke();
    }


}
