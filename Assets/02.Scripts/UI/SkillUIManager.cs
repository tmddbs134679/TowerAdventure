using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIManager : MonoBehaviour
{
    public SkillCooldownSlot[] skillslots;

    private void OnEnable()
    {
        EventBus.Subscribe<SkillUsedEvent>(OnSkillUsed);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<SkillUsedEvent>(OnSkillUsed);
    }


    private void OnSkillUsed(SkillUsedEvent e)
    {
        skillslots[e.skillIdx].SetSkill(e.skill);
        skillslots[e.skillIdx].TriggerCooldown();
     
    }





}
