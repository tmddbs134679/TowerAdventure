using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Skill/Slash")]
public class SlashSkill : SkillBase
{
    public float damage = 10f;
    public float range = 2f;
    public GameObject slashEffectPrefab;
    //public override void Active(GameObject caster, Vector3 dir, Action onComplete = null)
    //{
    //    if (slashEffectPrefab != null)
    //    {
    //        GameObject effect = Instantiate(slashEffectPrefab, caster.transform.position + dir * 1f, Quaternion.LookRotation(dir));
    //    }

    //    RaycastHit[] hits = Physics.SphereCastAll(caster.transform.position, 1f, dir, range);
    //    foreach (var hit in hits)
    //    {
    //        if (hit.collider.CompareTag("Enemy"))
    //        {
    //            Debug.Log($"Hit {hit.collider.name} with Melee for {damage}");
    //            // hit.collider.GetComponent<Enemy>()?.TakeDamage(damage);
    //        }
    //    }
    //}
}
