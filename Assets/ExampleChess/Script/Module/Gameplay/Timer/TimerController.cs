using System;
using UnityEngine;
using UnityEngine.UI;
using Framework.Entity;

namespace Example.Module.Timer
{
    public class TimerController : Controller<TimerData>
    {
        [SerializeField]
        private Image _timerFill;

        private Action TimeUp;

        public void ResetTimer()
        {
            _data.Countdown = _data.Duration;
            UpdateProgressBar();
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            StartListening("ResetTimer", ResetTimer);
        }

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            ResetTimer();
        }

        private void Update()
        {
            CountTimer();
        }

        private void CountTimer()
        {
            if (_data.Countdown > 0)
            {
                _data.Countdown -= 1 * Time.deltaTime;
            }
            else
            {
                TriggerEvent("GameOver");
            }
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            _timerFill.fillAmount = _data.Countdown / _data.Duration;
        }

        private void OnDestroy()
        {
            StopListening("ResetTimer", ResetTimer);
        }
    }
}
