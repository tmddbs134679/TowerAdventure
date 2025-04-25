using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{

    private Camera mainCaemra;

    [SerializeField] private List<Target> targets = new List<Target>();

    public Target CurrentTarget { get; private set; }


    private void Start()
    {
        mainCaemra = Camera.main;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) 
        { return; }

        targets.Add(target);
        target.OnDestroyed += RemoveTarget;

    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.TryGetComponent<Target>(out Target target))
        { return; }
        
         RemoveTarget(target);
    }

    public bool SelectTatget()
    {
        if (targets.Count == 0) 
        { return false; }

        Target closestTarget = null;
        float closestTargetDistance = Mathf.Infinity;

        foreach (var target in targets)
        {
            float distance = (target.transform.position - transform.position).sqrMagnitude;
         
            if (distance < closestTargetDistance)
            {
                closestTarget = target;
                closestTargetDistance = distance;
            }
        }

        if (closestTarget == null) { return false; }

        CurrentTarget = closestTarget;
        return true;
    }

    public void Cancel()
    {
        CurrentTarget = null;
    }

    private void RemoveTarget(Target target)
    {
        if (CurrentTarget == target)
        {
            CurrentTarget = null;
        }

        target.OnDestroyed -= RemoveTarget;
        targets.Remove(target);
    }



}