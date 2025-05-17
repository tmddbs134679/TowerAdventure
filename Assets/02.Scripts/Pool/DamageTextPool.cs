using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextPool : GenericSingleton<DamageTextPool>
{
    [SerializeField] private Canvas worldCanvas;
    [SerializeField] private DamageText damageTextPrefab;
    [SerializeField] private int initSize = 10;

    private GenericObjectPool<DamageText> damageTextPool;

    protected override void Awake()
    {
        base.Awake();
        damageTextPool = new GenericObjectPool<DamageText>(damageTextPrefab, worldCanvas.transform, initSize);
    }

    public void ShowDamageText(float dmg, Vector3 worldPosition)
    {
        DamageText text = damageTextPool.Get();
        text.Show(dmg, worldPosition, () => damageTextPool.Return(text)); 
    }
}
