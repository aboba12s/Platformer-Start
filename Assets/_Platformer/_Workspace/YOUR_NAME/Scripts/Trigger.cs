using System;
using UnityEngine;

[Serializable]
enum TriggerType
{
    Enter,
    Exit
}

[RequireComponent(typeof(Collider2D))]
public abstract class Trigger : MonoBehaviour
{
    [SerializeField] private TriggerType type;
    [SerializeField] private bool once;

    private bool _done;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type != TriggerType.Enter || _done) return;
        _done = once;
        Activate(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (type != TriggerType.Exit || _done) return;
        _done = once;
        Activate(collision);
    }

    public abstract void Activate(Collider2D other);
}

