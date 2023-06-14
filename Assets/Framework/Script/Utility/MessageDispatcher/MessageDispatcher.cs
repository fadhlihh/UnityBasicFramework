using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Utility
{
    public class MessageDispatcher<TMessage> : Singleton<MessageDispatcher<TMessage>>
    {
        public Dictionary<Type, Action<TMessage>> _messages = new Dictionary<Type, Action<TMessage>>();
        public void Subscribe(Action<TMessage> action)
        {
            var messageType = typeof(TMessage);
            bool isEventExist = _messages.ContainsKey(messageType);
            if (!isEventExist)
            {
                _messages.Add(messageType, action);
                Debug.Log($"Subscribe, Event: {_messages.Count}");
            }
            else
            {
                _messages[messageType] += action;
            }
        }

        public void Unsubscribe(Action<TMessage> action)
        {
            var messageType = typeof(TMessage);
            bool isEventExist = _messages.ContainsKey(messageType);
            if (isEventExist)
            {
                _messages[messageType] -= action;
                Debug.Log($"Subscribe, Event: {_messages.Count}");
            }
        }

        public void SendMessage(TMessage message)
        {
            var messageType = typeof(TMessage);
            bool isEventExist = _messages.ContainsKey(messageType);
            if (isEventExist)
            {
                _messages[messageType].Invoke(message);
            }
        }
    }
}
