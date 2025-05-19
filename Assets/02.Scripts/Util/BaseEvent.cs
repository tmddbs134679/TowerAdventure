using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Todo: 주석 잘 달기.
public abstract class BaseEvent { }

/// <summary>
/// 설명적기
/// </summary>

public class PlayerDamagedEvent : BaseEvent
{

    public int NewHP;
    public int MaxHP;
}


// Enum, String과 class 차이 정리  