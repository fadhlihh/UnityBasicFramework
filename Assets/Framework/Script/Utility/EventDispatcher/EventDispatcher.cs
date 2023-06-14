using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Utility
{
    public class EventDispatcher : Singleton<EventDispatcher>
    {
        public Dictionary<string, Action> _events = new Dictionary<string, Action>();

        public void StartListening(string eventName, Action action)
        {
            bool isEventExist = _events.ContainsKey(eventName);
            if (!isEventExist)
            {
                _events.Add(eventName, action);
                Debug.Log($"Subscribe, Event: {_events.Count}");
            }
            else
            {
                _events[eventName] += action;
            }
        }

        public void StopListening(string eventName, Action action)
        {
            bool isEventExist = _events.ContainsKey(eventName);
            if (isEventExist)
            {
                _events[eventName] -= action;
                Debug.Log($"Subscribe, Event: {_events.Count}");
            }
        }

        public void TriggerEvent(string eventName)
        {
            bool isEventExist = _events.ContainsKey(eventName);
            if (isEventExist)
            {
                _events[eventName].Invoke();
            }
        }
    }
}
