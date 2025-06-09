using System.Collections;
using UnityEngine;

public class AttackArea : BaseController
{
    CreatureController attacker;
    public Transform backGroundObject;
    public Transform visualObject;
    private float growDuration;
    private float radius;
    private Vector3 initPos;

    // 축별로 커질지 말지 설정
    public bool growX = true;
    public bool growY = false;
    public bool growZ = true;

    private bool active = false;
    private Vector3 originalScale;

    public void Init(CreatureController attacker,float duration, float explosionRadius, Vector3 pos)
    {
        this.attacker = attacker;
        growDuration = duration;
        radius = explosionRadius;
        initPos = pos;


    }

    void Start()
    {
        float baseVisualRadius = 0.5f;
        float scaleFactor = radius / baseVisualRadius;

       
        Vector3 current = visualObject.localScale;

        if (visualObject == null)
            visualObject = transform;


        visualObject.localScale = new Vector3(
            growX ? 0f : current.x,
            growY ? 0f : current.y,
            growZ ? 0f : current.z
        );


        originalScale = new Vector3(
            scaleFactor,
            scaleFactor,
            scaleFactor
        );

       
        originalScale = new Vector3
            (
               growX ? originalScale.x : current.x,
               growY ? originalScale.y : current.y,
               growZ ? originalScale.z : current.z
            );

       // backGroundObject.position = initPos;
        backGroundObject.localScale = originalScale;


        StartCoroutine(GrowAndAttack());
    }

    IEnumerator GrowAndAttack()
    {
        float elapsed = 0f;

        while (elapsed < growDuration)
        {
            float t = elapsed / growDuration;

            visualObject.localScale = new Vector3
            (
                growX ? Mathf.Lerp(0f, originalScale.x, t) : originalScale.x,
                growY ? Mathf.Lerp(0f, originalScale.y, t) : originalScale.y,
                growZ ? Mathf.Lerp(0f, originalScale.z, t) : originalScale.z
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        visualObject.localScale = originalScale;


        Collider[] targets = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in targets)
        {
          
           var health = col.GetComponent<Health>();
           if (health != null)
               health.DealDamage(attacker, attacker.CreatureData.Atk);
           
        }

        active = false;

        yield return null;
        gameObject.SetActive(active);
    }
}
