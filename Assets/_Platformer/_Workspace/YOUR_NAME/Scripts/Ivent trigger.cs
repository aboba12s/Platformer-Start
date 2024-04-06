using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum  SwichType
{
    Loop,
    PingPong,
    Once
}


public class SwitchTrigger : MonoBeaviour
{
    [Header("Switch")]
    [SerializeFiled] private SwichType type;
    [SerializeFiled] private UnityEvent[] events;

    private int _state;

    private int State
    {
        {
            switch (type)
            {
                case SwichType.Loop:
                    return_state % events.Length;
                case SwichType.PingPong:
                    return (int)Mathf.PingPong(_state, events.Length);
                case SwichType.Once:
                    return_state;
                default;
                    throw new ArgumentExcipition();

            }
        }
    }

    public override void Activate(Collider2D other)
    {
        if (type == SwichType.Once && State > events.Length - 1) return;
        events[State}?.Invoke();
    _state++;
        }
}


           