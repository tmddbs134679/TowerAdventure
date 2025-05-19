using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField] private float padding = 1;

    public void AutoSize()
    {

        if (transform.parent == null) return;

        Collider parentCollider = transform.parent.GetComponent<Collider>();

        if (parentCollider == null)   return;
        

        Bounds bounds = parentCollider.bounds;
        float diameter = Mathf.Max(bounds.size.x, bounds.size.z);
        float finalScale = diameter * padding;

        transform.localScale = new Vector3(finalScale, 1f, finalScale);
    }
}
