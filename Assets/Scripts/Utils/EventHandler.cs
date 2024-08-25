using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<bool> DialogueBeginEvent;
    public static void CallDialogueBeginEvent(bool isRefreshTip)
    {
        DialogueBeginEvent?.Invoke(isRefreshTip);
    }

    public static event Action DialogueEndEvent;
    public static void CallDialogueEndEvent()
    {
        DialogueEndEvent?.Invoke();
    }
}
