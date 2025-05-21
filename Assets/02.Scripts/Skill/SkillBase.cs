using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillBase : ScriptableObject
{

    public string SkillName;
    public Sprite SkillIcon;
    public float cooldown = 1f;
    private float lastUseTime = -Mathf.Infinity;
    [Header("움직임 제어")]
    public bool canMove = false;
    public float moveSpeed;

    public bool IsOnCooldown => Time.time < lastUseTime + cooldown;

    public virtual void Active(GameObject caster, Vector3 dir, Action onComplete = null)
    {
        lastUseTime = Time.time;
    }
}
