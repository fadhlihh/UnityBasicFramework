using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Entity;

namespace Example.Module.Timer
{
    public class TimerData : Data
    {
        public float Duration { get; set; } = 10f;
        public float Countdown { get; set; }
    }
}
