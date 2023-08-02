using UnityEngine;
using Framework.Entity;
using Pinball.Messages;

namespace Pinball.Module.Trap
{
    public class TrapController : Controller<TrapData>
    {
        public void InitObject()
        {
            _data.Countdown = _data.Lifespan;
        }

        protected override void OnControllerAwake()
        {
            base.OnControllerAwake();
            InitObject();
        }

        private void Update()
        {
            CountLifeTime();
        }

        private void CountLifeTime()
        {
            if (_data.Countdown > 0)
            {
                _data.Countdown -= 1 * Time.deltaTime;
            }
            else
            {
                DestroyTrap();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                TriggerEvent("RespawnBall");
                DestroyTrap();
            }
        }

        private void DestroyTrap()
        {
            SendMessage<DestroyTrapMessage>(new DestroyTrapMessage(gameObject));
        }
    }
}
