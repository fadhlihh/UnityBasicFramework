using Framework.Entity;

namespace Pinball.Module.SwitchItem
{
    public interface ISwitchItemData : IData
    {
        public bool IsOn { get; }
    }
}
