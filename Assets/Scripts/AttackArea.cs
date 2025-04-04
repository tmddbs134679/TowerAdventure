using System.Collections;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public float growDuration = 1.5f;
    public float activeDuration = 0.2f;
    public int damage = 10;

    public Transform visualObject;
    public Collider triggerCollider;

    // 축별로 커질지 말지 설정
    public bool growX = true;
    public bool growY = false;
    public bool growZ = true;

    private bool active = false;
    private Vector3 originalScale;

    void Start()
    {
        if (visualObject == null)
            visualObject = transform;

        if (triggerCollider == null)
            triggerCollider = GetComponent<Collider>();

        originalScale = visualObject.localScale;

        // 초기 스케일 설정 (선택된 축만 0으로)
        visualObject.localScale = new Vector3
        (
            growX ? 0f : originalScale.x,
            growY ? 0f : originalScale.y,
            growZ ? 0f : originalScale.z
        );

        triggerCollider.enabled = false;
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
        triggerCollider.enabled = true;
        active = true;

        yield return new WaitForSeconds(activeDuration);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }
}
