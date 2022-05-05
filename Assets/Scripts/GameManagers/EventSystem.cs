using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem current;

    private void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    public event Action onOrcaPickup;
    public event Action onPromptEnd;
    public event Action onPromptStart;

    public void orcaPickup()
    {
        if (onOrcaPickup != null) { onOrcaPickup(); }
    }
    public void promptEnd()
    {
        if (onPromptEnd != null) { onPromptEnd(); }
    }

    public void promptStart()
    {
        if (onPromptStart != null) { onPromptStart(); }
    }
}
