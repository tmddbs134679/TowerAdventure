
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public static class Extension
{
    public static T GetorAddComponent<T>(this GameObject go) where T : Component
    {
        return Util.GetOrAddComponent<T>(go);
    }


    public static void BindEvent(this GameObject go, Action action = null, Action<BaseEventData> dragAction = null, Define.EUIEVENT type = Define.EUIEVENT.CLICK)
    {
        UI_Base.BindEvent(go, action, dragAction, type);
    }

    public static bool IsValid(this GameObject go)
    {
        return go != null && go.activeSelf;
    }

    public static bool IsValid(this BaseController bc)
    {
        return bc != null && bc.isActiveAndEnabled;
    }


}