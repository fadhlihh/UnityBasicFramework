using Framework.Entity;

namespace Pinball.Module.SwitchItem
{
    public class SwitchItemData : Data, ISwitchItemData
    {
        public bool IsOn { get; set; } = false;
        public bool IsBlinking { get; set; } = true;
    }
}
