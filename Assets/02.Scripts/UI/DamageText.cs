using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private Vector3 floatOffset;

    public TextMeshProUGUI dmgtxt;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
 
    private float Speed = 1f;
    private float lifeTime = 1f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(float damage, Vector3 worldPosition, Action onComplete = null)
    {
        transform.position = worldPosition + floatOffset;
        dmgtxt.text = damage.ToString();
        StartCoroutine(TextAnim(onComplete));
    }

    private IEnumerator TextAnim(Action onComplete = null)
    {
        float elapsed = 0f;

        while (elapsed < lifeTime)
        {
            float t = elapsed / lifeTime;


            transform.position += Vector3.up * Speed * Time.deltaTime;


            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;

        onComplete?.Invoke();
    }



}