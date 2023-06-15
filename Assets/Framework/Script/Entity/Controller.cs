using System;
using UnityEngine;
using Framework.Utility;

namespace Framework.Entity
{
    #region Base Controller
    public class Controller : MonoBehaviour
    {
        protected void Awake()
        {
            OnControllerAwake();
        }

        protected virtual void Start()
        {
            RegisterEvent();
            RegisterMessage();
            OnControllerStart();
        }

        #region Message Dispatcher
        protected void Subscribe<TMessage>(Action<TMessage> action) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.Subscribe(action);
        }

        protected void Unsubscribe<TMessage>(Action<TMessage> action) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.Unsubscribe(action);
        }

        protected void SendMessage<TMessage>(TMessage message) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.SendMessage(message);
        }
        #endregion

        #region Event Dispatcher
        protected void StartListening(string eventName, Action action)
        {
            EventDispatcher.Instance.StartListening(eventName, action);
        }

        protected void StopListening(string eventName, Action action)
        {
            EventDispatcher.Instance.StopListening(eventName, action);
        }

        protected void TriggerEvent(string eventName)
        {
            EventDispatcher.Instance.TriggerEvent(eventName);
        }
        #endregion

        protected virtual void OnControllerAwake() { }
        protected virtual void OnControllerStart() { }
        protected virtual void RegisterEvent() { }
        protected virtual void RegisterMessage() { }
    }
    #endregion

    #region Data Controller
    public class Controller<TData> : MonoBehaviour where TData : Data, new()
    {
        protected TData _data;
        protected void Awake()
        {
            _data = new TData();
            OnControllerAwake();
        }

        protected virtual void Start()
        {
            RegisterEvent();
            RegisterMessage();
            OnControllerStart();
        }

        #region Message Dispatcher
        protected void Subscribe<TMessage>(Action<TMessage> action) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.Subscribe(action);
        }

        protected void Unsubscribe<TMessage>(Action<TMessage> action) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.Unsubscribe(action);
        }

        protected void SendMessage<TMessage>(TMessage message) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.SendMessage(message);
        }
        #endregion

        #region Event Dispatcher
        protected void StartListening(string eventName, Action action)
        {
            EventDispatcher.Instance.StartListening(eventName, action);
        }

        protected void StopListening(string eventName, Action action)
        {
            EventDispatcher.Instance.StopListening(eventName, action);
        }

        protected void TriggerEvent(string eventName)
        {
            EventDispatcher.Instance.TriggerEvent(eventName);
        }
        #endregion

        protected virtual void OnControllerAwake() { }
        protected virtual void OnControllerStart() { }
        protected virtual void RegisterEvent() { }
        protected virtual void RegisterMessage() { }
    }
    #endregion

    #region Data Controller with Interface
    public class Controller<TData, TIData> : MonoBehaviour
    where TData : Data, TIData, new()
    where TIData : IData
    {
        protected TData _data;

        public TIData Data { get { return _data; } }

        protected void Awake()
        {
            _data = new TData();
            OnControllerAwake();
        }

        protected virtual void Start()
        {
            RegisterEvent();
            RegisterMessage();
            OnControllerStart();
        }

        #region Message Dispatcher
        protected void Subscribe<TMessage>(Action<TMessage> action) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.Subscribe(action);
        }

        protected void Unsubscribe<TMessage>(Action<TMessage> action) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.Unsubscribe(action);
        }

        protected void SendMessage<TMessage>(TMessage message) where TMessage : struct
        {
            MessageDispatcher<TMessage>.Instance.SendMessage(message);
        }
        #endregion

        #region Event Dispatcher
        protected void StartListening(string eventName, Action action)
        {
            EventDispatcher.Instance.StartListening(eventName, action);
        }

        protected void StopListening(string eventName, Action action)
        {
            EventDispatcher.Instance.StopListening(eventName, action);
        }

        protected void TriggerEvent(string eventName)
        {
            EventDispatcher.Instance.TriggerEvent(eventName);
        }
        #endregion

        protected virtual void OnControllerAwake() { }
        protected virtual void OnControllerStart() { }
        protected virtual void RegisterEvent() { }
        protected virtual void RegisterMessage() { }
    }
    #endregion
}
