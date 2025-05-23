using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Todo: 주석 잘 달기.
public abstract class BaseEvent { }

/// <summary>
/// Player HP바, Text 처리 이벤트
/// </summary>
public class PlayerDamagedEvent : BaseEvent
{
    public GameObject Player;
    public int NewHP;
    public int MaxHP;
}

public class SkillUsedEvent : BaseEvent
{
    public SkillBase skill;
    public int skillIdx;

    public SkillUsedEvent(SkillBase skill, int idx)
    {
        this.skill = skill;
        this.skillIdx = idx;
    }
}



// Enum, String과 class 차이 정리  