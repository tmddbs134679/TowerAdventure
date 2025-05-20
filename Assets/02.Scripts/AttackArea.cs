using System.Collections;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
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

    public void Init(float duration, float explosionRadius, Vector3 pos)
    {
    
        growDuration = duration;
        radius = explosionRadius;
        initPos = pos;

        float finalSize = radius * 2f; // 직경 기준
        originalScale = new Vector3
        (
            growX ? finalSize : visualObject.localScale.x,
            growY ? finalSize : visualObject.localScale.y,
            growZ ? finalSize : visualObject.localScale.z
        );
    }

    void Start()
    {
        transform.position = initPos;

        if (visualObject == null)
            visualObject = transform;

        originalScale = visualObject.localScale;

        // 초기 스케일 설정 (선택된 축만 0으로)
        visualObject.localScale = new Vector3
        (
            growX ? 0f : originalScale.x,
            growY ? 0f : originalScale.y,
            growZ ? 0f : originalScale.z
        );

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

        active = false;

        yield return null;
        gameObject.SetActive(active);
    }
}
