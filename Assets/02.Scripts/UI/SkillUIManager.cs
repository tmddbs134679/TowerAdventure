using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIManager : MonoBehaviour
{
    public UpButton attackBtn;

    public Button Skill1_Btn;
    public Button Skill2_Btn;
    public Button Skill3_Btn;

    public SkillCooldownSlot[] skillslots;


    private void OnEnable()
    {
        PlayerSelector.Inst.OnPlayerChanged += Init;
        attackBtn.onButtonDown.AddListener(PlayerSelector.Inst.Input.OnAttackClick);
        attackBtn.onButtonUp.AddListener(PlayerSelector.Inst.Input.ResetAttack);
   
    }

    private void OnDisable()
    {
        if(PlayerSelector.Inst != null) 
            PlayerSelector.Inst.OnPlayerChanged -= Init;
    }


    public void Init(GameObject player)     //이름 변경
    {
        //List<SkillBase> skills =
        //    player.GetComponent<PlayerStateMachine>().Skills;

        //for (int i=0; i <  skillslots.Length; i++)
        //{
        //    skillslots[i].SetSkill(skills[i]);
        //}

        Skill1_Btn.onClick.RemoveAllListeners();
        Skill2_Btn.onClick.RemoveAllListeners();
        Skill3_Btn.onClick.RemoveAllListeners();

        Skill1_Btn.onClick.AddListener(() => UseSkill(0));
        Skill2_Btn.onClick.AddListener(() => UseSkill(1));
        Skill3_Btn.onClick.AddListener(() => UseSkill(2));
    }

    private void UseSkill(int idx)
    {
    
        //List<SkillBase> skills =
        //PlayerSelector.Inst.selectedPlayer.GetComponent<PlayerStateMachine>().Skills;

        //skillslots[idx].SetSkill(skills[idx]);
        //skillslots[idx].TriggerCooldown();

        //var skill = skills[idx];
        //EventBus.Publish(new SkillUsedEvent(skill, idx));
    }
}
