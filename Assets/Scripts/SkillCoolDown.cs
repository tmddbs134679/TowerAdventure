using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolDown : MonoBehaviour
{
    public GameObject[] hideSkillBtns;
    public GameObject[] textPros;
    public TextMeshProUGUI[] hideSkillTimetxts;
    public Image[] hideSkillImages;

    private float[] skillTimes = { 10f, 20f, 30f };
    private float[] remainingTimes = { 0f, 0f, 0f };
    private bool[] isCooldown = { false, false, false };

    private void Start()
    {
        for (int i = 0; i < textPros.Length; i++)
        {
            hideSkillTimetxts[i] = textPros[i].GetComponent<TextMeshProUGUI>();
            hideSkillBtns[i].SetActive(false);
            hideSkillImages[i].fillAmount = 0;
        }
    }

    public void HideSkillSetting(int skillIndex)
    {
        if (skillIndex < 0 || skillIndex >= skillTimes.Length) return;

        if (!isCooldown[skillIndex])
        {
            remainingTimes[skillIndex] = skillTimes[skillIndex];
            hideSkillBtns[skillIndex].SetActive(true);
            isCooldown[skillIndex] = true;
            StartCoroutine(SkillCooldownCoroutine(skillIndex));
        }
    }

    private IEnumerator SkillCooldownCoroutine(int skillIndex)
    {
        while (remainingTimes[skillIndex] > 0)
        {
            remainingTimes[skillIndex] -= Time.deltaTime;
            float ratio = Mathf.Clamp01(remainingTimes[skillIndex] / skillTimes[skillIndex]);
            hideSkillTimetxts[skillIndex].text = Mathf.Ceil(remainingTimes[skillIndex]).ToString("00");
            hideSkillImages[skillIndex].fillAmount = ratio;

            yield return null;
        }

        hideSkillBtns[skillIndex].SetActive(false);
        isCooldown[skillIndex] = false;
    }
}
