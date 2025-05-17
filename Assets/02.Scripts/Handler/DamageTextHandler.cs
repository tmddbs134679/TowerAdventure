using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DamageTextHandler : MonoBehaviour
{
    private Health health;

    private void Awake() => health = GetComponent<Health>();
    private void OnEnable() => health.OnTakeDamage += HandleDamageText;
    private void OnDisable() => health.OnTakeDamage -= HandleDamageText;


    private void HandleDamageText(float dmg, Vector3 pos)
    {
        DamageTextPool.Inst.ShowDamageText(dmg, pos);
    }
}
