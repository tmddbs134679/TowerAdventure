using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    public event Action<Vector3> OnLadderDetect;
    private void OnTriggerEnter(Collider other)
    {
        OnLadderDetect?.Invoke(other.transform.forward);
    }
}
