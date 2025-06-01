using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.Examples.TMP_ExampleScript_01;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;
    public Define.EOBJECTTYPE ObjectType { get; protected set; }
    // Update is called once per frame
    protected virtual void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();

    }

}
