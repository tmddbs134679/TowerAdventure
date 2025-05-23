using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIManager : MonoBehaviour
{
    public SkillCooldownSlot[] skillslots;

    private void OnEnable()
    {
        PlayerSelector.Inst.OnPlayerChanged += Init;
        EventBus.Subscribe<SkillUsedEvent>(OnSkillUsed);
    }

    private void OnDisable()
    {
        if(PlayerSelector.Inst != null) 
            PlayerSelector.Inst.OnPlayerChanged -= Init;

        EventBus.Unsubscribe<SkillUsedEvent>(OnSkillUsed);
    }


    public void Init(GameObject player)
    {
        List<SkillBase> skills =
            player.GetComponent<PlayerStateMachine>().Skills;

        for (int i=0; i <  skillslots.Length; i++)
        {
            skillslots[i].SetSkill(skills[i]);
        }
    }

    private void OnSkillUsed(SkillUsedEvent e)
    {
        skillslots[e.skillIdx].SetSkill(e.skill);
        skillslots[e.skillIdx].TriggerCooldown();
     
    }






}
