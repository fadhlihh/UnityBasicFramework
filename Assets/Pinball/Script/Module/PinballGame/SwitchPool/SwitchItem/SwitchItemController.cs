using System.Collections;
using UnityEngine;
using Framework.Entity;
using Pinball.Messages;

namespace Pinball.Module.SwitchItem
{
    public class SwitchItemController : Controller<SwitchItemData, ISwitchItemData>
    {
        [SerializeField]
        private Material _onMaterial;
        [SerializeField]
        private Material _offMaterial;

        private Renderer _renderer;


        public void SetIsOn(bool isOn)
        {
            _data.IsOn = isOn;
            _renderer.material = (isOn) ? _onMaterial : _offMaterial;
        }

        public void SetIsBlinking(bool isBlinking)
        {
            _data.IsBlinking = isBlinking;
            if (!_data.IsBlinking && !_data.IsOn)
            {
                _renderer.material = _offMaterial;
            }
        }

        protected override void OnControllerAwake()
        {
            base.OnControllerAwake();
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            if (_data.IsBlinking)
            {
                // StartCoroutine(Blinking(5));
            }
        }

        private IEnumerator Blinking(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            _renderer.material = _onMaterial;
            yield return new WaitForSeconds(delayTime);
            _renderer.material = _offMaterial;
            yield return new WaitForSeconds(delayTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                SetIsOn(!_data.IsOn);
                SendMessage<TriggerSwitchMessage>(new TriggerSwitchMessage(_data.IsOn));
            }
        }
    }
}
