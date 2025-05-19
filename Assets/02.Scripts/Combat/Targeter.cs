using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{

    private Camera mainCaemra;
    [SerializeField]private GameObject targetCircle;

    [SerializeField] private List<Target> targets = new List<Target>();
    private float checkInterval = 0.3f;
    private float checkTimer = 0f;


    public Target CurrentTarget { get; private set; }


    private void Start()
    {
        if (targetCircle != null)
        {
            targetCircle.SetActive(false);
        }
        mainCaemra = Camera.main;
    }

    private void Update()
    {
        checkTimer -= Time.deltaTime;
        if (checkTimer <= 0f && targets.Count != 0)
        {
            checkTimer = checkInterval;
            SelectTatget(); //  가장 가까운 타겟을 다시 찾음
        }
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

        if (closestTarget == null)
        {
            targetCircle.SetActive(false);
            return false;
        }

        CurrentTarget = closestTarget;

        ShowTargetCircle(closestTarget);
        return true;
    }

    private void ShowTargetCircle(Target closestTarget)
    {
        if (closestTarget == null){  return; }

        // 타겟이 바뀌었을 때만 한 번만 수행
        targetCircle.transform.SetParent(closestTarget.transform, worldPositionStays: false);
        targetCircle.transform.localPosition = Vector3.zero;

        targetCircle.SetActive(true);
        targetCircle.GetComponent<TargetCircle>()?.AutoSize();
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

        if(targets.Count <= 0)
        {
            targetCircle.SetActive(false);
        }
  

    }



}