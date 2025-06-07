using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldownSlot : MonoBehaviour
{
    //[Header("UI References")]
    //public GameObject rootObject; // 전체 버튼 or 이미지의 부모 오브젝트
    //public Image icon;
    //public Image cooldownFillImage;
    //public TextMeshProUGUI cooldownText;

    //private float cooldownDuration;

    //private float remainingTime;
    //private bool isCooling;

    //private void Start()
    //{
    //    ResetUI();
    //}

    //public void SetSkill(SkillBase skill)
    //{
    //    icon.sprite = skill.SkillIcon;
    //    cooldownDuration = skill.cooldown;
    //    cooldownFillImage.sprite = icon.sprite;
    //    cooldownFillImage.fillAmount = 0;
    //    cooldownText.text = "";
    //}


    //public void TriggerCooldown()
    //{
    //    if (isCooling) return;

    //    remainingTime = cooldownDuration;
    //    cooldownFillImage.fillAmount = 1f;
    //    isCooling = true;
    //    StartCoroutine(CooldownRoutine());
    //}

    //private IEnumerator CooldownRoutine()
    //{
    //    while (remainingTime > 0f)
    //    {
    //        remainingTime -= Time.deltaTime;

    //        float ratio = Mathf.Clamp01(remainingTime / cooldownDuration);
    //        cooldownFillImage.fillAmount = ratio;
    //        cooldownText.text = Mathf.Ceil(remainingTime).ToString("00");

    //        yield return null;
    //    }

    //    ResetUI();
    //}

    //private void ResetUI()
    //{
    //    cooldownFillImage.fillAmount = 0f;
    //    cooldownText.text = "";
    //    isCooling = false;
    //}
}
