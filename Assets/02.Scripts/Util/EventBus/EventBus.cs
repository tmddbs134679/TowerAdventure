using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class EventBus 
{
    private static Dictionary<Type, Action<BaseEvent>> listeners = new();

    public static void Subscribe<T>(Action<T> callback) where T : BaseEvent
    {
        Type eventType = typeof(T);

        if (!listeners.ContainsKey(eventType))
            listeners[eventType] = _ => { };

        listeners[eventType] += (e) => callback((T)e);
    }

    public static void Unsubscribe<T>(Action<T> callback) where T : BaseEvent
    {
        Type eventType = typeof(T);
        if (listeners.ContainsKey(eventType))
            listeners[eventType] -= (e) => callback((T)e);
    }

    public static void Publish(BaseEvent e)
    {
        Type eventType = e.GetType();
        if(listeners.TryGetValue(eventType, out var callback))
        {
            callback.Invoke(e);
        }    
    }

}
