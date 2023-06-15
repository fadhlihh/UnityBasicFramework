using System.Collections.Generic;
using UnityEngine;
using Framework.Entity;
using Pinball.Module.SwitchItem;
using Pinball.Messages;

namespace Pinball.Module.SwitchPool
{
    public class SwitchPoolController : Controller<SwitchPoolData>
    {
        [SerializeField]
        private List<SwitchItemController> _switchItem = new List<SwitchItemController>();

        protected override void RegisterMessage()
        {
            base.RegisterMessage();
            Subscribe<TriggerSwitchMessage>(OnTriggerSwitch);
        }

        private void OnTriggerSwitch(TriggerSwitchMessage message)
        {
            if (message.IsOn)
            {
                List<SwitchItemController> onSwitchItem = _switchItem.FindAll(item => item.Data.IsOn);
                if (onSwitchItem.Count >= _switchItem.Count)
                {
                    foreach (SwitchItemController switchItem in _switchItem)
                    {
                        _data.IsBlinking = true;
                        switchItem.SetIsOn(false);
                        switchItem.SetIsBlinking(_data.IsBlinking);
                    }
                }
                else
                {
                    _data.IsBlinking = false;
                    SetItemBlinking(_data.IsBlinking);
                }
            }
            else
            {
                foreach (SwitchItemController switchItem in _switchItem)
                {
                    if (switchItem.Data.IsOn)
                    {
                        return;
                    }
                }
                _data.IsBlinking = true;
                SetItemBlinking(_data.IsBlinking);
            }
        }

        private void SetItemBlinking(bool isBlinking)
        {
            foreach (SwitchItemController switchItem in _switchItem)
            {
                switchItem.SetIsBlinking(isBlinking);
            }
        }
    }
}
