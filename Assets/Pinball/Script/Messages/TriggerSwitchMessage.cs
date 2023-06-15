namespace Pinball.Messages
{
    public struct TriggerSwitchMessage
    {
        public bool IsOn { get; set; }

        public TriggerSwitchMessage(bool isOn)
        {
            IsOn = isOn;
        }
    }
}
