// #define DEBUG_EVENTS

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    [TextArea] [SerializeField] private string description;

    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {
#if (DEBUG_EVENTS)
        Debug.Log("Event " + name + " raised");
#endif
        for (int index = listeners.Count - 1; index >= 0; --index)
        {
            listeners[index].OnEventRaised();
        }
    }
}