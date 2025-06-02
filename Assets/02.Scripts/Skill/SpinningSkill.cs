using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
[CreateAssetMenu(menuName = "Skill/Spinning")]
public class SpinningSkill : SkillBase                                                      
{
    public float duration;
    public float interval = 0.5f;
    public float damage = 10f;
    public float radius = 2f;
    public float spinSpeed = 720f;



    //public override void Active(GameObject caster, Vector3 dir, Action onComplete = null)
    //{
    //    caster.GetComponent<MonoBehaviour>().StartCoroutine(SpinAttackRoutine(caster, onComplete));
    //}

    private IEnumerator SpinAttackRoutine(GameObject caster, Action onComplete)
    {
        float elapsed = 0f;
        float timer = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            timer += Time.deltaTime;

            // 회전
            caster.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

            // 타격
            if (timer >= interval)
            {
                timer = 0f;
                Collider[] hits = Physics.OverlapSphere(caster.transform.position, radius);
                foreach (var hit in hits)
                {
                    if (hit.CompareTag("Enemy"))
                    {
                        Debug.Log($"Spin hit {hit.name} for {damage}");
                        hit.GetComponent<Health>()?.DealDamage(caster, damage);
                    }
                }
            }

            yield return null;
        }
        onComplete?.Invoke();
    }
}

